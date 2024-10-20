using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public sealed class Circle : Figure
	{
		public double R { get; set; }

		public Circle(int x, int y,  int radius) : base(x, y)
		{

			if (radius <= 0)
			{
				throw new InvalidArgumentException("Радиус должнн быть должны быть положительным!");
			}

			R = radius;	
		}

		public override void Resize(int height, int width)
		{

			if (height <= 0 || width <= 0)
			{
				throw new InvalidArgumentException("Параметры должны быть положительны!");
			}

			R = (height + width) / 2;
		}

		public override string ToString()
		{
			return $"Circle ({GetType()}): кординаты - ({Coords.X}, {Coords.Y}), радиус - {R}\n";
		}
	}
}

