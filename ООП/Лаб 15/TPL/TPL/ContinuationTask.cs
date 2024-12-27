using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	static public class ContinuationTask
	{
		static public int Square(int a) => a * a;
		static public int Mul(int a, int b) => a * b;
		static public int Difference(int a, int b) => a - b;
		static public void ShowcaseWith()
		{

			Task task1 = new Task(() => Console.WriteLine($"Id задачи: {Task.CurrentId}"));
			Task task2 = task1.ContinueWith(PrintTask);
			task1.Start();
			task2.Wait();
		}

		static public void ShowcaseAwait()
		{
			Task<int> task1 = Task.Run(() =>
			{
				Random random = new Random();
				return random.Next();
			});

			var awaiter = task1.GetAwaiter();
			awaiter.OnCompleted(() =>
			{
				int res = awaiter.GetResult();
				Console.WriteLine($"Случайно сгенерированное число: {res}");
			});
				
		}

		static void PrintTask(Task tprev)
		{
			Console.WriteLine($"Id задачи: {Task.CurrentId}");
			Console.WriteLine($"Id предыдущей задачи: {tprev.Id}");
			Thread.Sleep(1000);
		}
	}
}
