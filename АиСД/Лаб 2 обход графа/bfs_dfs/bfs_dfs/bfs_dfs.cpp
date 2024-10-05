#include "graphs.h"

int checkData() {
	int parm;
	cin >> parm;
	while (cin.fail()) {
		cout << "Введено не число. Попробуйте еще раз" << endl;
		//очистка консоли с ошибкой
		cin.clear();
		//игнориурем символы и переходим в конец потока
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
		cin >> parm;
	}
	return parm;
}

void BFS(int start) {
	vector<bool> visited(SIZE, false);
	queue<int> q;		

	visited[start-1] = true;
	q.push(start);	

	while (!q.empty()) {
		int v = q.front();	
		q.pop();		

		cout << "Посещаем вершину " << v << endl;

		for (int i = 0; i < SIZE; i++) {
			if (adjacency_matrix[v - 1][i] == 1 && !visited[i]) {
				q.push(i+1);	
				visited[i] = true;	
			}
		}
	}
}

void DFS(int start) {
	vector<bool> visited(SIZE, false);
	stack<int> s;

	visited[start - 1] = true;
	s.push(start);  

	while (!s.empty()) {
		int v = s.top();
		s.pop();

		cout << "Посещаем вершину " << v << endl;

		for (int i = 0; i < SIZE; i++) {

			if (adjacency_matrix[v - 1][i] == 1 && !visited[i]) {
				s.push(i + 1);      
				visited[i] = true; 
			}
		}
	}
};

int main() {
	
	setlocale(LC_ALL, "rus");

	int start;
	cout << "Введите начальную вершину для обхода графа в ширину (число от 1 до 10): ";
	start = checkData();

	while (start < 1 || start > 10) {
		cout << "Число вышло из диапазона значений. Попробуйте еще раз" << endl;
		start = checkData();
	}

	cout << "BFS: " << endl;
	BFS(start);

	cout << "\nВведите начальную вершину для обхода графа в глубину (число от 1 до 10): ";
	start = checkData();

	while (start < 1 || start > 10) {
		cout << "Число вышло из диапазона значений. Попробуйте еще раз" << endl;
		start = checkData();
	}


	cout << "\nDFS: " << endl;
	DFS(start);

	return 0;
}