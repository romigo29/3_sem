#pragma once
#define IN_MAX_LEN_TEXT 1024*1024
#define IN_CODE_ENDL '\n'
#define SPACE 32

#define IN_CODE_TABLE_2 {\
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, '|', IN::F, IN::F, IN::I, IN::F, IN::F, /*15*/ \
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*31*/ \
    /*�������*/IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*47*/ \
    /*48 - 0*/IN::T, IN::F,/*50 - 2*/ IN::T, IN::F, IN::F,/*53 - 5*/ IN::T, /*54 - 6*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*63*/ \
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*73 - I*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*79*/ \
    IN::F, IN::F, /*82 - R*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::T, /*X*/ IN::I, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,  /*95*/ \
    IN::F, /*97 - a*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::F,/*103 - g*/ IN::T, IN::F, IN::F, IN::F, IN::F, IN::T, /*109 - m*/IN::T, /*110 - n*/IN::T, /*111 - o*/IN::T, /*111*/\
    IN::F, IN::F, /*114 - r*/ IN::T, IN::F, IN::F, IN::F, /*v - 118*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*127*/\
                                                          \
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*143*/\
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*159*/\
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*175*/\
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*191*/\
    '-', IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*200 - �*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*207*/\
    /*208 - �*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*223*/\
    /*224 - �*/IN::T, IN::F, /*226 - �*/IN::T, /*227 - �*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*236 - �*/ IN::T, /*237 - �*/IN::T, /*238 - �*/ IN::T, IN::F, /*239*/\
    /*240 - �*/IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*252 - � */IN::T, IN::F, IN::F, IN::F /*255*/\
      }

namespace In
{
    struct IN
    {
        enum { T = 1024, F = 2048, I = 4096 };
        int size;
        int lines;
        int ignor;
        unsigned char* text;
        int code[256] = IN_CODE_TABLE_2;
        int error_size;                 //���������� ����������� ��������
        unsigned char* forbiddenChar;   //�������� ����������� ��������
        int* errorLine;                 //������ ����� � ������������ ���������
        int* errorCol;                  //������� ����������� ��������
    };
    IN getin(wchar_t infile[]);
};
