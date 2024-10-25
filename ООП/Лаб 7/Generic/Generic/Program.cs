using System;
using System.IO;
using Newtonsoft.Json;

namespace Generic
{
	internal class Generic
	{
		static void Main()
		{
			try
			{ 
				CollectionType<Stack> StackCollection = new CollectionType<Stack>();
				CollectionType<string> StringCollection = new CollectionType<string>(2);
				CollectionType<Figure> FigureCollection = new CollectionType<Figure>(2);

				Stack myStack = new Stack();
				myStack = myStack * 10;
				myStack = myStack * 7;
				Stack myStack2 = new Stack();
				myStack = myStack * 13;
				myStack = myStack * 2;
				myStack = myStack * 29;

				StackCollection.AddElement(myStack);
				StackCollection.AddElement(myStack2);
				StackCollection.ViewElements();

				StringCollection.AddElement("parrot");
				StringCollection.AddElement("tea");
				StringCollection.ViewElements();

				Figure MyRectangle = new Rectangle(10, 10, 100, 100);
				Figure MyCircle = new Circle(10, 10, 10);
				FigureCollection.AddElement(MyRectangle);
				FigureCollection.AddElement(MyCircle);
				FigureCollection.ViewElements();

				StackCollection.WriteToFile(ref StackCollection);
				StackCollection.ReadFromFile();


			}

			catch (Exception ex) 
			{ 
				Console.WriteLine($"Ошибка выполнения программы: {ex.Message}");
				Console.WriteLine($"Место ошибки: {ex.StackTrace}");
			}

			finally
			{
				Console.WriteLine("Окончание программы");
			}
		}
	}
}
