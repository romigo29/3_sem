#include <iostream>
#include <string>
#include <vector>
using namespace std;
void getLIS(vector<int>, int);

static int checkData() {
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

void getLIS(vector<int>seq, int N) {

	vector<int> lengths(N, 1);
	vector<int> previous(N, -1);

	for (int i = 1; i < N; i++) {
		for (int j = 0; j < i; j++) {
			if (seq[j] < seq[i] && lengths[j] + 1 > lengths[i]) {
				lengths[i] = lengths[j] + 1;
				previous[i] = j;
			}
		}
	}

	int maxLength = 0, maxIndex = 0;
	for (int i = 0; i < N; i++) {
		if (lengths[i] > maxLength) {	
			maxLength = lengths[i];
			maxIndex = i;
		}
	}

	vector<int> path;
	while (maxIndex != -1) {
		path.push_back(seq[maxIndex]);
		maxIndex = previous[maxIndex];
	}

	reverse(path.begin(), path.end());

	cout << "\nДлина наибольшей возрастающей подпоследовательности: " << maxLength << endl;
	cout << "Наибольшая подпоследовательность: ";
	for (int n : path) {
		cout << n << " ";
	}
}
int main() {

	setlocale(LC_ALL, "rus");
	srand(time(0));
	int N;

	cout << "Введите натуральное число (количество чисел в последовательности): ";
	N = checkData();
	while (N <= 0) {
		cout << "Введено не натуральное число. Попробуйте еще раз: ";
		N = checkData();
	}

	vector<int> sequence;
	cout << "Введите последовательность чисел: ";
	int num;
	for (int i = 0; i < N; i++) {
		cin >> num;
		sequence.push_back(num);
	}

	cout << "Исходная последовательность: ";
	for (int n : sequence) {
		cout << n << " ";
	}

	cout << "\n------------------------------" << endl;
	getLIS(sequence, N);
	return 0;
}