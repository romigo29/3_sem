#include <iostream>
#include <locale>
#include "stdafx.h"
#include "Error.h"   // обработка ошибок
#include "Parm.h"    // обработка параметров
#include "Log.h"     // работа с протоколами
#include "In.h"      // ввод исходного файла
#include "Out.h"

int _tmain(int argc, _TCHAR* argv[]) {
    setlocale(LC_ALL, "rus");
    /*
    cout << "---- тест Error:geterror  ----" << endl;
    try {
      throw ERROR_THROW(101);
    }
    catch (Error::ERROR e) {
      cout << "Ошибка " << e.id << ": " << e.message << endl << endl;
    };



    cout << "---- тест Error::geterroin ---" << endl << endl;
    try {
      throw ERROR_THROW_IN(111, 7, 7);
    }
    catch (Error::ERROR e) {
      cout << "Ошибка " << e.id << ": " << e.message
        << ", строка " << e.inext.line
        << ",позиция " << e.inext.col << endl << endl;
    };


    cout << "---- тест Parm::getparm ---" << endl << endl;
    try {
      Parm::PARM parm = Parm::getparm(argc, argv);
      wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << endl << endl;
    }
    catch (Error::ERROR e) {
      cout << "Ошибка " << e.id << ": " << e.message << endl << endl;
    };
    */
    cout << "---- тест In::getin ---" << endl << endl;
    try {
        Parm::PARM parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);
        cout << in.text << endl;
        cout << "Всего символов: " << in.size << endl;
        cout << "Всего строк: " << in.lines << endl;
        cout << "Пропущено: " << in.ignor << endl;
    }
    catch (Error::ERROR e) {
        cout << "Ошибка " << e.id << ": " << e.message << endl << endl;
        cout << "строка " << e.inext.line << " позиция " << e.inext.col << endl << endl;
    };

    Log::LOG log = Log::INITLOG;
    Parm::PARM parm = Parm::getparm(argc, argv);
    Out::OUT out = Out::INITOUT;
    In::IN in = In::getin(parm.in);

    try {
        out = Out::getout(parm.out);

        Out::WriteOut(in, parm.out);
        Out::CloseOut(out);
    }
    catch (Error::ERROR e) {
        Out::WriteError(out, e);
    };

    try {

        log = Log::getlog(parm.log);
        Log::WriteLine(log, (char*)"Тeст:", (char*)" без ошибок \n", "");
        Log::WriteLine(log, (wchar_t*)L"Тест:", (wchar_t*)L" 6eз oши6oк \n", "");
        Log::WriteLog(log);
        Log::WriteParm(log, parm);
        In::IN in = In::getin(parm.in);
        Log::WriteIn(log, in);
        Log::Close(log);

    }
    catch (Error::ERROR e) {
        Log::WriteError(log, e);
    };

    delete[] in.text;
    delete[] in.forbiddenChar;
    delete[] in.errorLine;
    delete[] in.errorCol;
    system("pause");
    return 0;
}
