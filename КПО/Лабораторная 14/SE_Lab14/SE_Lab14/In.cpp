#include "stdafx.h"
#include "In.h"
#include "Error.h"

namespace In {     //посимвольно вводит данные из файла, заданного параметром
    IN getin(wchar_t infile[]) {
        IN in; // структура in для заполнения
        in.size = 0;
        in.lines = 1;
        in.ignor = 0;
        in.text = new unsigned char[IN_MAX_LEN_TEXT];  // Выделение памяти для текста

        // Инициализация таблицы проверки
        int checkTable[256] = IN_CODE_TABLE_2;       //ТАБЛИЦА ПРОВЕРКИ
        for (int i = 0; i < 256; ++i) {
            in.code[i] = checkTable[i];
        }

        int cols = 1, pos = 0;
        ifstream fin(infile);

        if (!fin.is_open()) {   // если не удается открыть файл
            throw ERROR_THROW(110);
        }

        char ch;
        while (fin.get(ch)) {
            if (in.size >= IN_MAX_LEN_TEXT) {   // если размер структуры превысил максимальный размер
                break;
            }

            unsigned char ch_code = ch; // получаем код извлеченного символа

            switch (in.code[ch_code]) {
            case in.T:   // символ может быть введен
                in.text[pos++] = ch_code;
                in.size++;
                cols++;
                break;
            case in.I:  // символ должен быть проигнорирован
                in.ignor++;
                cols++;
                break;
            case in.F:  // символ запрещен
                delete[] in.text;  // освобождаем память перед бросанием исключения
                throw ERROR_THROW_IN(111, in.lines, cols);
                break;
            default:  // символ может быть заменен на другой символ
                in.text[pos++] = static_cast<unsigned char>(in.code[ch_code]);
                in.size++;
                cols++;
                break;
            }

            if (ch_code == IN_CODE_ENDL) {   //если символ - это перенос строки
                in.lines++;
                cols = 1;
            }
        }
        in.text[pos] = '\0';   //после проверки уставналиваем нуль-символ в конец таблицы
        fin.close();           //закрываем файл
        return in;
    }
}
