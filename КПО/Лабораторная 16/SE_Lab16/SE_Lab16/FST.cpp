#include "FST.h"

FST::RELATION::RELATION(char c, short nn) {
	symbol = c;
	nnode = nn;
};

FST::NODE::NODE() {	// конструктор по умолчанию
	n_relation = 0;
	RELATION* relations = NULL;
};

FST::NODE::NODE(short n, RELATION rel, ...) {		//конструктор с параметрами
	n_relation = n;
	RELATION* p = &rel;
	relations = new RELATION[n];
	for (short i = 0; i < n; i++) {
		relations[i] = p[i];
	}
};

FST::FST::FST(char* s, short ns, NODE n, ...) {
	string = s;
	nstates = ns;
	nodes = new NODE[ns];
	NODE* p = &n;
	for (int k = 0; k < ns; k++) {
		nodes[k] = p[k];
	};
	rstates = new short[nstates];
	memset(rstates, 0xff, sizeof(short) * nstates);		//заполянем массив  -1
	rstates[0] = 0;
	position = -1;

};

bool step(FST::FST& fst, short*& rstates) {		//один шаг автомата

	bool rc = false;
	swap(rstates, fst.rstates);		//смена массивов
	for (short i = 0; i < fst.nstates; i++) {
		if (rstates[i] == fst.position) {
			for (short j = 0; j < fst.nodes[i].n_relation; j++) {
				if (fst.nodes[i].relations[j].symbol == fst.string[fst.position]) {
					fst.rstates[fst.nodes[i].relations[j].nnode] = fst.position + 1;
					rc = true;
				};
			};
		};
	};
	return rc;
};

FST::FST createFST(const char* chain) {
	return FST::FST(
		(char*)chain,
		AMOUNT,  // количество состояний
		/*S0*/ FST::NODE(1, FST::RELATION('p', 1)),
		/*S1*/ FST::NODE(1, FST::RELATION('q', 2)),
		/*S2*/ FST::NODE(3, FST::RELATION('q', 2), FST::RELATION('t', 3), FST::RELATION('l', 4)),
		/*S3*/ FST::NODE(3, FST::RELATION('t', 3), FST::RELATION('s', 4), FST::RELATION('c', 4)),
		/*S4*/ FST::NODE(3, FST::RELATION('s', 4), FST::RELATION('c', 4), FST::RELATION('q', 5)),
		/*S5*/ FST::NODE(2, FST::RELATION('q', 5), FST::RELATION('e', 6)),
		/*S6*/ FST::NODE()  // конечное состояние
	);
}

bool FST::execute(FST& fst) {		//выполнить распознавание цепочки
	short* rstates = new short[fst.nstates];
	memset(rstates, 0xff, sizeof(short) * fst.nstates);  //выделяем место для состояний
	short lstring = strlen(fst.string);		//длина цепочки
	bool rc = true;		//распознана ли цепочка?
	for (short i = 0; i < lstring && rc; i++) {
		fst.position++;				//продвинули позиции
		rc = step(fst, rstates);	//один шаг автомата
	};

	delete[] rstates;
	return (rc ? (fst.rstates[fst.nstates - 1] == lstring) : rc);
};

void FST::executeProgram(const char* chain) {
	FST fst = createFST(chain);	//создаем граф конечного автомата

	if (execute(fst)) {	//выполнить разбор
		cout << "Цепочка " << fst.string << " распознана" << endl;
	}
	else {
		cout << "Цепочка " << fst.string << " не распознана" << endl;
	}
}