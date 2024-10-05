#include "FST.h"

FST::RELATION::RELATION(char c, short nn) {
	symbol = c;
	nnode = nn;
};

FST::NODE::NODE() {	// ����������� �� ���������
	n_relation = 0;
	RELATION* relations = NULL;
};

FST::NODE::NODE(short n, RELATION rel, ...) {		//����������� � �����������
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
	memset(rstates, 0xff, sizeof(short) * nstates);		//��������� ������  -1
	rstates[0] = 0;
	position = -1;

};

bool step(FST::FST& fst, short*& rstates) {		//���� ��� ��������

	bool rc = false;
	swap(rstates, fst.rstates);		//����� ��������
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
		AMOUNT,  // ���������� ���������
		/*S0*/ FST::NODE(1, FST::RELATION('p', 1)),
		/*S1*/ FST::NODE(1, FST::RELATION('q', 2)),
		/*S2*/ FST::NODE(3, FST::RELATION('q', 2), FST::RELATION('t', 3), FST::RELATION('l', 4)),
		/*S3*/ FST::NODE(3, FST::RELATION('t', 3), FST::RELATION('s', 4), FST::RELATION('c', 4)),
		/*S4*/ FST::NODE(3, FST::RELATION('s', 4), FST::RELATION('c', 4), FST::RELATION('q', 5)),
		/*S5*/ FST::NODE(2, FST::RELATION('q', 5), FST::RELATION('e', 6)),
		/*S6*/ FST::NODE()  // �������� ���������
	);
}

bool FST::execute(FST& fst) {		//��������� ������������� �������
	short* rstates = new short[fst.nstates];
	memset(rstates, 0xff, sizeof(short) * fst.nstates);  //�������� ����� ��� ���������
	short lstring = strlen(fst.string);		//����� �������
	bool rc = true;		//���������� �� �������?
	for (short i = 0; i < lstring && rc; i++) {
		fst.position++;				//���������� �������
		rc = step(fst, rstates);	//���� ��� ��������
	};

	delete[] rstates;
	return (rc ? (fst.rstates[fst.nstates - 1] == lstring) : rc);
};

void FST::executeProgram(const char* chain) {
	FST fst = createFST(chain);	//������� ���� ��������� ��������

	if (execute(fst)) {	//��������� ������
		cout << "������� " << fst.string << " ����������" << endl;
	}
	else {
		cout << "������� " << fst.string << " �� ����������" << endl;
	}
}