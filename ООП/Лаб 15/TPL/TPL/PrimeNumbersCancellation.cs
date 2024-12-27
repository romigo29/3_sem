using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	static public class PrimeNumbersCancellation
	{
		static public void ShowCase()
		{
			Stopwatch stopwatch = new Stopwatch();
			CancellationTokenSource tokenSource = new CancellationTokenSource();
			CancellationToken token = tokenSource.Token;
			Task task = new Task(() => EratosthenesSieve(token), token);

			stopwatch.Start();
			task.Start();

			Thread.Sleep(2000);
			Console.WriteLine($"Статус задачи №{task.Id}: {task.Status}");
			tokenSource.Cancel();
			stopwatch.Stop();

			Console.WriteLine($"\nСтатус задачи №{task.Id}: {task.Status}");
			Console.WriteLine($"\nЗатраченное время: {stopwatch.ElapsedMilliseconds} милисекунд");
		}

		static public void EratosthenesSieve(CancellationToken token)
		{
			Console.Write("Введите число n (поиск простых чисел от 2 до n: ");
			int n = Convert.ToInt32(Console.ReadLine());
			List<int> sieve = new List<int>();

			for (int i = 2; i < n; i++)
			{
				sieve.Add(i);
			}

			bool Removed = false;
			for (int i = 0; i < sieve.Count; i++)
			{
				if (token.IsCancellationRequested)
				{
					Console.WriteLine("Выполнение задачи превысило лимит по времени");
					return;
				}
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
