#include "stdafx.h"
#include "In.h"
#include "Error.h"

namespace In {     // посимвольно вводит данные из файла, заданного параметром
    IN getin(wchar_t infile[]) {
        IN in; // структура in для заполнения
        in.size = 0;
        in.error_size = 0;
        in.lines = 0;
        in.ignor = 0;
        int cols = 1, error_pos = 0;
        in.text = new unsigned char[IN_MAX_LEN_TEXT];
        in.forbiddenChar = new unsigned char[IN_MAX_LEN_TEXT];
        in.errorLine = new int[IN_MAX_LEN_TEXT];
        in.errorCol = new int[IN_MAX_LEN_TEXT];

        ifstream fin(infile);

        if (!fin.is_open()) {   
            throw ERROR_THROW(110);
        }

        char* buff = new char[1000];  // Читаем строки длиной до 1000 символов

        while (fin.getline(buff, 1000))  // Чтение файла построчно
        {

            in.lines++;
            cols = 1;

            for (int position = 0; position < strlen(buff); position++)
            {
                switch (in.code[int((unsigned char)buff[position])])
                {
                case IN::T:
                    if (buff[position] == SPACE && position == 0)  // Пропуск пробелов в начале строки
                    {
                        while (buff[position] == ' ')
                        {
                            position++;
                            in.ignor++;
                        }
                    }
                    if (buff[position] == SPACE && buff[position + 1] == SPACE)  // Пропуск двойных пробелов
                    {
                        in.ignor++;
                        break;
                    }
                    if (buff[position] == SPACE && (buff[position + 1] == '{' || buff[position + 1] == '}' || buff[position + 1] == '(' || buff[position + 1] == ')' || buff[position + 1] == ';' ||
                        buff[position + 1] == '+' || buff[position + 1] == '-' || buff[position + 1] == '*' || buff[position + 1] == '/' || buff[position + 1] == '='))  // Пропуск пробела перед символами
                    {
                        in.ignor++;
                        break;
                    }
                    if (buff[position] == SPACE && (buff[position - 1] == '{' || buff[position - 1] == '}' || buff[position - 1] == '(' || buff[position - 1] == ')' || buff[position - 1] == ';' ||
                        buff[position - 1] == '+' || buff[position - 1] == '-' || buff[position - 1] == '*' || buff[position - 1] == '/' || buff[position - 1] == '=' || buff[position - 1] == ','))  // Пропуск пробела после символов
                    {
                        in.ignor++;
                        break;
                    }
                    if (position == strlen(buff) - 1 && buff[strlen(buff) - 1] == SPACE)  // Пропуск пробела в конце строки
                    {
                        in.ignor++;
                        break;
                    }
                    in.text[in.size++] = (unsigned)buff[position];  // Добавление символа в структуру
                    break;

                case in.I:  // Символ должен быть проигнорирован
                    in.ignor++;
                    break;

                case in.F:  // Символ запрещен
                    in.forbiddenChar[error_pos] = buff[position];
                    in.text[in.size++] = '^';   // Запрещенный символ помечается символом '^'
                    in.errorLine[error_pos] = in.lines;  // Строка ошибки
                    in.errorCol[error_pos++] = cols++;   // Позиция ошибки
                    in.error_size++;
                    break;

                default:  // Символ может быть заменен на другой символ
                    in.text[in.size++] = static_cast<unsigned char>(in.code[buff[position]]);
                    cols++;
                    break;
                }
            }

            in.text[in.size++] = '|';

        }

        in.text[in.size] = '\0';   // Устанавливаем нуль-символ в конец таблицы
        fin.close();           // Закрываем файл
        delete[] buff;
        return in;  // Возвращаем результат после обработки всех строк
    }
}
