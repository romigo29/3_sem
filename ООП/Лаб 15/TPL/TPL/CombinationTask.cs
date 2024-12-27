using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
	static public class CombinationTask
	{

		static public int Square(int a) => a * a;
		static public int Mul(int a, int b) => a * b;

		static public int Difference(int a, int b) => a - b;
		static public void Showcase()
		{
			Console.Write("Введите значние a: ");
			int a = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите значние b: ");
			int b = Convert.ToInt32(Console.ReadLine());

			var task1 = Task.Run(() => Square(a));
			var task2 = Task.Run(() => Mul(a, b));
			var task3 = Task.Run(() => Difference(a, b));

			Task task4 = Task.Run(() => Console.WriteLine($"Результат возведения в квадрат: {task1.Result}" +
				$"\nРезультат произведения: {task2.Result}" +
				$"\nРезультат разности: {task3.Result}"));


		}
	}
}
