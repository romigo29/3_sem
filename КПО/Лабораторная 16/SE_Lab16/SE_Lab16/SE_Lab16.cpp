#include "FST.h"

int _tmain(int argc, _TCHAR* argv[]) {

	setlocale(LC_ALL, "rus");

	const char* chain_arrays[SIZE]{
	"pqlqe",
	"pqqtcqe",
	"pqtcqe",
	"pqtsqqe",
	"pqtccqe",
	"pqtssqqe",
	"pqqtcqe",
	"pqqtcqa",
	"apqqtcqe"

	};

	for (int i = 0; i < SIZE; i++) {
		FST::executeProgram(chain_arrays[i]);
	}

	system("pause");
	return 0;
}
