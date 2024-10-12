using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class Printer
	{
		public static void IAmPrinting(Figure figure)
		{
			Console.WriteLine(figure.ToString());
		}

		public static void IAmPrinting(IManageElement manageable)
		{
			Console.WriteLine(manageable.ToString());
		}
	}
}
