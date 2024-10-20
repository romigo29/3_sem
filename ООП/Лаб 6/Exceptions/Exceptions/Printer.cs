using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class Printer
	{
		public void IAmPrinting(Figure figure)
		{
			if (figure == null)
			{
				throw new NullException("Невозможно вывести пустой объект");
			}

			Console.WriteLine(figure.ToString());
		}

		public void IAmPrinting(IManageElement manageable)
		{
			Console.WriteLine(manageable.ToString());
		}
	}
}
