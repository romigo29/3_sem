using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
	static public class Domains
	{

		static public void ShowcaseDomains()
		{
			AppDomain CurrentDomain = AppDomain.CurrentDomain;
			Console.WriteLine($"Имя домена: {CurrentDomain.FriendlyName}");
			Console.WriteLine($"Базовый каталог: ${CurrentDomain.BaseDirectory}");
			Console.WriteLine($"Детали конфигурации: ${CurrentDomain.SetupInformation}");
			Console.WriteLine($"Все сборки, загруженные в домен: ");
			foreach (var assembly in CurrentDomain.GetAssemblies())
			{
				Console.WriteLine($"\t{assembly.FullName}");
			}

			AppDomain NewDomain = AppDomain.CreateDomain("TestDomain");
			Console.WriteLine($"Загрузка сборки в новый домен {NewDomain.FriendlyName}");
			NewDomain.Load(Assembly.GetExecutingAssembly().FullName);
			Console.WriteLine($"Выгрузка сборки {NewDomain.BaseDirectory}");
			AppDomain.Unload(NewDomain);
		}
	}
}
