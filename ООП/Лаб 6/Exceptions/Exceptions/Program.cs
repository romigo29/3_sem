using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace Inheritance
{
	
    internal class Program
	{
		static void Main()
		{

			Rectangle myRectangle = new Rectangle(1, 1, 50, 100);
			Rectangle myRectangle2 = new Rectangle(45, 45, 150, 200);
			Console.WriteLine(myRectangle.ToString());
			Console.WriteLine(myRectangle2.ToString());

			Circle myCircle = new Circle(5, 5, 4);
			Circle myCircle2 = new Circle(9, 9, 5);
			Console.WriteLine(myCircle.ToString());
			Console.WriteLine(myCircle2.ToString());

			Printer myPrinter = new Printer();

			try
			{
				try
				{
					Controller MyFigureContainer = new Controller(1);

					MyFigureContainer.AddFigure(myRectangle);

					Figure[] newFigures = new Figure[]
					{
					myRectangle2,
					myCircle
					};

					MyFigureContainer.SetFigures = newFigures;
				}

				catch (InvalidArgumentException)
				{
					throw;
				}

				catch (OutOfRangeException)
				{
					throw;
				}
			}

			catch (Exception ex)
			{
				Console.WriteLine($"Вызвано исключение: {ex.Message}");
				Console.WriteLine($"Место : {ex.StackTrace}");
				Console.WriteLine($"Причина: {ex.InnerException}");
			}


			finally
			{

				Console.WriteLine($"Исправление: измените размер объекта");
			}



			try
			{
				Rectangle myRectangle3 = new Rectangle(30, 30, 0, 0);
			}

			catch (InvalidArgumentException ex)
			{
				Console.WriteLine($"Вызвано исключение: {ex.Message}");
				Console.WriteLine($"Место : {ex.StackTrace}");
				Console.WriteLine($"Причина: {ex.InnerException}");
			}

			finally
			{
				Console.WriteLine("Исправьте значения width и height для прямоугольника");
			}

			try
			{
				Circle myCircle3 = new Circle(9, 9, 0);
			}

			catch (InvalidArgumentException ex)
			{
				Console.WriteLine($"Вызвано исключение: {ex.Message}");
				Console.WriteLine($"Место : {ex.StackTrace}");
				Console.WriteLine($"Причина: {ex.InnerException}"); ;
			}

			finally
			{
				Console.WriteLine("Исправьте значения radius для круга");
			}

			try
			{
				myPrinter.IAmPrinting(null as Figure);
			}

			catch (NullException ex)
			{
				Console.WriteLine($"Вызвано исключение: {ex.Message}");
				Console.WriteLine($"Место : {ex.StackTrace}");
				Console.WriteLine($"Причина: {ex.InnerException}");
			}

			finally
			{
				Console.WriteLine("Невозможна работа с пустым объектом");
			}


			try
			{
				Window MyWindow = new Window("Окошко");
				MyWindow.Close();
			}

			catch (WindowException ex)
			{
				Console.WriteLine($"Вызвано исключение: {ex.Message}");
				Console.WriteLine($"Место : {ex.StackTrace}");
				Console.WriteLine($"Причина: {ex.InnerException}");
			}

			Window MyWindow2 = new Window(null);

			Debug.Assert(MyWindow2.Title != null, "Имя окна не может быть пустым");

		}
	}
}
