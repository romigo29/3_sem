#pragma once
#include <iostream>
#include <tchar.h>
#define AMOUNT 7
#define SIZE 9
using namespace std;

namespace FST {

	struct RELATION {		// �����:������ -> ������� ����� ��������� �� 
		char symbol;			//������ �������� short nnode; 
		short nnode;			//����� ������� �������
		RELATION(
			char � = 0x00,		// ������ �������� 
			short ns = NULL		// ����� ���������
		);
	};

	struct NODE {				//������� ����� ���������
		short n_relation;		    // ���������� ������������ �����
		RELATION* relations;		// ����������� �����
		NODE();
		NODE(
			short n,				// ���������� ������������ �����
			RELATION rel, ...		//������ �����
		);
	};

	struct FST {		// ������������������ �������� �������
		const char* string;		// ������� (������, ���������� 0�00 )
		short position;		// ������� ������� � �������
		short nstates;		// ���������� ��������� ��������
		NODE* nodes;		// ���� ���������:  [0] -��������� ���������, [nstate-1] - ��������
		short* rstates;		// ��������� ��������� �������� �� ������ �������

		FST(
			char* s,		// �������(������, ���������� 0�00)
			short ns,		// ���������� ��������� ��������
			NODE n, ...		// ������ ���������(���� ���������)
		);

	};

	bool execute(		//��������� ������������� ������� 
			FST& fst		// ������������������ �������� �������
		);

	void executeProgram(const char* chain);
}

FST::FST createFST(const char* chain);	//�������� ����� ��������� ��������