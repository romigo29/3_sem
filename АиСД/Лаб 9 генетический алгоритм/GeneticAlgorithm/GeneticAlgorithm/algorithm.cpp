#include <iostream>
#include <vector>
#include <algorithm>
#include <limits.h>
#include <Windows.h>
#include <time.h>
using namespace std;

#define START 0

int V = 5;
int child = 0;
int populationSize = 0;
int evoCount = 0;
double mutationChance = 0;

typedef vector<vector<int>> Matrix;

Matrix cities = {
	{ INT_MAX, 25, 40, 31, 27 },
	{ 5, INT_MAX, 17, 30, 25 },
	{ 19, 15, INT_MAX, 6, 1 },
	{ 9, 50, 24, INT_MAX, 6 },
	{ 22, 8, 7, 10, INT_MAX }
};

//Matrix cities = { 
//	{ INT_MAX, 25, 40, 31, 27, 10, 5, 9},
//	{ 5, INT_MAX, 17, 30, 25, 15, 20, 10},
//	{ 19, 15, INT_MAX, 6, 1, 20, 30, 25},
//	{ 9, 50, 24, INT_MAX, 6, 10, 5, 9 },
//	{ 22, 8, 7, 10, INT_MAX, 15, 20, 10 },
//	{ 10, 15, 20, 10, 15, INT_MAX, 17, 30 },
//	{ 5, 20, 30, 5, 20, 17, INT_MAX, 6 },
//	{ 9, 10, 25, 9, 10, 30, 6, INT_MAX }
//};

struct marshrut {
	string path;
	int length;
};

void addCity() {
	vector<int> newDistances(V, INT_MAX);
	vector<int> newDistances2(V, INT_MAX);

	for (int i = 0; i < V; ++i) {
		cout << "Расстояние к городу " << i + 1 << " : ";
		cin >> newDistances[i];
	}
	for (int i = 0; i < V; ++i) {
		cout << "Расстояние от города " << i + 1 << " : ";
		cin >> newDistances2[i];
	}
	for (int i = 0; i < V; ++i) {
		cities[i].push_back(newDistances2[i]);
	}

	newDistances.push_back(INT_MAX);
	cities.push_back(newDistances);
	V++;
}

void deleteCity(int cityIndex) {

	for (int i = 0; i < V; ++i) {
		cities[i].erase(cities[i].begin() + cityIndex);
	}
	cities.erase(cities.begin() + cityIndex);

	V--;
}

void print(Matrix matrix)
{
	for (auto i : matrix)
	{
		for (auto el : i)
		{
			if (el != INT_MAX)cout << el << "\t";
			else cout << "INF" << "\t";
		}
		cout << endl;
	}
}

int getRandomNumber(int start, int end)
{
	int r = end - start;
	int rnum = start + rand() % r;
	return rnum;
}

bool contains(string s, char ch)
{
	for (int i = 0; i < s.size(); i++) {
		if (s[i] == ch)
			return true;
	}
	return false;
}

bool lessthan(struct marshrut t1, struct marshrut t2)
{
	return t1.length < t2.length;
}

string createPath()
{
	string path = "0";
	while (true) {
		if (path.size() == V) {
			path += path[0];
			break;
		}
		int temp = getRandomNumber(1, V);
		if (!contains(path, (char)(temp + 48)))
			path += (char)(temp + 48);
	}
	return path;
}

int calculateLength(string path)
{
	int f = 0;
	for (int i = 0; i < path.size() - 1; i++) {
		if (cities[path[i] - 48][path[i + 1] - 48] == INT_MAX)
			return INT_MAX;
		f += cities[path[i] - 48][path[i + 1] - 48];
	}
	return f;
}

marshrut childGene(marshrut dad, marshrut mom)
{
	marshrut child;
	int barrier = getRandomNumber(1, V);
	child.path = dad.path.substr(0, barrier);
	string mom_path = mom.path.substr(barrier + 1);
	for (char ch : mom_path)
	{
		if (!contains(child.path, ch)) {
			child.path += ch;
		}
	}

	if (child.path.size() != V) {
		for (int i = barrier; i < dad.path.size(); i++) {
			if (!contains(child.path, dad.path[i])) {
				child.path += dad.path[i];
			}
		}
	}

	child.path += child.path[0];
	child.length = calculateLength(child.path);
	return child;
}

string mutatedGene(string path)
{
	while (true) {
		int r = getRandomNumber(1, V);
		int r1 = getRandomNumber(1, V);
		if (r1 != r) {
			char temp = path[r];
			path[r] = path[r1];
			path[r1] = temp;
			break;
		}
	}
	return path;
}

int main()
{
	setlocale(LC_ALL, "ru");
	srand(time(0));
	int input = 0;
	cout << "Начальная матрица городов: \n";
	print(cities);
	cout << endl;
	while (true) {

		cout << "1 - Редактировать города\n";
		cout << "2 - Запустить генетический алгоритм\n";
		cin >> input;
		switch (input) {
		case 1: {
			cout << "1 - добавить город\n";
			cout << "2 - убрать город\n";
			cin >> input;
			switch (input) {
			case 1: {

				addCity();
				cout << "\n новая матрица городов: \n";
				print(cities);
				break;
			}
			case 2: {
				std::cout << "\nномер удаляемого города (от 1 до " << V << "): \n";
				cin >> input;
				deleteCity(input - 1);
				cout << "\n новая матрица городов: \n";
				print(cities);
				break;
			}
			}
			break;
		}
		case 2: {
			cout << "Размер популяций: ";
			cin >> populationSize;
			cout << "Вероятность мутации(в процентах,разделение точкой): ";
			cin >> mutationChance;
			cout << "Количество скрещиваний в одной популяции: ";
			cin >> child;
			cout << "Количество эволюций: ";
			cin >> evoCount;

			int gen = 1;
			int mutated_counter = 0;
			vector<struct marshrut> population;
			struct marshrut temp;

			for (int i = 0; i < populationSize; i++) {
				temp.path = createPath();
				temp.length = calculateLength(temp.path);
				population.push_back(temp);
			}

			cout << "\nСтартовая популяция: " << endl;
			cout << "Путь популяции \t - длина пути\n";
			for (int i = 0; i < populationSize; i++)
				cout << population[i].path << "\t\t\t"
				<< population[i].length << endl;
			cout << "\n";


			sort(population.begin(), population.end(), lessthan);

			while (gen <= evoCount) {
				mutated_counter = 0;
				cout << endl << "Лучший путь: " << population[0].path;
				cout << " Его длина: " << population[0].length << "\n\n";

				vector<struct marshrut> new_population;

				for (int i = 0; i < child; i++) {

					struct marshrut p1 = population[i];

					while (true)
					{
						int dad_id = getRandomNumber(0, populationSize - 1);
						int mom_id = getRandomNumber(0, populationSize - 1);
						if (dad_id != mom_id)
						{
							marshrut new_marshrut = childGene(population[dad_id], population[mom_id]);
							new_population.push_back(new_marshrut);
							new_marshrut = childGene(population[mom_id], population[dad_id]);
							new_population.push_back(new_marshrut);
							break;
						}
					}
				}

				for (int i = 0; i < populationSize - 1; i++) {

					struct marshrut p1 = population[i];

					if (getRandomNumber(0, 100) < mutationChance) {
						mutated_counter++;
						while (true)
						{
							string new_path = mutatedGene(p1.path);
							struct marshrut new_marshrut;
							new_marshrut.path = new_path;
							new_marshrut.length = calculateLength(new_marshrut.path);

							if (new_marshrut.length <= population[i].length) {
								new_population.push_back(new_marshrut);
								break;
							}
							else {
								new_marshrut.length = INT_MAX;
								new_population.push_back(new_marshrut);
								break;
							}
						}
					}
				}

				for (int i = 0; i < child + mutated_counter; i++)
				{
					population.push_back(new_population[i]);
				}
				sort(population.begin(), population.end(), lessthan);

				for (int i = 0; i < child + mutated_counter; i++)
				{
					population.pop_back();
				}

				cout << "Поколение " << gen << " \n";
				cout << "Путь популяции \t - длина пути\n";

				for (int i = 0; i < populationSize; i++) {
					cout << population[i].path << "\t\t\t"
						<< population[i].length << endl;
				}
				gen++;
			}
			cout << "\n\nНаиболее оптимальный маршрут: ";
			cout << population[0].path;
			cout << "\n\n";
			return 0;
		}
		}
	}
}