using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
	public class Program
	{
		public static void Main() {

			try
			{
				Game Hero1 = new("Brian", 13);
				Game Hero2 = new("Igor", 100);

				Hero1.Attacked += (hero, damage) => Console.WriteLine($"Персонажу {hero} нанесен удар! -{damage} HP");
				Hero2.Attacked += (hero, damage) => Console.WriteLine($"Персонажу {hero} нанесен удар! -{damage} HP");

				Hero1.Healed += (hero, HP) => Console.WriteLine($"Персонаж {hero} вылечен! +{HP} HP");
				Hero2.Healed += (hero, HP) => Console.WriteLine($"Персонаж {hero} вылечен! +{HP} HP");

				Hero1.Remained += (hero) => Console.WriteLine($"С персонажем {hero} ничего не произошло.");
				Hero2.Remained += (hero) => Console.WriteLine($"С персонажем {hero} ничего не произошло.");

				Hero1.ShowHP();
				Hero1.AttackHero(Hero1.HeroesName, 1);
				Hero1.ShowHP();

				Hero1.HealHero(Hero1.HeroesName, 10);
				Hero1.ShowHP();

				Hero2.AttackHero(Hero2.HeroesName, 0);
				Hero2.ShowHP();

				string MyString = "Oh, what's a pity!";
				Console.WriteLine($"\nИсходная строка: {MyString}");

				Func<string, string> operateText;
				string result;

				operateText = StringHandler.RemoveSeparators;
				result = operateText(MyString);
				Console.WriteLine($"Строка до удаления сепараторов: {MyString}");

				operateText = StringHandler.RemoveSpaces;
				result = operateText(result);
				Console.WriteLine($"Строка после удаления пробелов: {result}");

				operateText = StringHandler.UpperSymbols;
				result = operateText(result);
				Console.WriteLine($"Строка после привдениия строки в верхнему регистру: {result}");

				operateText = StringHandler.AddSymbols;
				result = operateText(result);
				Console.WriteLine($"Строка после добавления символов: {result}\n");

				Action<string> GetSize = StringHandler.CountSymbols;
				GetSize(result);

				Predicate<string> HasChanged = text => text.Length < MyString.Length;

				Console.WriteLine(HasChanged(result) ? "Строка изменилась" : "Строка не изменилась");
			}

			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}

			finally
			{
				Console.WriteLine("\nЗавершение работы программы");
			}

		}
	}
}
