using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
	static public class ParallelMethods
	{
		static public void For()
		{
			const int Size = 1_000_000;
			double[] numbers = new double[Size];
			double[] squares = new double[Size];

			Random random = new Random();

			for (int i = 0; i < Size; i++)
			{
				numbers[i] = random.Next(1, 101);
			}

			Stopwatch stopwatch = Stopwatch.StartNew();
			for (int i = 0; i < Size; i++)
			{
				squares[i] = Math.Pow(numbers[i], 2);
			}
			stopwatch.Stop();

			Console.WriteLine($"Время работы заполнения массивов через обычный цикл: {stopwatch.ElapsedMilliseconds} миллисекунд");

			stopwatch.Restart();
			System.Threading.Tasks.Parallel.For(0, Size, i =>
			{
				squares[i] = Math.Pow(numbers[i], 2);
			});
			stopwatch.Stop();
			Console.WriteLine($"Время работы заполнения массива через распаллелирование: {stopwatch.ElapsedMilliseconds} миллисекунд");
		}

		static public void Foreach()
		{
			const int Size = 1_000_000;
			List<string> cities = new List<string>();
			List<string> toUpperCities = new List<string>();	

			for (int i = 0; i < Size; i++)
			{
				cities.Add($"Город{i}");
			}

			Stopwatch stopwatch = Stopwatch.StartNew();
			foreach(string city in cities)
			{
				toUpperCities.Add(city.ToUpper());
			}
			stopwatch.Stop();
			Console.WriteLine($"Результат обработки городов через foreach: {stopwatch.ElapsedMilliseconds} милисекунд");

			toUpperCities.Clear();

			stopwatch.Restart();
			System.Threading.Tasks.Parallel.ForEach(cities, city =>
			{
				string upperCity = city.ToUpper();
				toUpperCities.Add(upperCity);
			});
			stopwatch.Stop();
			Console.WriteLine($"Результат обработки городов через распаллелирование: {stopwatch.ElapsedMilliseconds} милисекунд");
		}

		static public void ShowcaseInvoke()
		{
			Console.Write("Введите значние a для обработки: ");
			int a = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите значние b для обработки: ");
			int b = Convert.ToInt32(Console.ReadLine());

			Parallel.Invoke(
			() => Console.WriteLine($"Квадрат числа {a}: {CombinationTask.Square(a)}"),
			() => Console.WriteLine($"Разница {a} и {b}: {CombinationTask.Difference(a, b)}"),
			() => Console.WriteLine($"Произведение {a} и {b}: {CombinationTask.Mul(a, b)}")
			);
		}
	}
}
