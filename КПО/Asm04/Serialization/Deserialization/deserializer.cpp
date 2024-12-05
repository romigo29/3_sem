#include "deserializer.h"

void Deserializer::DeserializeData()
{

	ifstream ifile = ifstream("D:\\BSTU\\3 �������\\���\\Asm04\\Serialization\\Serialization\\serialization.bin");

	if (ifile.is_open()) {

		uint8_t dataType;
		uint32_t dataLength;

		while (!ifile.eof()) {

			ifile.read(reinterpret_cast<char*>(&dataType), sizeof(dataType));
			ifile.read(reinterpret_cast<char*>(&dataLength), sizeof(dataLength));

			switch (dataType) {

			case TYPE_INT:
				ifile.read(reinterpret_cast<char*>(&intVal), dataLength);
				break;

			case TYPE_UINT:

				ifile.read(reinterpret_cast<char*>(&uintLit), dataLength);
				break;

			default:
				cout << "����������� ��� ������" << endl;
				break;
			}
		}

		ifile.close();

		cout << "��������� ��������������: " << "\nInt ����������: " << intVal << "\t" << "\nUnsigned int �������: " << uintLit << endl;

	}

	else {
		cout << "�� ������� ������� ���� ��� ������!";
	}
}

void Deserializer::ConvertToAssembler()
{

	ofstream ofile = ofstream("D:\\BSTU\\3 �������\\���\\Asm04\\Serialization\\asm04\\asm04.asm");

	if (ofile.is_open()) {

		ofile ASM_HEAD;
		
		ofile << "INT_VAL \t SDWORD " << intVal << endl;
		ofile << "UINT_LIT \t DWORD " << uintLit << endl;

		ofile ASM_FOOTER;

		ofile.close();
	}

	else {
		cout << "�� ������� ������� ���� ��� ������!";
	}
}

