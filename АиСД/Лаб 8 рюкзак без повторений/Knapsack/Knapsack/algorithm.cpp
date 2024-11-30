#include <iostream>
#include <Windows.h>
using namespace std;

void main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    int N, n;
    cout << "������� ��������������� �������: "; cin >> N;
    cout << "������� ���������� ���������: "; cin >> n;

    string* name = new string[n];
    int* cost = new int[n];
    int* weight = new int[n];

    for (int i = 0; i < n; i++) {
        cout << "\n������� �������� " << i + 1 << " ��������: "; cin >> name[i];
        cout << "������� ��������� " << i + 1 << " ��������: "; cin >> cost[i];
        cout << "������� ��� " << i + 1 << " ��������: "; cin >> weight[i];
    }

    int** A = new int* [n + 1];
    for (int i = 0; i < n + 1; i++) {
        A[i] = new int[N + 1];
    }

    for (int i = 0; i < n + 1; i++) {
        for (int j = 0; j < N + 1; j++) {
            A[i][j] = 0;
        }
    }

    for (int i = 1; i < n + 1; i++) {
        for (int j = 1; j < N + 1; j++) {
            if (j < weight[i - 1]) {
                A[i][j] = A[i - 1][j];
                cout << A[i][j] << "\t";
            }
            else {
                A[i][j] = max(A[i - 1][j], A[i - 1][j - weight[i - 1]] + cost[i - 1]);
                cout << A[i][j] << "\t";
            }
        }
        cout << "\n";
    }

    cout << "\n������������ ��������� ���������, ���������� � ������: " << A[n][N];
    cout << "\n��������, ���������� � ������: "; 

    int i = n, j = N;
    while (i > 0 && j > 0) {
        if (A[i][j] != A[i - 1][j]) {
            cout << name[i - 1] << " ";
            j -= weight[i - 1];
        }
        i--;
    }

    cout << endl;
    for (int i = 0; i < n + 1; i++) {
        delete[] A[i];
    }
    delete[] A;
    delete[] name;
    delete[] cost;
    delete[] weight;
}
