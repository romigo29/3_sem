using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using System.Text;

namespace Example
{
	class DataTypes
	{
		static void Main()
		{

			NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
			{
				NumberDecimalSeparator = ".",
			};

			/*Console.Write("Введите булевую переменную: ");
			bool boolVar = Convert.ToBoolean(Console.ReadLine());
			Console.WriteLine(boolVar);

			Console.Write("Введите byte переменную: ");
			byte byteVar = Convert.ToByte(Console.ReadLine());
			Console.WriteLine(byteVar);

			Console.Write("Введите sbyte переменную: ");
			sbyte sbyteVar = Convert.ToSByte(Console.ReadLine());
			Console.WriteLine(sbyteVar);

			Console.Write("Введите символьную переменную: ");
			char charVar = Convert.ToChar(Console.ReadLine());
			Console.WriteLine(charVar);

			Console.Write("Введите десятичную переменную: ");
			decimal decimalVar = Convert.ToDecimal(Console.ReadLine());
			Console.WriteLine(decimalVar);

			Console.Write("Введите double переменную: ");
			double doubleVar = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine(doubleVar);

			Console.Write("Введите float переменную: ");
			float floatVar = Convert.ToSingle(Console.ReadLine());
			Console.WriteLine(floatVar);

			Console.Write("Введите int переменную: ");
			int intVar = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(intVar);

			Console.Write("Введите uint переменную: ");
			uint uintVar = Convert.ToUInt32(Console.ReadLine());
			Console.WriteLine(uintVar);

			Console.Write("Введите long переменную: ");
			long longVar = Convert.ToInt64(Console.ReadLine());
			Console.WriteLine(longVar);

			Console.Write("Введите строковую переменную: ");
			string strVar = Console.ReadLine();
			Console.WriteLine(strVar);

			Console.Write("Введите unsigned long переменную: ");
			ulong ulongVar = Convert.ToUInt64(Console.ReadLine());
			Console.WriteLine(ulongVar);

			Console.Write("Введите short переменную: ");
			short shortVar = Convert.ToInt16(Console.ReadLine());
			Console.WriteLine(shortVar);

			Console.Write("Введите ushort переменную: ");
			ushort ushortVar = Convert.ToUInt16(Console.ReadLine());
			Console.WriteLine(ushortVar);*/

			int myInt = 300;
			byte intToByte = (byte)myInt;

			double myDouble = 9.78;
			int doubleToInt = (int)myDouble;

			long myLong = 1000L;
			int longToInt = (int)myLong;

			float myFloat = 5.99f;
			int floatToInt = (int)myFloat;

			object myObject = "Hello";
			string objectToString = (string)myObject;

			int myInt2 = 100;
			long intToLong = myInt2;

			char myChar = 'A';
			int charToInt = myChar;

			float myFloat2 = 3.14f;
			double floatToDouble2 = myFloat2;

			byte myByte = 25;
			int byteToInt = myByte;

			ushort myUShort = 500;
			int ushortToInt = myUShort;

			object objInt = myInt;
			int unboxObj = (int)objInt;

			var varInt = 13;
			//varInt = Convert.ToString(varInt);

			int? nullInt = 14;

			string hello1 = "Hello";
			string BSTU = "BSTU";
			string quote = "per aspera ad astra";
			Console.WriteLine($"Сравнение Hello и BSTU: {hello1.CompareTo(BSTU)}");

			Console.WriteLine($"Сцепление: {hello1 + BSTU}");

			string hello2 = string.Copy(hello1);
			Console.WriteLine($"Копия строки: {hello2}");

			string quoteWord = quote.Substring(4, 6);
			Console.WriteLine($"Подстрока: {quoteWord}");

			string[] splittedQuote = quote.Split(' ');
			Console.WriteLine("Слова:");
			foreach (var word in splittedQuote)
			{
				Console.WriteLine(word);
			}

			string insertedQuote = quote.Insert(3, "_");
			Console.WriteLine($"После вставки: {insertedQuote}");

			string removedQuote = insertedQuote.Remove(3, 1);
			Console.WriteLine($"После удаления: {removedQuote}");

			Console.WriteLine($"Строка: {hello1}, {BSTU}!");

			string emptyString = "";
			string nullString = null;
			Console.WriteLine($"emptyString empty or null?: {string.IsNullOrEmpty(emptyString)}");
			Console.WriteLine($"nullString empty or null?: {string.IsNullOrEmpty(nullString)}");

			Console.WriteLine(nullString ?? "banana");

			StringBuilder sb = new StringBuilder("коит - лучший питомец");
				sb.Remove(2, 1); 
				sb.Insert(0, "Мой "); 
				sb.Append(" в мире");
				Console.WriteLine(sb);


			dynamic dynamicVar = 12;
			dynamicVar = "hello";


		/*int[,] twodArray = new int[2, 3];

		Random ran = new Random();

		for (int i = 0; i < twodArray.GetLength(0); i++)
		{
			for (int j = 0; j < twodArray.GetLength(1); j++)
			{
				twodArray[i, j] = ran.Next(1, 10);
				Console.Write("{0} ", twodArray[i, j]);
			}
			Console.WriteLine();
		}


		string[] Fruits = { "Яблоко", "Банан", "Слива", "Алыча", "Персик", "Груша" };
		Console.Write("Массив фруктов: ");
		foreach(var fruit in Fruits)
		{
			Console.Write($"{fruit} ");
		}

		int fruitLength = Fruits.Length;
		Console.WriteLine($"\nДлина массива фруктов: {fruitLength}");

		Console.WriteLine("Введите новое значение для массива фруктов: ");
		string newValue = Console.ReadLine();

		Console.WriteLine("Введите позицию нового значения для массива фруктов: ");
		int newPosition = Convert.ToInt32(Console.ReadLine());

		if (newPosition >= 0 && newPosition <= fruitLength)
		{
			Fruits[newPosition] = newValue;
			foreach (var fruit in Fruits)
			{
				Console.Write($"{fruit} ");
			}
		}

		else
		{
			Console.WriteLine("Позиция выходит за диапазон массива");
		}*/

		/*double[][] jaggedArray = new double[3][];
		jaggedArray[0] = new double[2];
		jaggedArray[1] = new double[3];
		jaggedArray[2] = new double[4];

		for (int i = 0; i < jaggedArray.Length; i++)
		{
			for (int j = 0; j < jaggedArray[i].Length; j++)
			{
				Console.Write($"Введите значение для элемента [{i}][{j}]: ");
				string tempVar = Console.ReadLine();
				jaggedArray[i][j] = Convert.ToDouble(tempVar, numberFormatInfo);
			}
		}

		Console.WriteLine("Получившийся ступенчатый массив:");
		for (int i = 0; i < jaggedArray.Length; i++)
		{
			for (int j = 0; j < jaggedArray[i].Length; j++)
			{
				Console.Write(jaggedArray[i][j] + " ");
			}
			Console.WriteLine();
		}

		var UntypedColors = new[] {"red", "yellow", "green"};

		var UntypedMessage = "Hello, BSTU!";*/

		/*var myTuple = (13, "coconut", 'c', "cherry", 100UL);
		var myTuple2 = (13, "coconut", 'c', "cherry", 100UL);

		Console.WriteLine(myTuple);

		Console.WriteLine($"1-ый элемент кортежа: {myTuple.Item1}");
		Console.WriteLine($"3-ий элемент кортежа: {myTuple.Item3}");
		Console.WriteLine($"4-ый элемент кортежа: {myTuple.Item4}");

		(int number, string coconut, char letter, string cherry, ulong ulnumber) = myTuple;
		Console.WriteLine("Полная распоковка кортежа:");
		Console.WriteLine(number);
		Console.WriteLine(coconut);
		Console.WriteLine(letter);
		Console.WriteLine(cherry);
		Console.WriteLine(ulnumber);

		Console.WriteLine("Распоковка кортежа с символом _: ");
		(_, string coconut2, char letter2, _, _) = myTuple;
		Console.WriteLine(coconut2);
		Console.WriteLine(letter2);

		Console.WriteLine("Частичная распаковка: ");

		var (_, _, _, cherry2, ulnumber2) = myTuple;
		Console.WriteLine(cherry2);
		Console.WriteLine(ulnumber2);

		Console.WriteLine(myTuple == myTuple2);*/



		/*int[] numbersArray = { 1, 2, 3, 4 };
		string myMessage = "Hello, BSTU!";

		(int maxValue, int minValue, int arraySum, char firstLetter) getTuple(int[] array, string message)
		{

			int maxValue = array.Max();
			int minValue = array.Min();
			int arraySum = array.Sum();
			char firstLetter = message[0];
			return (maxValue, minValue, arraySum, firstLetter);
		}

		Console.WriteLine(getTuple(numbersArray, myMessage));



		int maxInt = int.MaxValue;
		void controlOverflow()
		{
			try
			{
				checked
				{
					Console.WriteLine(++maxInt);
				}
			}

			catch (OverflowException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		void ignoreOverflow()
		{
			unchecked
			{
				Console.WriteLine(++maxInt);
			}
		}

		controlOverflow();
		ignoreOverflow();*/

	}
}
}