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

			Task task = Task.Run(() => EratosthenesSieve(token), token);
			stopwatch.Start();
			task.Wait();

			Console.WriteLine($"Статус задачи №{task.Id}: {task.Status}");
			stopwatch.Stop();
		
			Console.WriteLine($"\nСтатус задачи №{task.Id}: {task.Status}");
			Console.WriteLine($"\nЗатраченное время: {stopwatch.ElapsedMilliseconds} милисекунд");
		}

		static public async Task EratosthenesSieve(CancellationToken token)
		{
			Console.Write("Введите число n (поиск простых чисел от 2 до n): ");
			var inputTask = Task.Run(Console.ReadLine);

			if (await Task.WhenAny(inputTask, Task.Delay(2000, token)) == inputTask)
			{
	
				int n = Convert.ToInt32(await inputTask);
				List<int> sieve = new List<int>();

				for (int i = 2; i < n; i++)
				{
					sieve.Add(i);
				}

				for (int i = 0; i < sieve.Count; i++)
				{
					if (token.IsCancellationRequested)
					{
						Console.WriteLine("\nОперация была остановлена.");
						return; 
					}

					for (int j = 2; j < n; j++)
					{
						sieve.Remove(sieve[i] * j);
					}
				}

				Console.Write("Простые числа из заданного диапазона: ");
				foreach (var element in sieve)
				{
					if (token.IsCancellationRequested)
					{
						Console.WriteLine("\nОперация была остановлена во время вывода результата.");
						return;
					}
					Console.Write($"{element} ");
					Thread.Sleep(200);
				}
			}
			else
			{
				Console.WriteLine("\nТаймаут ввода. Операция остановлена.");
			}
		}
	}
}
