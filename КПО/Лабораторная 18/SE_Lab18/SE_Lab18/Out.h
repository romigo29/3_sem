#pragma once
#include "stdafx.h"
#include "Out.h" 
#include "In.h" 
#include "Parm.h" 
#include "Error.h"

namespace Out     // ������ � �������� ������
{
	struct OUT		// �������� ����
	{
		wchar_t outfile[PARM_MAX_SIZE]; // ��� ��������� ����� 
		std::ofstream* stream;			// �������� ����� ��������� �����
	};

	static const OUT INITOUT{ L"", NULL }; // ��������� ��� ��������� ������������� OUT
	OUT getout(wchar_t outfile[]); // ������������ ��������� OUT
	void WriteOut(In::IN in, wchar_t out[]); // ������ � �������� out ���������� �� �������� �����
	void WriteError(OUT out, Error::ERROR error); // ������� � �������� ���� ���������� �� ������ 
	void CloseOut(OUT out); //�������� ��������� �����
}