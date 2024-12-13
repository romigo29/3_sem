using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
	[Serializable]
	public class Rectangle : Figure
	{
		public int Height { get; set; }
		public int Width { get; set; }

		public Rectangle() : base(0, 0)
		{
			Height = 1;
			Width = 1;
		}

		public Rectangle(int x, int y, int height, int width) : base(x, y)
		{

			Height = height;
			Width = width;

		}

		public override void Resize(int height, int width)
		{
			Height = height;
			Width = width;
		}

		public override string ToString()
		{
			return $"Rectangle ({GetType()}): кординаты - ({X}, {Y}); параметры - ({Height}, {Width})\n";
		}

	}
}
