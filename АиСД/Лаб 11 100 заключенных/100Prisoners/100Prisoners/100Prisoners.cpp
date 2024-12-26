#include <iostream>
#include <vector>
#include <algorithm>
#include <ctime>

using namespace std;

#define MAX_BOXES 100
#define MAX_ATTEMPTS 50

bool RandomCase(vector<int> box) {

    for (int prisoner = 0; prisoner < MAX_BOXES; prisoner++ ) {
        bool isFound = false;
        for (int attempt = 0; attempt < MAX_ATTEMPTS; attempt++) {
            int randomBox = rand() % MAX_BOXES;

            if (box[randomBox] == prisoner) {
                isFound = true;
                break;
            }
        }

        if (!isFound) {
            return false;
        }

    }
    return true;
}

bool AlgorithmCase(vector<int> box) {

    for (int prisoner = 0; prisoner < MAX_BOXES; prisoner++) {
        bool isFound = false;
        int nextBox = box[prisoner];
        for (int attempt = 0; attempt < MAX_ATTEMPTS; attempt++) {
           
            if (box[nextBox] == prisoner) {
                isFound = true;
                break;
            }
            
            nextBox = box[nextBox];

        }

        if (!isFound) {
            return false;
        }

    }
    return true;
}

int main()
{
    srand(time(0));
    setlocale(LC_ALL, "rus");
    int N = 0;
    int nRandom = 0;
    int nAlgorithm = 0;

    vector<int> box;

    for (int i = 0; i < MAX_BOXES; i++) {
        box.push_back(i);
    }

    cout << "Введите количество раундов сравнений N:";
    cin >> N;

    for (int i = 0; i < N; i++) {

        random_shuffle(box.begin(), box.end());

        if (RandomCase(box)) {
            nRandom++;
        }

        if (AlgorithmCase(box)) {
            nAlgorithm++;
        }
    }

    cout << "\nКоличество успешных исходов случайным образом: " << nRandom << endl;
    cout << "Количество успешных исходов через алгоритм: " << nAlgorithm;
}