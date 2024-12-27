using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	static public class PrimeNumbers
	{
		static public void ShowCase()
		{
			Stopwatch stopwatch = new Stopwatch();
			Task task = new Task(() => EratosthenesSieve());

			stopwatch.Start();
			task.Start();

			Console.WriteLine($"Статус задачи №{task.Id}: {task.Status}");
			task.Wait();
			stopwatch.Stop();
			Console.WriteLine($"\nСтатус задачи №{task.Id}: {task.Status}");
			Console.WriteLine($"\nЗатраченное время: {stopwatch.ElapsedMilliseconds} милисекунд");

		}

		static public void EratosthenesSieve()
		{
			Console.Write("Введите число n (поиск простых чисел от 2 до n: ");
			int n = Convert.ToInt32(Console.ReadLine());
			List<int> sieve = new List<int>();

			for (int i = 2; i < n; i++)
			{
				sieve.Add(i);
			}

			bool Removed = false;
			for (int i = 0;  i < sieve.Count; i++)
			{
				for (int j = 2; j < n; j++)
				{
					sieve.Remove(sieve[i] * j);
					Removed = true;
				}

				if (!Removed)
				{
					break;
				}
			}

			Console.Write("Простые числа из заданного диапазона: ");
			foreach (var element in sieve)
			{
				Console.Write($"{element} ");
				Thread.Sleep(200);
			}
		}
	}
}
