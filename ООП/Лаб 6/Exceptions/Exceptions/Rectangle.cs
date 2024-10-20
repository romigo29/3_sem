using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class Rectangle : Figure
	{
		public int Height { get; set; }
		public int Width { get; set; }

		public Rectangle(int x, int y, int height, int width) : base(x, y)
		{

			if (height <= 0 || width <= 0)
			{
				throw new InvalidArgumentException("Размеры прямоугольника должны быть положительны!");
			} 

			Height = height;
			Width = width;

		}

		public override void Resize(int height, int width)
		{

			if (height <= 0 || width <= 0)
			{
				throw new InvalidArgumentException("Размеры прямоугольника должны быть положительны!");
			}

			Height = height;
			Width = width;
		}

		public override string ToString()
		{
			return $"Rectangle ({GetType()}): кординаты - ({Coords.X}, {Coords.Y}); параметры - ({Height}, {Width})\n";
		}

	}
}
