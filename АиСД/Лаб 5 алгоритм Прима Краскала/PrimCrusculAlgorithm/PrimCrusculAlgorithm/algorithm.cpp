#include "graph.h"

int checkData() {
    int parm;
    cin >> parm;
    while (cin.fail()) {
        cout << "������� �� �����. ���������� ��� ���" << endl;
        //������� ������� � �������
        cin.clear();
        //���������� ������� � ��������� � ����� ������
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cin >> parm;
    }

    return parm;
}


void Prim(int graph[SIZE][SIZE]) {

    int visited[SIZE];
    memset(visited, false, sizeof(visited));

    cout << "������� ��������� ������� (�� 1 �� 8): ";

    int startIndex = checkData() - 1;

    while (startIndex < 0 || startIndex >= 8) {

        cout << "����� ������� �� ��������� �������. ���������� ��� ���\n";
        startIndex = checkData() - 1;
    }
   
    visited[startIndex] = true;

    cout << "�������� �����:\n";
    cout << "�����" << "  " << "����������" << endl;

    for (int edgeCount = 0; edgeCount < SIZE - 1; edgeCount++) {
        int min = INT_MAX;
        int x = -1, y = -1;

        for (int i = 0; i < SIZE; i++) {
            if (visited[i]) {
                for (int j = 0; j < SIZE; j++) {
                    if (!visited[j] && graph[i][j] && graph[i][j] < min) {
                            min = graph[i][j];
                            x = i;
                            y = j;
                    }
                }
            }
        }

        if (x != -1 && y != -1) {
        cout << x + 1 << " - " << y + 1 << " :  \t" << graph[x][y];
        cout << endl;
        visited[y] = true;
        }
    }
}

void Cruscul(int graph[SIZE][SIZE])   {

    int visited[SIZE];
    for (int i = 0; i < SIZE; i++) {
        visited[i] = i;
    }

    cout << "\n�������� ��������: \n";
    cout << "�����" << "  " << "���������� \n";
    for (int edgeCount = 0; edgeCount < SIZE - 1; edgeCount++) {
        int min = INT_MAX;
        int x = -1, y = -1;

        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                if (graph[i][j] && graph[i][j] < min) {

                    int rootI = i;
                    while (visited[rootI] != rootI) {
                        rootI = visited[rootI];
                    }

                    int rootJ = j;
                    while (visited[rootJ] != rootJ) {
                        rootJ = visited[rootJ];
                    }

                    if (rootI != rootJ) {
                        min = graph[i][j];
                        x = i;
                        y = j;
                    }
                }
            }
        }

        if (x != -1 && y != -1) {

            int rootA = x;
            while (visited[rootA] != rootA) {
                rootA = visited[rootA];
            }

            int rootB = y;
            while (visited[rootB] != rootB) {
                rootB = visited[rootB];
            }

            cout << x + 1 << " - " << y + 1 << " : \t" << min << endl;
            visited[rootA] = rootB;
        }
    }
}


int main() {

    setlocale(LC_ALL, "rus");
	Prim(graph);
    Cruscul(graph);

	return 0;
}