using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
	public abstract class Figure : IResize
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Figure(int x, int y)
		{
			X = x;
			Y = y;
		}

		public abstract void Resize(int height, int width);

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode() 
		{ 
			return base.GetHashCode(); 
		}

		public override string ToString()
		{
			return base.ToString();	
		}

	}
}
