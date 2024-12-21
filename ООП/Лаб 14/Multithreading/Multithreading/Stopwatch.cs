using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
	static public class MyStopwatch
	{
		static public void Showcase()
		{
			int num = 0;
			TimerCallback tm = new TimerCallback(Count5sec);
			Timer timer = new Timer(tm, num, 5000, 5000);

			Console.ReadLine();

		}

		static public void Count5sec(object obj)
		{
			Console.WriteLine("Прошло пять секунд");
		}
	}
}
