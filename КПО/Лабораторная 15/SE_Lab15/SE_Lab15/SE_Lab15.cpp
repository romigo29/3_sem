#include <iostream>
#include <locale>
#include "stdafx.h"
#include "Error.h"   // ��������� ������
#include "Parm.h"    // ��������� ����������
#include "Log.h"     // ������ � �����������
#include "In.h"      // ���� ��������� �����
#include "Out.h"

int _tmain(int argc, _TCHAR* argv[]) {
    setlocale(LC_ALL, "rus");
    /*
    cout << "---- ���� Error:geterror  ----" << endl;
    try {
      throw ERROR_THROW(101);
    }
    catch (Error::ERROR e) {
      cout << "������ " << e.id << ": " << e.message << endl << endl;
    };



    cout << "---- ���� Error::geterroin ---" << endl << endl;
    try {
      throw ERROR_THROW_IN(111, 7, 7);
    }
    catch (Error::ERROR e) {
      cout << "������ " << e.id << ": " << e.message
        << ", ������ " << e.inext.line
        << ",������� " << e.inext.col << endl << endl;
    };


    cout << "---- ���� Parm::getparm ---" << endl << endl;
    try {
      Parm::PARM parm = Parm::getparm(argc, argv);
      wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << endl << endl;
    }
    catch (Error::ERROR e) {
      cout << "������ " << e.id << ": " << e.message << endl << endl;
    };
    */
    cout << "---- ���� In::getin ---" << endl << endl;
    try {
        Parm::PARM parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);
        cout << in.text << endl;
        cout << "����� ��������: " << in.size << endl;
        cout << "����� �����: " << in.lines << endl;
        cout << "���������: " << in.ignor << endl;
    }
    catch (Error::ERROR e) {
        cout << "������ " << e.id << ": " << e.message << endl << endl;
        cout << "������ " << e.inext.line << " ������� " << e.inext.col << endl << endl;
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
        Log::WriteLine(log, (char*)"�e��:", (char*)" ��� ������ \n", "");
        Log::WriteLine(log, (wchar_t*)L"����:", (wchar_t*)L" 6e� o��6o� \n", "");
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
