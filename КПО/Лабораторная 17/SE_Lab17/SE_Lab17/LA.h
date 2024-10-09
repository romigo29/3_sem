#pragma once
#include<iostream>
#include<stack>
#include"stdafx.h"
#include"LA.h"
#include"IT.h"
#define MAX_LEX_SIZE 4096
#define FST_AMOUNT 9
#define MARK '\''
#define NEW_LINE '|'
#define SEMICOLON ';'
#define COMMA ','
#define LEFT_BRACE '{'
#define RIGHT_BRACE '}'
#define LEFTTHESIS '('
#define RIGHTTHESIS ')'
#define PLUS '+'
#define MINUS '-'
#define STAR '*'
#define EQUAL '='
#define DIRSLASH '/'


namespace LA
{

	struct FstLexeme {
		FST::FST& fst;
		int lexeme;
		bool* flag;
	};


	char FST(char* str);
	void LA(Parm::PARM parm, In::IN in);
}