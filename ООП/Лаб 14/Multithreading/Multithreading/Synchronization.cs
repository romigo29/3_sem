using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
	static public class Synchronization
	{

		static public void ChangedPriority()
		{

			Console.Write("Ввведите число n - диапазон вывода чисел (от 1 до n): \n");
			int n = Convert.ToInt32(Console.ReadLine());

			Thread First = new Thread(PrintEvenNumbers) {Name = "EvenNumbers", Priority = ThreadPriority.Highest};
			Thread Second = new Thread(PrintOddNumbers) {Name = "OddNumbers", Priority = ThreadPriority.Lowest};

			First.Start();
			Second.Start();

			void PrintEvenNumbers()
			{
				for (int i = 2; i < n; i++)
				{
					if (i % 2 == 0)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write($"{i} ");
						Thread.Sleep(300);
					}
				}
			}

			void PrintOddNumbers()
			{
				for (int i = 1; i < n; i++)
				{
					if (i % 2 != 0)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine(i);
						Thread.Sleep(500);
					}
				}
			}


		}

		static public void PrintEvenOdd()
		{
			Console.Write("Ввведите число n - диапазон вывода чисел (от 1 до n): \n");
			int n = Convert.ToInt32(Console.ReadLine());
			string objLocker = "abc";

			Thread First = new Thread(PrintEvenNumbers) { Name = "EvenNumbers"};
			Thread Second = new Thread(PrintOddNumbers) { Name = "OddNumbers"};

			First.Start();
			Second.Start();

			Console.ForegroundColor = ConsoleColor.White;

			void PrintEvenNumbers()
			{
				lock (objLocker) { 
					for (int i = 2; i < n; i++)
					{		
						if (i % 2 == 0)
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write($"{i} ");
							Thread.Sleep(300);
						}
					}
				}
			}

			void PrintOddNumbers()
			{
				lock (objLocker)
				{
					for (int i = 1; i < n; i++)
					{
						if (i % 2 != 0)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write($"{i} ");
							Thread.Sleep(500);
						}
					}
				}
			}
		}

		static public void PrintOneByOne()
		{
			Console.Write("Ввведите число n - диапазон вывода чисел (от 1 до n): \n");
			int n = Convert.ToInt32(Console.ReadLine());
			string objLocker = "abc";

			Thread First = new Thread(PrintEvenNumbers) { Name = "EvenNumbers" };
			Thread Second = new Thread(PrintOddNumbers) { Name = "OddNumbers" };

			First.Start();
			Second.Start();


			void PrintEvenNumbers()
			{
				for (int i = 2; i < n; i++)
				{
					lock (objLocker)
					{
						if (i % 2 == 0)
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write($"{i} ");
							Thread.Sleep(1000);
						}
					}
				}
			}

			void PrintOddNumbers()
			{
				for (int i = 1; i < n; i++)
				{
					lock (objLocker)
					{
						if (i % 2 != 0)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write($"{i} ");
							Thread.Sleep(500);
						}
					}
				}
			}
		}

		/*static public void PrintOneByOne()
		{
			Console.Write("Ввведите число n - диапазон вывода простых чисел (от 1 до n): \n");
			int n = Convert.ToInt32(Console.ReadLine());
			Barrier barrier = new Barrier(2);
			string objLocker = "abc";

			Thread First = new Thread(PrintEvenNumbers) { Name = "EvenNumbers" };
			Thread Second = new Thread(PrintOddNumbers) { Name = "OddNumbers" };

			First.Start();
			Second.Start();

			First.Join();
			Second.Join();

			void PrintEvenNumbers()
			{
				for (int i = 2; i < n; i++)
				{
					if (i % 2 == 0)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write($"{i} ");
						barrier.SignalAndWait();
						Thread.Sleep(1000);
						
					}
				}
			}

			void PrintOddNumbers()
			{
				for (int i = 1; i < n; i++)
				{
					if (i % 2 != 0)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write($"{i} ");
						barrier.SignalAndWait();
						Thread.Sleep(700);
					}
				}
			}
		}*/
	}
}
