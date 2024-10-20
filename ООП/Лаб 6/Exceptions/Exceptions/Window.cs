using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class Window : IManageElement
	{

		internal bool IsOpened {  get; set; }
		public string Title { get; set; }

		public Window(string title)
		{
			Title = title;
		}

		public void Click()
		{
			if (IsOpened)
			{
				throw new WindowException("Окно уже открыт. Его нельзя повторно открыть");
			}
			Console.WriteLine("Открываю окно...");
			IsOpened = true;
		}

		public void Close()
		{
			if (!IsOpened)
			{
				throw new WindowException("Окно уже закрыто. Его нельзя повторно закрыть");
			}
			Console.WriteLine("Закрываю окно...");
			IsOpened = false;
		}

		public override string ToString()
		{
			return $"Window ({GetType()}): имя - {Title}\n";
		}
	}
}
