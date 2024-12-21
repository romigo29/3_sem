using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
	static public class PrimeNumbers
	{
		static public void ShowProcess()
		{
			Thread TestThread = new Thread(PrintSimpleNumbers) { Name = "GetPrimeNumbers" };
			TestThread.Start();

			Thread StatusThread = new Thread(() =>
			{
				while (TestThread.IsAlive)
				{
					Console.WriteLine($"Имя потока: {TestThread.Name}");
					Console.WriteLine($"Приоритет потока: {TestThread.Priority}");
					Console.WriteLine($"Статус потока: {TestThread.ThreadState}");
					Console.WriteLine($"Числовой идентификатоп потока: {TestThread.ManagedThreadId}");
					Thread.Sleep(3000);
				}
				Console.WriteLine("Поток завершен.");
			});
			StatusThread.Start();


			void PrintSimpleNumbers()
			{
				Console.Write("Ввведите число n - диапазон вывода простых чисел (от 1 до n): \n");
				int n = Convert.ToInt32(Console.ReadLine());

				for (int i = 2; i < n; i++)
				{
					bool IsPrime = true;
					for (int j = 2; j < i; j++)
					{
						if (i % j == 0)
						{
							IsPrime = false;
							break;
						}
					}
					if (IsPrime)
					{
						Console.Write($"{i} ");

						Thread.Sleep(100);
					}
				}
			}
		}
	}
}
