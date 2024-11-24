using System;
using System.Drawing;
using System.Reflection;

namespace Reflection
{
	public class Program
	{
		
		static void Main()
		{
			try
			{
				Type myType = typeof(Reflection.Rectangle);
				/*Type myType = typeof(Reflection.Stack);*/
				Console.WriteLine($"Информация о классе записана в файл");
				Reflector.GetTypeInfo(myType, "System.Int32");

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
				Console.WriteLine($"Место: {ex.StackTrace}");
			}
		}
	}
}