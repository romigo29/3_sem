using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
	public class StringHandler
	{

		public static string RemoveSeparators(string text)
		{
			const string Separators = ".,;:!?-()[]{}'\"/"; 
			string newText = "";
			foreach (char c in text)
			{
				if (!Separators.Contains(c))
					newText += c;
			}
			return newText;
		}

		public static string AddSymbols(string text)
		{
			return text += " :)";
		}

		public static string UpperSymbols(string text)
		{
			return text.ToUpper();
		}

		public static void CountSymbols(string text)
		{
			Console.WriteLine($"Текущий размер строки: {text.Length}");
		}

		public static string RemoveSpaces(string text)
		{
			return text.Replace(" ", "");
		}
	}
}
