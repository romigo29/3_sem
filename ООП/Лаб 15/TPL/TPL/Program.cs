using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
	internal class Program
	{
		static void Main(string[] args)
		{

			try
			{
				/*//1
				PrimeNumbers.ShowCase();*/

				//2
				PrimeNumbersCancellation.ShowCase();

				/*//3
				CombinationTask.Showcase();*/

				/*//4
				ContinuationTask.ShowcaseWith();
				ContinuationTask.ShowcaseAwait();
				Task.Delay(1000).Wait();*/

				/*//5
				ParallelMethods.For();
				ParallelMethods.Foreach();*/

				/*//6
				ParallelMethods.ShowcaseInvoke();*/

				/*// 7
				Store.Showcase();*/

				/*//8
				AsyncMethods.Showcase();*/
			}

			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}
	}
}
