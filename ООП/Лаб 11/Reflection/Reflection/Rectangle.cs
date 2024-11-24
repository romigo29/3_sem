using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
	partial class Rectangle
	{
		private int height1, height2, width1, width2;
		static int objectAmount;
		private readonly string objType;
		private readonly Guid ID;

		static Rectangle()
		{
			objectAmount = 0;
		}

		public Rectangle()
		{
			objType = "square";
			height1 = height2 = width1 = width2 = 1;

			ID = Guid.NewGuid();
			objectAmount++;
		}
		private Rectangle(int height1, int height2, int width1, int width2, string objType)
		{
			this.height1 = height1;
			this.height2 = height2;
			this.width1 = width1;
			this.width2 = width2;
			this.objType = objType;

			ID = Guid.NewGuid();
			objectAmount++;
		}
		public Rectangle(string objType = "arbitrary", int height1 = 3, int height2 = 3, int width1 = 3, int width2 = 4)
		{
			this.objType = objType;
			this.height1 = height1;
			this.height2 = height2;
			this.width1 = width1;
			this.width2 = width2;

			ID = Guid.NewGuid();
			objectAmount++;
		}
		public static Rectangle CreateRectangle(int height1, int width1, int height2, int width2, string objType)
		{
			return new Rectangle(height1, height2, width1, width2, objType);
		}
		public double GetSquare()
		{
			switch (this.objType)
			{
				case "rectangle":
					return this.height1 * this.width1;

				case "square":
					return this.height1 * this.height1;

				case "rhombus":
					return (this.height1 * this.height1) / 2;

				default:
					double p = (this.height1 + this.width1 + this.height2 + this.width2) / 2;
					return Math.Sqrt((p - this.height1) * (p - this.width1) * (p - this.height2) * (p - this.width2));
			}
		}
		public int GetPerimeter()
		{
			return this.height1 + this.height2 + this.width1 + this.width2;
		}

		public string GetObjType()
		{
			return this.objType;
		}

		public int GetSquareSideSize()
		{
			return height1;
		}

		public static int GetAmount()
		{
			return objectAmount;
		}

		public static void OutputInfo(int n1, int n2, int n3, int n4)
		{
			Console.WriteLine($"Количество объектов, находящихся в классе: {objectAmount}");
			Console.WriteLine($"Количество прямоугольников: {n1}");
			Console.WriteLine($"Количество квадратов: {n2}");
			Console.WriteLine($"Количество ромбов: {n3}");
			Console.WriteLine($"Количество произвольных четырехугольников: {n4}");
		}

		public static void GetMaxMin(Rectangle[] rectangles, string type)
		{
			double minSquare = double.MaxValue; double maxSquare = double.MinValue;
			int minPerimeter = int.MaxValue; int maxPerimeter = int.MinValue;

			foreach (var obj in rectangles)
			{

				string objType = obj.objType;

				if (objType == type)
				{
					double square = obj.GetSquare();
					int perimeter = obj.GetPerimeter();

					if (square > maxSquare)
					{
						maxSquare = square;
					}

					if (square < minSquare)
					{
						minSquare = square;
					}

					if (perimeter < minPerimeter)
					{
						minPerimeter = perimeter;
					}

					if (perimeter > maxPerimeter)
					{
						maxPerimeter = perimeter;
					}
				}
			}

			if (maxSquare != double.MinValue && minSquare != double.MaxValue)
			{
				Console.WriteLine($"\nТип: {type}");
				Console.WriteLine($"Наибольшая площадь: {maxSquare}");
				Console.WriteLine($"Наименьшая площадь: {minSquare}");
				Console.WriteLine($"Наибольший периметр: {maxPerimeter}");
				Console.WriteLine($"Наименьший периметр: {minPerimeter}");
			}
		}

		public int SetHeight1
		{
			private set
			{
				if (value < 1)
				{
					Console.WriteLine("Число должно быть положительным");
				}
				else
				{
					height1 = value;
				}
			}

			get
			{
				return height1;
			}
		}

		public int SetHeight2
		{
			private set
			{
				if (value < 1)
				{
					Console.WriteLine("Число должно быть положительным");
				}
				else
				{
					height2 = value;
				}
			}

			get
			{
				return height2;
			}
		}

		public int SetWidth1
		{
			private set
			{
				if (value < 1)
				{
					Console.WriteLine("Число должно быть положительным");
				}
				else
				{
					width1 = value;
				}
			}

			get
			{
				return width1;
			}
		}

		public int SetWidth2
		{
			private set
			{
				if (value < 1)
				{
					Console.WriteLine("Число должно быть положительным");
				}
				else
				{
					width2 = value;
				}
			}

			get
			{
				return width2;
			}
		}
	}

	partial class Rectangle
	{
		public override bool Equals(object obj)
		{
			if (obj == null || this.GetType() != obj.GetType())
				return false;

			Rectangle other = (Rectangle)obj;

			return this.height1 == other.height1 &&
				   this.width1 == other.width1 &&
				   this.objType == other.objType;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + height1.GetHashCode();
			hash = hash * 31 + width1.GetHashCode();
			hash = hash * 31 + (objType != null ? objType.GetHashCode() : 0);
			return hash;
		}

		public override string ToString()
		{
			return $"Фигура: Height1 = {height1}, Width1 = {width1}, Type = {objType}";
		}
	}
}