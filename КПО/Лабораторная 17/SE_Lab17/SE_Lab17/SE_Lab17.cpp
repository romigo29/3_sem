#include "stdafx.h"
#include "Error.h"   // ��������� ������
#include "Parm.h"    // ��������� ����������
#include "Log.h"     // ������ � �����������
#include "In.h"      // ���� ��������� �����
#include "Out.h"

int _tmain(int argc, _TCHAR* argv[]) {
    setlocale(LC_ALL, "rus");

    try {
        Parm::PARM parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);
        cout << in.text << endl;
        cout << "����� ��������: " << in.size << endl;
        cout << "����� �����: " << in.lines << endl;
        cout << "���������: " << in.ignore << endl;
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
        log = Log::getlog(parm.log);

        Log::WriteLog(log);
        Log::WriteParm(log, parm);
        Out::WriteOut(in, parm.out);
        Log::WriteIn(log, in);
        Log::WriteForbidden(log, in);

        LA::LA(parm, in);
        Log::Close(log);
        Out::CloseOut(out);
    }
    catch (Error::ERROR e)
    {
        cout << "������" << e.id << ':' << e.message << endl << endl;
        if (e.inext.line)
            Log::WriteError(log, e);
        Out::WriteError(out, e);
        Log::Close(log);
        Out::CloseOut(out);
    }

    delete[] in.text;
    delete[] in.forbiddenChar;
    delete[] in.errorLine;
    delete[] in.errorCol;
    system("pause");
    return 0;
}
