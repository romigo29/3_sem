#pragma once
#include <iostream>
#include <tchar.h>
#define AMOUNT 7
#define SIZE 9
using namespace std;

namespace FST {

	struct RELATION {		// ребро:символ -> вершина графа переходов КА 
		char symbol;			//символ перехода short nnode; 
		short nnode;			//номер смежной вершины
		RELATION(
			char с = 0x00,		// символ перехода 
			short ns = NULL		// новое состояние
		);
	};

	struct NODE {				//вершина графа переходов
		short n_relation;		    // количество инциндентных ребер
		RELATION* relations;		// инцидентные ребра
		NODE();
		NODE(
			short n,				// количество инциндентных ребер
			RELATION rel, ...		//список ребер
		);
	};

	struct FST {		// недетерминировнный конечный автомат
		const char* string;		// цепочка (строка, завершатся 0х00 )
		short position;		// текуцая позиция в цепочке
		short nstates;		// количество состояний автомата
		NODE* nodes;		// граф переходов:  [0] -начальное состояние, [nstate-1] - конечное
		short* rstates;		// возможные состояния автомата на данной позиции

		FST(
			char* s,		// цепочка(строка, завершатся 0х00)
			short ns,		// количество состояний автомата
			NODE n, ...		// список состояний(граф переходов)
		);

	};

	bool execute(		//выполнить распознавание цепочки 
			FST& fst		// недетерминировнный конечный автомат
		);

	void executeProgram(const char* chain);
}

FST::FST createFST(const char* chain);	//создание графа конечного автомата