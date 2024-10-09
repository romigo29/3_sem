#pragma once
#define IN_MAX_LEN_TEXT 1024*1024
#define IN_CODE_ENDL '\n'
#define SPACE 32
#define BUFF_SIZE 1000

#define IN_CODE_TABLE_2 {\
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, '|', IN::F, IN::F, IN::I, IN::F, IN::F, /*15*/ \
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*31*/ \
    /*пробелы*/IN::P, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, /*47*/ \
    /*48 - 0*/IN::T, IN::T,/*50 - 2*/ IN::T, IN::T, IN::T,/*53 - 5*/ IN::T, /*54 - 6*/IN::T, IN::T, IN::T, IN::T, IN::S, IN::S, IN::S, IN::S, IN::S, IN::S, /*63*/ \
    IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*73 - I*/IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*79*/ \
    IN::T, IN::T, /*82 - R*/IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*X*/ IN::T, IN::T, IN::T, IN::S, IN::S, IN::S, IN::S, IN::S,  /*95*/ \
    IN::S, /*97 - a*/IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,/*103 - g*/ IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*109 - m*/IN::T, /*110 - n*/IN::T, /*111 - o*/IN::T, /*111*/\
    IN::T, IN::T, /*114 - r*/ IN::T, IN::T, IN::T, IN::T, /*v - 118*/IN::T, IN::T, IN::T, IN::T, IN::T, IN::S, IN::S, IN::S, IN::S, IN::F, /*127*/\
                                                          \
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*143*/\
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*159*/\
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*175*/\
    IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, /*191*/\
    IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*200 - И*/IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*207*/\
    /*208 - Р*/IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*223*/\
    /*224 - а*/IN::T, IN::T, /*226 - в*/IN::T, /*227 - г*/IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*236 - м*/ IN::T, /*237 - н*/IN::T, /*238 - о*/ IN::T, IN::T, /*239*/\
    /*240 - р*/IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, /*252 - ь */IN::T, IN::T, IN::T, IN::T /*255*/\
      }

namespace In
{
    struct IN
    {
        enum { P = 256, S = 512, T = 1024, F = 2048, I = 4096};
        int size = 0;
        int lines = 0;
        int ignore = 0;
        unsigned char* text;
        int code[256] = IN_CODE_TABLE_2;
        int error_size = 0;                 //количество запрещенной символов
        unsigned char* forbiddenChar;   //хранение запрещенных символов
        int* errorLine;                 //номера строк с запрещенными символами
        int* errorCol;                  //позиции запрещенных символов
    };
    IN getin(wchar_t infile[]);
};
