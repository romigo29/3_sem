#include "graph.h"

using namespace std;

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

void printSolution(int dist[], int origin)  
{
    char str[SIZE] = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
    cout << "���������� �� ������� " << str[origin] << ": \n";
    for (int i = 0; i < SIZE; i++)
    {
        if (dist[i] != INT_MAX) {
            cout << "�� ������� " << str[i] << " -- " << dist[i] << endl;
        }
        else {
            cout << "������� " << i << " �����������." << endl;
        }
    }
}

void dijkstra(int graph[SIZE][SIZE], int origin)
{
    int distances[SIZE];
    bool visited[SIZE];
    for (int i = 0; i < SIZE; i++)
    {
        distances[i] = INT_MAX;
        visited[i] = false;
    }

    distances[origin] = 0;

    for (int count = 0; count < SIZE - 1; count++)
    {
        int node = -1;
        int minDistance = INT_MAX;

        for (int i = 0; i < SIZE; i++) {
            if (!visited[i] && distances[i] < minDistance) {
                minDistance = distances[i];
                node = i;
            }
        }

        if (node == -1) {
            break;
        }

        visited[node] = true;

        for (int v = 0; v < SIZE; v++) {
            if (!visited[v] && graph[node][v] && distances[node] != INT_MAX && distances[node] + graph[node][v] < distances[v]) {
                distances[v] = distances[node] + graph[node][v];
            }
        }
    }
    printSolution(distances, origin);
}

int main()
{
    int node;
    setlocale(LC_ALL, "rus");
   
    do
    {
        cout << "������� ����� �������\n";
        cout << "A - 0, B - 1, C - 2, D - 3, E - 4, F - 5, G - 6, H - 7, I - 8" << endl;
        node = checkData();
    } while (node < 0 || node > 8);

    dijkstra(graph, node);
    return 0;
}
