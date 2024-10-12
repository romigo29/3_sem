using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{

	public struct Point
	{
		public int X { get; set; }
		public int Y { get; set; }


		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"Координаты точки: ({X}, {Y})";
		}
	}

	 public abstract partial class Figure : IResize, IComparable<Figure>
	{
		public Point Coords { get; set; }

		public Figure(int x, int y)
		{
			Coords = new Point(x, y);
		}

		public virtual void Resize(int height, int width)
		{
			Console.WriteLine("Переопределение размеров фигуры.");
		}

		public int CompareTo(Figure figure)
		{
			if (figure == null) return 1;

			if (this == null) return -1;

			return this.GetType().Name.CompareTo(figure.GetType().Name);
		}

	}
}
