#include"LA.h"
#include"stdafx.h"
#include"In.h"
#include"Error.h"
#include <stdio.h>
#include <string.h>
#include <iomanip>
#define FST_AMOUNT 9
#define ID_SIZE 5

namespace LA
{
    LT::LexTable __LexTable = LT::Create(LT_MAXSIZE - 1);  //������� ��� �������� ������
    IT::IdTable __IdTable = IT::Create(TI_MAXSIZE - 1);    //������� ��� �������� ���������������

    //��������� ��������� ���������
    bool stringFlag = false;
    bool parmFlag = false;
    bool functionFlag = false;
    bool mainFlag = false;
    bool declareFunctionflag = false;
    bool addedToITFlag = false; // ���� ���������� � ������� ���������������

    char* str = new char[MAX_LEX_SIZE];    //�������� ������� �������

    char FST()
    {
        FST_INT
            FST_STRING
            FST_FUNC
            FST_DECLARE
            FST_RETURN
            FST_MAIN
            FST_PRINT
            FST_LITERAL
            FST_IDENF

            FstLexeme lexemes[] = {
            {_int, LEX_INTEGER, nullptr},
            {_string, LEX_STRING, &stringFlag},
            {_function, LEX_FUNCTION, nullptr},
            {_declare, LEX_DECLARE, nullptr},
            {_return, LEX_RETURN, nullptr},
            {_main, LEX_MAIN, &mainFlag},
            {_print, LEX_PRINT, nullptr},
            {literal_int, LEX_LITERAL, nullptr},
            {idenf, LEX_ID, nullptr}
        };

        for (int i = 0; i < FST_AMOUNT; i++) {
            if (Execute(lexemes[i].fst)) {
                if (lexemes[i].flag) {
                    *lexemes[i].flag = true;
                }
                return lexemes[i].lexeme;
            }
        }

        return NULL;
    }


    void LA(Parm::PARM parm, In::IN in)
    {
        int indexIT;
        LT::Entry current_entry_LT;
        int bufferIndex = 0;
        current_entry_LT.sn = 0;
        current_entry_LT.idxTI = 0;
        current_entry_LT.lexema[0] = NULL;
        stack<IT::Entry*> scope;
        scope.push(NULL);
        int number_literal = 0;
        IT::Entry current_entry_IT;
        __LexTable.size = 0;
        int currentLine = 1;
        ofstream LT_file;
        ofstream IT_file;
        LT_file.open("LT.txt");
        IT_file.open("IT.txt");
        for (int i = 0; i < in.size; i++)
        {
            if ((in.code[(int)in.text[i]] == In::IN::T || in.text[i] == '\'') && in.code[(int)in.text[i]] != In::IN::P)
            {
                str[bufferIndex++] = in.text[i];
                if (bufferIndex >= MAX_LEX_SIZE)
                {
                    throw ERROR_THROW(119);
                }
            }
            else
            {
                str[bufferIndex] = '\0';
                current_entry_LT.lexema[0] = FST();
                switch (current_entry_LT.lexema[0])
                {
                case LEX_MAIN:
                    mainFlag = true;
                    current_entry_LT.idxTI = __IdTable.size;
                    memcpy(current_entry_IT.id, str, 5);
                    current_entry_IT.id[5] = '\0';
                    current_entry_IT.iddatatype = IT::INT;
                    current_entry_IT.value.vint = NULL;
                    current_entry_IT.idxfirstLE = currentLine;
                    current_entry_IT.scope = NULL;
                    indexIT = IT::search(__IdTable, current_entry_IT);
                    if (indexIT > 0)
                    {
                        throw ERROR_THROW(105);
                    }
                    if (indexIT == -1)
                    {
                        IT::Add(__IdTable, current_entry_IT);
                    }
                    break;
                case LEX_LITERAL:
                    current_entry_LT.idxTI = __IdTable.size;
                    sprintf_s(current_entry_IT.id, "L%d", number_literal);
                    current_entry_IT.iddatatype = IT::INT;
                    current_entry_IT.idtype = IT::L;
                    current_entry_IT.idxfirstLE = currentLine;
                    current_entry_IT.value.vint = atoi(str);
                    current_entry_IT.scope = scope.top();
                    current_entry_LT.idxTI = __IdTable.size; // ��������� ������� ��� �������
                    IT::Add(__IdTable, current_entry_IT);
                    number_literal++;
                    break;
                case LEX_ID:
                    // �������� ������� ���������
                    if (scope.empty())
                        current_entry_IT.scope = NULL; // ���� ���� ����, ������� ��������� ����� NULL
                    else
                        current_entry_IT.scope = scope.top(); // ��������� ������� ��������� ��� ������� �����


                    current_entry_LT.idxTI = __IdTable.size; // ��������� ������� ��� �������
                    memcpy(current_entry_IT.id, str, ID_SIZE); // ����������� �������������� � ������� ���������������
                    current_entry_IT.id[ID_SIZE] = '\0'; // ���������� ������ ��������������
                    current_entry_IT.iddatatype = IT::INT; // ��������� ���� ������ ��������������
                    current_entry_IT.value.vint = NULL; // �������� �� ����������������
                    current_entry_IT.idxfirstLE = currentLine; // ����� ������, ��� ��������� �������������
                    current_entry_IT.idtype = IT::V; // ��������� ���� �������������� ��� ����������

                    // ��������� ������, ���� ���������� ������� - ��� ����������
                    if (__LexTable.table[__LexTable.size - 2].lexema[0] == LEX_DECLARE)
                    {
                        // ���� ��������� ������� - ������ � ���������� ����
                        if (__LexTable.table[__LexTable.size - 1].lexema[0] == LEX_STRING && stringFlag)
                        {
                            current_entry_IT.iddatatype = IT::STR; // ��������� ���� ������ �������������� ��� ������
                            strcpy_s(current_entry_IT.value.vstr->str, ""); // ������������� ������
                            stringFlag = false; // ����� �����
                        }
                        indexIT = IT::search(__IdTable, current_entry_IT); // ����� �������������� � �������

                        if (indexIT != -1) // ���� ������������� ��� ����������
                        {
                            throw ERROR_THROW(105); // ������: ������������� ��� ����������
                        }
                        current_entry_LT.idxTI = __IdTable.size; // ��������� ������� ��� �������
                        IT::Add(__IdTable, current_entry_IT); // ���������� �������������� � �������
                        addedToITFlag = true; // ��������� ����� ����������
                    }

                    // ��������� ������, ���� ���������� ������� - ��� �������
                    if (__LexTable.table[__LexTable.size - 1].lexema[0] == LEX_FUNCTION)
                    {
                        current_entry_IT.idtype = IT::F; // ��������� ���� �������������� ��� �������
                        declareFunctionflag = true; // ��������� ����� ���������� �������
                        // ���� ���������� ������� - ������ � ���������� ����
                        if (__LexTable.table[__LexTable.size - 2].lexema[0] == LEX_STRING && stringFlag)
                        {
                            current_entry_IT.iddatatype = IT::STR; // ��������� ���� ������ �������������� ��� ������
                            strcpy_s(current_entry_IT.value.vstr->str, ""); // ������������� ������
                            stringFlag = false; // ����� �����
                        }
                        indexIT = IT::search(__IdTable, current_entry_IT); // ����� �������������� � �������
                        if (indexIT != -1) // ���� ������������� ��� ����������
                        {
                            throw ERROR_THROW(105); // ������: ������������� ��� ����������
                        }
                        current_entry_LT.idxTI = __IdTable.size; // ��������� ������� ��� �������
                        IT::Add(__IdTable, current_entry_IT); // ���������� �������������� � �������
                        addedToITFlag = true; // ��������� ����� ����������
                    }


                    // ��������, �������� �� ������� ������������� ���������� �������
                    if (__LexTable.table[__LexTable.size - 2].lexema[0] == LEX_LEFTTHESIS &&
                        __LexTable.table[__LexTable.size - 3].lexema[0] == LEX_ID &&
                        __LexTable.table[__LexTable.size - 3].idxTI == __IdTable.size - 1 &&
                        __IdTable.table[__IdTable.size - 1].idtype == IT::F) // ������� ������������� - �������� �������
                    {
                        current_entry_IT.idtype = IT::P; // ��������� ���� �������������� ��� ���������
                        // ���� ��������� ������� - ������ � ���������� ����
                        if (__LexTable.table[__LexTable.size - 1].lexema[0] == LEX_STRING && stringFlag)
                        {
                            current_entry_IT.iddatatype = IT::STR; // ��������� ���� ������ �������������� ��� ������
                            strcpy_s(current_entry_IT.value.vstr->str, ""); // ������������� ������
                            stringFlag = false; // ����� �����
                        }
                        indexIT = IT::search(__IdTable, current_entry_IT); // ����� �������������� � �������
                        if (indexIT != -1) // ���� ������������� ��� ����������
                        {
                            throw ERROR_THROW(105); // ������: ������������� ��� ����������
                        }
                        current_entry_LT.idxTI = __IdTable.size; // ��������� ������� ��� �������
                        IT::Add(__IdTable, current_entry_IT); // ���������� �������������� � �������
                        addedToITFlag = true; // ��������� ����� ����������
                    }

                    if (__LexTable.table[__LexTable.size - 2].lexema[0] == LEX_COMMA && __IdTable.table[__LexTable.table[__LexTable.size - 2].idxTI].idtype == IT::P)
                    {
                        current_entry_IT.idtype = IT::P; // ��������� ���� �������������� ��� ���������

                        if (__LexTable.table[__LexTable.size - 1].lexema[0] == LEX_STRING && stringFlag)
                        {
                            current_entry_IT.iddatatype = IT::STR; // ��������� ���� ������ �������������� ��� ������
                            strcpy_s(current_entry_IT.value.vstr->str, ""); // ������������� ������ ��������
                            stringFlag = false; // ����� ����� ��� ������
                        }

                        indexIT = IT::search(__IdTable, current_entry_IT); // ����� �������������� � �������

                        if (indexIT != -1) // ���� ������������� ��� ����������
                        {
                            throw ERROR_THROW(105); // ��������� ������: ������������� ��� ����������
                        }

                        IT::Add(__IdTable, current_entry_IT); // ���������� �������������� � �������
                        addedToITFlag = true; // ��������� �����, ��� ������������� ��� ��������
                    }

                    if (!addedToITFlag) // ���� ������������� �� ��� ��������
                    {
                        indexIT = IT::search(__IdTable, current_entry_IT); // ��������� ����� �������������� � �������

                        if (indexIT >= 0) // ���� ������������� ������
                        {

                            current_entry_LT.idxTI = indexIT; // ��������� ������� �������������� ��� �������
                        }
                    }

                    std::memset(current_entry_IT.id, NULL, ID_SIZE); // ��������� ��������������

                    current_entry_IT.iddatatype = IT::INT; // ��������� ���� ������ �������������� ��� ������ �����
                    current_entry_IT.value.vint = NULL; // ������������� �������� ��������������
                    addedToITFlag = false; // ����� ����� ����������

                    break; // ������� � ���������� ����
                }

                bufferIndex = 0;
                //memset(str, 0, bufferIndex + 1);    //������� �����
                delete[] str;
                str = new char[MAX_LEX_SIZE];

                }
                if (current_entry_LT.lexema[0] != NULL)    //���� ������� ������������
                {
                    current_entry_LT.sn = currentLine;    // ��������� �� � �������
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;    // �������� �������


                }
                switch (in.text[i])
                {
                case MARK:
                    if (str[0] == '\'' && bufferIndex != 1)
                    {
                        current_entry_LT.idxTI = __IdTable.size;
                        str[bufferIndex] = '\0';
                        current_entry_LT.lexema[0] = LEX_LITERAL;
                        number_literal++;
                        sprintf_s(current_entry_IT.id, "L%d", number_literal);
                        current_entry_IT.iddatatype = IT::STR;
                        current_entry_IT.idtype = IT::L;
                        current_entry_IT.idxfirstLE = currentLine;
                        for (int i = 0; i < strlen(str); i++)
                        {
                            current_entry_IT.value.vstr->str[i] = str[i];
                        }
                        current_entry_IT.value.vstr->str[strlen(str)] = '\0';
                        current_entry_IT.value.vstr->len = strlen(current_entry_IT.value.vstr->str);
                        current_entry_LT.sn = currentLine;
                        current_entry_IT.scope = scope.top();
                        LT::Add(__LexTable, current_entry_LT);
                        IT::Add(__IdTable, current_entry_IT);
                        current_entry_LT.lexema[0] = NULL;
                        break;
                    }
                    break;
                case NEW_LINE:
                    current_entry_LT.lexema[0] = '\n';
                    current_entry_LT.sn = currentLine;
                    currentLine++;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    break;
                case SEMICOLON:
                    current_entry_LT.lexema[0] = LEX_SEMICOLON;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    if (__LexTable.table[__LexTable.size - 1].lexema[0] == LEX_BRACELET)
                    {
                        scope.pop();
                        functionFlag = false;
                    }
                    break;
                case COMMA:
                    current_entry_LT.lexema[0] = LEX_COMMA;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    break;
                case LEFT_BRACE:
                    if (mainFlag)
                    {
                        scope.push(&__IdTable.table[__IdTable.size - 1]);
                    }
                    current_entry_LT.lexema[0] = LEX_LEFTBRACE;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    for (int j = __IdTable.size - 1; j >= 0; j--) // ������� ������� ��������������� � �����
                    {
                        if (__IdTable.table[j].idtype == IT::F) // ���� ������������� - �������
                        {
                            scope.push(&__IdTable.table[j]); // ���������� ������� � ������� ���������
                            break; // ����� �� �����
                        }
                    }
                    break;
                case RIGHT_BRACE:
                    current_entry_LT.lexema[0] = LEX_BRACELET;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    if (!scope.empty()) // ���� ���� ������� ��������� �� ����
                        scope.pop(); // �������� �������� �������� �� �����
                    break;
                case LEFTTHESIS:
                    current_entry_LT.lexema[0] = LEX_LEFTTHESIS;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    if (declareFunctionflag)
                    {
                        for (int j = __IdTable.size - 1; j >= 0; j--) // ������� ������� ��������������� � �����
                        {
                            if (__IdTable.table[j].idtype == IT::F) // ���� ������������� - �������
                            {
                                scope.push(&__IdTable.table[j]); // ���������� ������� � ������� ���������
                                break; // ����� �� �����
                            }
                        }
                    }


                    break;
                case RIGHTTHESIS:
                    current_entry_LT.lexema[0] = LEX_RIGHTTHESIS;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    parmFlag = false;
                    if (!scope.empty() && functionFlag)
                    {
                        scope.pop(); // �������� �������� �������� �� ����� ������� ���������
                        functionFlag = false;
                    }
                    break;
                case PLUS:
                    current_entry_LT.lexema[0] = LEX_PLUS;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    break;
                case MINUS:
                    current_entry_LT.lexema[0] = LEX_MINUS;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    break;
                case STAR:
                    current_entry_LT.lexema[0] = LEX_STAR;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    break;
                case DIRSLASH:
                    current_entry_LT.lexema[0] = LEX_DIRSLASH;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    break;
                case EQUAL:
                    current_entry_LT.lexema[0] = LEX_EQUAL;
                    current_entry_LT.sn = currentLine;
                    LT::Add(__LexTable, current_entry_LT);
                    current_entry_LT.lexema[0] = NULL;
                    break;
                }
    }
    currentLine = 1;
    LT_file << currentLine;
    LT_file << '\t';
    for (int i = 0; i < __LexTable.size; i++)
    {
        current_entry_LT = LT::GetEntry(__LexTable, i);
        if (currentLine != current_entry_LT.sn)
        {
            currentLine = current_entry_LT.sn;
            LT_file << currentLine;
            LT_file << '\t';
        }
        LT_file << current_entry_LT.lexema[0];
    }
    LT_file.close();
    IT_file << std::setw(5) << "id"
        << std::setw(10) << "datatype"
        << std::setw(10) << "idtype"
        << std::setw(10) << "Line"
        << std::setw(10) << "value"
        << std::setw(10) << "Scope" << std::endl;

    for (int i = 0; i < __IdTable.size; i++) {
        IT::Entry temp_entry = IT::GetEntry(__IdTable, i); // �������� ��������� ������
        IT_file << std::setw(5) << temp_entry.id;
        if (temp_entry.iddatatype == 1)
            IT_file << std::setw(10) << "INT";
        if (temp_entry.iddatatype == 2)
            IT_file << std::setw(10) << "STR";
        if (temp_entry.idtype == IT::V)
            IT_file << std::setw(10) << "V";
        if (temp_entry.idtype == IT::L)
            IT_file << std::setw(10) << "L";
        if (temp_entry.idtype == IT::F)
            IT_file << std::setw(10) << "F";
        if (temp_entry.idtype == IT::P)
            IT_file << std::setw(10) << "P";
        IT_file << std::setw(10) << temp_entry.idxfirstLE;

        if (temp_entry.iddatatype == IT::INT) {
            IT_file << std::setw(10) << temp_entry.value.vint;
        }
        if (temp_entry.iddatatype == IT::STR) {
            IT_file << std::setw(7);
            for (int j = 0; j < strlen(temp_entry.value.vstr->str); j++) {
                IT_file << temp_entry.value.vstr->str[j];
            }
            IT_file << std::setw(10);
        }
        IT_file << std::setw(10);
        if (temp_entry.scope != NULL) {
            for (int j = 0; j < strlen(temp_entry.scope->id); j++)
            {
                IT_file << temp_entry.scope->id[j];
            }
        }
        IT_file << std::endl;
    }
    IT_file.close();
  }
}
