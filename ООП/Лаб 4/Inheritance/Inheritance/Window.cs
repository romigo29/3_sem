using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class Window : IManageElement
	{

		public string Title { get; set; }

		public Window(string title)
		{
			Title = title;
		}

		public void Click()
		{
			Console.WriteLine("Открываю окно...");
		}

		public void Close()
		{
			Console.WriteLine("Закрываю окно...");
		}

		public override string ToString()
		{
			return $"Window ({GetType()}): имя - {Title}\n";
		}
	}
}
