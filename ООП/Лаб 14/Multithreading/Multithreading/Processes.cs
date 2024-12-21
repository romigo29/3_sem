using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
	static public class Processes
	{
		public static void ShowcaseProcesses()
		{
			var allProcesses = Process.GetProcesses();
			try
			{
				foreach (var process in allProcesses)
				{

					Console.WriteLine($"ID: {process.Id}");
					Console.WriteLine($"Имя: {process.ProcessName}");
					Console.WriteLine($"Приоритет: {process.BasePriority}");
					Console.WriteLine($"Текущее состояние: {process.Responding}");
					Console.WriteLine($"Время запуска: {process.StartTime}");
					Console.WriteLine($"Время Использования: {process.TotalProcessorTime}");
				}
			}

			catch
			{

			}
		}
	}
}
