using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			Figure figureRectangle = myRectangle as Figure;

			if (myRectangle is Figure) 
			{
				Console.WriteLine("Прямоугольник может быть переопределен");
				Console.WriteLine("Переопределяю...");
				myRectangle.Resize(7, 13);
				Console.WriteLine(myRectangle.ToString());

			}

			Circle myCircle = new Circle(5, 5, 4);
			Circle myCircle2 = new Circle(9, 9, 5);
			Console.WriteLine(myCircle.ToString());
			Console.WriteLine(myCircle2.ToString());

			if (myCircle2 is IResize)
			{
				Console.WriteLine("Круг может быть переопределен");
				Console.WriteLine("Переопределяю...");
				myCircle2.Resize(7, 13);
				Console.WriteLine(myCircle2.ToString());
			}


			Bitmap myBitmap = new Bitmap(Bitmap.FileFormat.GIF, 100, 100, 10, 10);

			PictureBox myPictureBox = new PictureBox("ColorfulBox", myBitmap);

			Window myWindow = new Window("ColorfulWindow");
			myWindow.Click();

			Console.WriteLine(myBitmap.ToString());
			Console.WriteLine(myPictureBox.ToString());
			Console.WriteLine(myWindow.ToString());

			myWindow.Close();

			Figure[] figures = new Figure[]
			{
				myRectangle,
				myRectangle2,
				myCircle,
				myCircle2,
				myBitmap
			};

			foreach (Figure f in figures)
			{
				Console.WriteLine(f.ToString());
			}

			IManageElement[] interfaces = new IManageElement[]
			{
				myWindow,
				myPictureBox
			};

			foreach (IManageElement iface in interfaces)
			{
				Console.WriteLine(iface.ToString());
			}

		}
	}
}
