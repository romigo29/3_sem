#include "graphs.h"

void printMatrix(int M[SIZE][SIZE]) {

    for (int i = 0; i < SIZE; i++) {
        for (int j = 0; j < SIZE; j++) {
            cout << M[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}

void floydWarshall(int D[SIZE][SIZE], int S[SIZE][SIZE]) {

    for (int m = 0; m < SIZE; m++)
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (D[i][m] != INT_MAX && D[m][j] != INT_MAX && D[i][j] > D[i][m] + D[m][j])
                {
                    D[i][j] = D[i][m] + D[m][j];
                    S[i][j] = S[i][m];
                }
            }
        }
    }
}

int main(){

    setlocale(LC_ALL, "rus");
	floydWarshall(D, S);
    cout << "Матрица кратчайших путей:" << endl;
    printMatrix(D);
    cout << "Матрица последовательности вершин:" << endl;
    printMatrix(S);
	return 0;
}