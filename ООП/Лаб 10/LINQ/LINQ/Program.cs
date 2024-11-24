using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
	public class Program
	{
		public static void Main()
		{
			string[] Months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

			Console.Write("Введите число n - количесто букв в месяце: ");
			int n = Convert.ToInt32(Console.ReadLine());
			var MonthsSortedBySize = from m in Months
									 where m.Length == n
									 select m;

			Console.Write($"\nМесяцы с числом букв {n}: ");
			PrintCollection(MonthsSortedBySize);

			var OnlyWinterSummerMonths = from m in Months
										 where m.StartsWith('J') || m == "August" || m == "December" || m == "February"
										 select m;

			Console.Write("\nТолько зиминие и летние месяцы: ");
			PrintCollection(OnlyWinterSummerMonths);

			var AlphabetSortedMonths = from m in Months
									   orderby m.ToLower() 
									   select m;

			Console.Write("\nМесяцы в алфавитном порядке: ");
			PrintCollection(AlphabetSortedMonths);

			var MonthWithU = from m in Months
							 where m.ToLower().Contains('u') && m.Length >= 4
							 select m;

			Console.Write("\nМесяцы длиной не менее 4, содержащие не менее 4 символов: ");
			PrintCollection(MonthWithU);

			SeparateParts();

			Rectangle rectangle1 = Rectangle.CreateRectangle(2, 3, 2, 3, "rectangle");
			Rectangle rectangle2 = Rectangle.CreateRectangle(5, 4, 5, 4, "rectangle");
			Rectangle square1 = Rectangle.CreateRectangle(1, 1, 1, 1, "square");
			Rectangle square2 = Rectangle.CreateRectangle(2, 2, 2, 2, "square");
			Rectangle rhombus1 = Rectangle.CreateRectangle(3, 3, 3, 3, "rhombus");
			Rectangle rhombus2 = Rectangle.CreateRectangle(4, 4, 4, 4, "rhombus");
			Rectangle default1 = Rectangle.CreateRectangle(1, 3, 5, 7, "arbitrary");
			Rectangle default2 = Rectangle.CreateRectangle(2, 4, 6, 8, "arbitrary");
			Rectangle default3 = Rectangle.CreateRectangle(11, 9, 7, 5, "arbitrary");
			Rectangle default4 = Rectangle.CreateRectangle(10, 8, 6, 4, "arbitrary");

			List<Rectangle> rectangles = new List<Rectangle>
			{
				rectangle1, rectangle2, square1, square2, rhombus1, rhombus2, default1, default2, default3, default4
			};


			var DifferentRectanglesCount = rectangles
				.GroupBy(r => r.GetObjType())
				.Select(group => new {Type = group.Key, Count = group.Count() });

			Console.WriteLine("\nКоличество различных типов фигур в коллекции:");
			foreach (var group in DifferentRectanglesCount)
			{
				Console.WriteLine($"Тип: {group.Type}, Количество: {group.Count}");
			}


			var MinMaxRectanglesSquaresPerimeter = rectangles
				.GroupBy(r => r.GetObjType())
				.Select(group => new
				{
					Type = group.Key,
					MinPerimeterFig = group.Aggregate((min, next) => next.GetPerimeter() < min.GetPerimeter() ? next : min),
					MaxPerimeterFig = group.Aggregate((max, next) => next.GetPerimeter() > max.GetPerimeter() ? next : max),
					MinSquareFig = group.Aggregate((min, next) => next.GetSquare() < min.GetSquare() ? next : min),
					MaxSquareFig = group.Aggregate((max, next) => next.GetSquare() > max.GetSquare() ? next : max)
				});

			Console.WriteLine("\nМинимальные и максимальные периметры и площади: ");
			foreach (var group in MinMaxRectanglesSquaresPerimeter)
			{
				Console.WriteLine($"Тип: {group.Type}," +
				$" Минимальный периметр: {group.MinPerimeterFig.GetPerimeter()} " +
				$" Максимальный периметр: {group.MaxPerimeterFig.GetPerimeter()}," +
				$" Минимальная площадь: {group.MinSquareFig.GetSquare()}, " +
				$" Максимальная площадь: {group.MaxSquareFig.GetSquare()}");
			}


			Console.WriteLine("\nВведите x (Для сравнения со стороной квадрата):");
			int x = Convert.ToInt32(Console.ReadLine());

			var SquaresLessThanX = rectangles
				.Where(r => r.GetObjType() == "square" && r.GetSquareSideSize() < x)
				.ToArray();

			Console.WriteLine($"Квадраты со сторонами меньшими, чем заданнный x({x}):");
			foreach (var square in SquaresLessThanX)
			{
				Console.WriteLine(square);
			}


			var SortedPerimeterRectangleArray = rectangles
				.Where(r => r.GetObjType() == "rectangle")
				.OrderBy(r => r.GetPerimeter())
				.ToArray();

			Console.WriteLine($"\nУпорядоченный по периметру прямоугольников массив:");
			foreach (var rectangle in SortedPerimeterRectangleArray)
			{
				Console.WriteLine(rectangle);
				Console.WriteLine($"Периметр {rectangle.GetPerimeter()}");
			}

			SeparateParts();

			var MyQuery = rectangles
				.Where(r => r.GetSquare() <= 10 && r.GetObjType() != "arbitrary")
				.OrderBy(r => r.GetObjType())
				.GroupBy(r => r.GetObjType())
				.Select(group => new
				{
					Type = group.Key,
					MinPerimeterFig = group.Min(r => r.GetPerimeter()),
					MaxPerimeterFig = group.Max(r => r.GetPerimeter()),
					Total = group.Count()
				});

			Console.WriteLine($"\nРезультат пользовательского запроса: ");
			foreach(var group in  MyQuery)
			{
				Console.WriteLine($"Тип объекта: {group.Type}");
				Console.WriteLine($"Минимальный периметр: {group.MinPerimeterFig}");
				Console.WriteLine($"максимальный периметр: {group.MaxPerimeterFig}");
				Console.WriteLine($"Общее количество: {group.Total}");

			}

			SeparateParts();

			var GeneralInformation = DifferentRectanglesCount
				.Join(
					MinMaxRectanglesSquaresPerimeter,
					counter => counter.Type,
					parameteres => parameteres.Type,
					(counter, parameters) => new
					{
						counter.Type,
						Total = counter.Count,
						MinPerimeter = parameters.MinPerimeterFig,
						MaxPerimeter = parameters.MaxPerimeterFig,
						MinSquare = parameters.MinSquareFig,
						MaxSquare = parameters.MaxSquareFig,
					}
				);

			Console.WriteLine("\nОбщая информация о фигурах в коллекции: ");
			foreach (var group in GeneralInformation)
			{
				Console.WriteLine($"\nТип: {group.Type}");
				Console.WriteLine($"Количество: {group.Total}");
				Console.WriteLine($"Минимальный периметр: {group.MinPerimeter.GetPerimeter()}");
				Console.WriteLine($"Максимальный периметр: {group.MaxPerimeter.GetPerimeter()}");
				Console.WriteLine($"Максимальная площадь: {group.MinSquare.GetSquare()}");
				Console.WriteLine($"Максимальная площадь: {group.MaxSquare.GetSquare()}");
			}

		}

		public static void PrintCollection(IEnumerable array)
		{
			foreach (var element in array)
			{
				Console.Write($"{element} ");
			}
		}

		public static void SeparateParts()
		{
			Console.WriteLine("\n---------------------------------------------------------");
		}
	}
}