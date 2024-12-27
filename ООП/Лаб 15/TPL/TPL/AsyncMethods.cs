using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	static public class AsyncMethods
	{
		static public void Showcase()
		{
			Console.WriteLine("Привет, БГТУ");
			Parrot().Wait();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Нечто промежуточное");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Конец");
			Thread.Sleep(2000);
		}

		static async Task Parrot()
		{
			Console.WriteLine("Life's good");
			int result = await Carrot();
			Console.WriteLine("result");
			Console.WriteLine(result);
		}

		static async Task<int> Carrot()
		{
			Console.WriteLine("Че за бред");
			await Task.Delay(1000);
			return 13;

		}
	}
}
