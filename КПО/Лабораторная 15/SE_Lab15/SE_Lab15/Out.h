#pragma once
#include "stdafx.h"
#include "Out.h" 
#include "In.h" 
#include "Parm.h" 
#include "Error.h"

namespace Out     // Работа с выходным файлом
{
	struct OUT		// выходной файл
	{
		wchar_t outfile[PARM_MAX_SIZE]; // имя выходного файла 
		std::ofstream* stream;			// выходной поток выходного файла
	};

	static const OUT INITOUT{ L"", NULL }; // структура для начальной инициализации OUT
	OUT getout(wchar_t outfile[]); // сформировать структуру OUT
	void WriteOut(In::IN in, wchar_t out[]); // ввести в протокол out информацию об исходном файле
	void WriteError(OUT out, Error::ERROR error); // вывести в выходной файл информацию об ошибке 
	void CloseOut(OUT out); //закрытие выходоног файла
}