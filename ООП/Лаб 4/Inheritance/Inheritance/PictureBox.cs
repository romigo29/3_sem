using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class PictureBox : Window, IResize
	{
		public Bitmap Image { get; set; }

		public PictureBox(string title, Bitmap image) : base(title)
		{
			Image = image;
		}

		public void Resize(int height, int width)
		{
			Console.WriteLine($"Переопределение размера коробки к длине {height} и ширине {width}");
		}
		public override string ToString()
		{
			return $"PictureBox ({GetType()}): имя - {Title}; изображение {Image}";
		}
	}
}
