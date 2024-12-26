#include <iostream>
#include <vector>
#include <cmath>
#include <ctime>
#include <limits.h>
#include <algorithm>

#define Q 1.0
#define evaporation 0.64

using namespace std;

void generateDistanceMatrix(vector<vector<double>>& distances, int numCities) {
    for (int i = 0; i < numCities; i++) {
        for (int j = i + 1; j < numCities; ++j) {
            distances[i][j] = distances[j][i] = rand() % 100 + 1; 
        }
        distances[i][i] = 0; 
    }
}

void printMatrix(vector<vector<double>>& distances, int numCities) {

    cout << "\n Исходая матрица городов: \n";
    for (int i = 0; i < numCities; i++) {
        for (int j = 0; j < numCities; j++) {
            cout << distances[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}

double calculateRouteLength(const vector<int>& route, const vector<vector<double>>& distances) {
    double length = 0.0;
    for (size_t i = 0; i < route.size() - 1; ++i) {
        length += distances[route[i]][route[i + 1]];
    }
    length += distances[route.back()][route[0]];
    return length;
}

// Обновление феромонов
void updatePheromones(vector<vector<double>>& pheromones, vector<vector<double>>& distances,
    vector<vector<int>>& routes, vector<double>& lengths) {
    int numCities = pheromones.size();

    // Испарение феромонов
    for (int i = 0; i < numCities; ++i) {
        for (int j = 0; j < numCities; ++j) {
            pheromones[i][j] *= evaporation;
        }
    }

    // Добавление новых феромонов
    for (size_t k = 0; k < routes.size(); ++k) {
        double contribution = Q / lengths[k];
        for (size_t i = 0; i < routes[k].size() - 1; ++i) {
            int from = routes[k][i];
            int to = routes[k][i + 1];
            pheromones[from][to] += contribution;
            pheromones[to][from] += contribution;
        }
        // Добавляем вклад за замыкание маршрута
        int from = routes[k].back();
        int to = routes[k][0];
        pheromones[from][to] += contribution;
        pheromones[to][from] += contribution;
    }
}

int main() {

    setlocale(LC_ALL, "rus");
    srand(time(0));

    int numCities;
    double initialPheromone;
    double alpha, beta;
    int iterations;

    cout << "Введите количество городов (N): ";
    cin >> numCities;
    cout << "Введите начальное значение феромонов (значение < 1): ";
    cin >> initialPheromone;
    cout << "Введите значения альфа и бета: ";
    cin >> alpha >> beta;
    cout << "Введите количество итераций: ";
    cin >> iterations;

    vector<vector<double>> distances(numCities, vector<double>(numCities));
    vector<vector<double>> pheromones(numCities, vector<double>(numCities));
    generateDistanceMatrix(distances, numCities);
    printMatrix(distances, numCities);

    for (int i = 0; i < numCities; ++i) {
        fill(pheromones[i].begin(), pheromones[i].end(), initialPheromone);
    }

    vector<int> bestRoute;
    double bestLength = DBL_MAX;

    for (int iter = 0; iter < iterations; ++iter) {
        vector<vector<int>> routes;
        vector<double> lengths;

        for (int ant = 0; ant < numCities; ++ant) {
            vector<int> route;
            vector<bool> visited(numCities, false);

            int currentCity = ant;
            route.push_back(currentCity);
            visited[currentCity] = true;

            for (int step = 1; step < numCities; ++step) {
                vector<double> probabilities(numCities, 0.0);
                double total = 0.0;

                for (int nextCity = 0; nextCity < numCities; ++nextCity) {
                    if (!visited[nextCity]) {
                        probabilities[nextCity] = pow(pheromones[currentCity][nextCity], alpha) *
                            pow(Q / distances[currentCity][nextCity], beta);
                        total += probabilities[nextCity];
                    }
                }

                double threshold = static_cast<double>(rand()) / RAND_MAX * total;
                double cumulative = 0.0;

                for (int nextCity = 0; nextCity < numCities; ++nextCity) {
                    cumulative += probabilities[nextCity];
                    if (cumulative >= threshold) {
                        route.push_back(nextCity);
                        visited[nextCity] = true;
                        currentCity = nextCity;
                        break;
                    }
                }
            }

            routes.push_back(route);
            lengths.push_back(calculateRouteLength(route, distances));

            if (lengths.back() < bestLength) {
                bestLength = lengths.back();
                bestRoute = route;
            }
        }

        updatePheromones(pheromones, distances, routes, lengths);

        cout << "Итерация " << iter + 1 << ": лучший маршрут [";
        for (size_t i = 0; i < bestRoute.size(); ++i) {
            cout << bestRoute[i] << (i == bestRoute.size() - 1? "" : " -> ");
        }
        cout << "] длина: " << bestLength << "\n";
    }

    return 0;
}