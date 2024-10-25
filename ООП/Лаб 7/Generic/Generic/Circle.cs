using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
	public sealed class Circle : Figure
	{
		public double R { get; set; }

		public Circle(int x, int y,  int radius) : base(x, y)
		{
			R = radius;	
		}

		public override void Resize(int height, int width)
		{
			R = (height + width) / 2;
		}

		public override string ToString()
		{
			return $"Circle ({GetType()}): кординаты - ({X}, {Y}), радиус - {R}\n";
		}
	}
}

