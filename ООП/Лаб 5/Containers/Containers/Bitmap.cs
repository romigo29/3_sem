using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class Bitmap : Rectangle
	{

		public enum FileFormat { JPEG, PNG, GIF, BMP }

		public FileFormat ImageFormat { get; set; }


		//FileFormat { JPEG, PNG, GIF, BMP }
		public Bitmap(FileFormat format, int height, int width, int x, int y) : base(height, width, x, y)
		{
			ImageFormat = format;
		}

		public override string ToString()
		{
			return $"Bitmap ({GetType()}): формат файла - {ImageFormat}, кординаты - ({Coords.X}, {Coords.Y}), параметры - ({Height}, {Width})\n";
		}

	}
}
