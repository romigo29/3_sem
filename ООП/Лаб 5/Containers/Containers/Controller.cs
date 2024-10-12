using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class Controller : Container
	{
		public Controller(int size) : base(size)  {}

		public int CountFigurues()
		{
			return Count;
		}

		public void SortByType()
		{
			Array.Sort(FigureContainer);

			FigureContainer = FilterNulls(FigureContainer);
		}

		public Figure FindRectangleByWith(int width) 
		{

			foreach(Figure figure in FigureContainer)
			{
				if (figure is Rectangle rectangle && rectangle.Width == width)
				{
					Console.WriteLine("Прямоугольник найден!: ");
					return rectangle;
				}
			}

			Console.WriteLine("Прямоугольник не найден!: ");
			return null;
		}

		private Figure[] FilterNulls(Figure[] FigureContainer)
		{
			Figure[] FilteredContainer = new Figure[FigureContainer.Length];

			int index = 0;
			foreach (var f in FigureContainer)
			{
				if (f != null)
				{
					FilteredContainer[index++] = f;
				}
			}

			return FilteredContainer;
		}

	}

}
