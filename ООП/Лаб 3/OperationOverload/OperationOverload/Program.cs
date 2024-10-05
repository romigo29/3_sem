using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OperationOverload
{
	partial class Stack
	{
		public class Production
		{
			Guid Id { get; set; }
			string organizationName { get; set; }


			public Production(string name)
			{
				Id = Guid.NewGuid();
				organizationName = name;
			}
		}

		public class Developer
		{
			string fullName { get; set; }
			Guid Id { get; set; }
			string department { get; set; }


			public Developer(string name, string dep)
			{
				fullName = name;
				Id = Guid.NewGuid();
				department = dep;
			}
		}
	}
	partial class Stack
	{
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (obj.GetType() != this.GetType())
			{
				return false;
			}

			Stack stack = (Stack)obj;
			if (this.currentSize == stack.currentSize)
			{
				for (int i = 0; i < stack.currentSize; i++)
				{
					if (this[i] != stack.arrStack[i])
					{
						return false;
					}
				}

				return true;
			}

			return false;

		}
		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 23 + currentSize.GetHashCode();
			foreach (var item in arrStack)
			{
				hash = hash * 23 + item.GetHashCode();
			}
			return hash;
		}

	}
	partial class Stack
	{

		int [] arrStack;
		int stackSize;
		int currentSize;
		
		public Stack()
		{
			stackSize = 10;
			currentSize = 0;
			arrStack = new int[stackSize];
		}

		public Stack(int stack_size)
		{
			stackSize = stack_size;
			currentSize = 0;
			arrStack = new int[stackSize];
		}

		public int this[int index]
		{
			get { return arrStack[index]; }
			set { arrStack[index] = value; }
		}

		public int getCurrentSize(Stack stack)
		{
			return stack.currentSize;
		}

		public static string PrintStack(Stack stack)
		{
			string result = "";
			for (int i = 0; i < stack.currentSize; i++)
			{
				result += stack[i] + " ";
			}

			return result;
		}

		public static Stack operator * (Stack stack, int element)
		{
			if (stack.currentSize >= stack.stackSize)
			{
				Console.WriteLine("Стек переполнен! Не удалось добавить элемент");
				return stack;
			}
			stack.arrStack[stack.currentSize++] = element;
			return stack;
		}

		public static int operator / (Stack stack, int _)
		{
			if (stack.currentSize == 0)
			{
				Console.WriteLine("Стек пуст! Не удалось извлечь элемент");
				return -1;
			}
			int element = stack.arrStack[stack.currentSize - 1];
			stack.arrStack[stack.currentSize - 1] = 0;
			stack.currentSize--;
			return element;
		} 

		public static bool operator true(Stack stack)
		{
			foreach (int element in stack.arrStack)
			{
				if (element < 0)
				{
					return true;
				}
			}

			return false;
		}

		public static bool operator false(Stack stack)
		{
			foreach (int element in stack.arrStack)
			{
				if (element >= 0)
				{
					return true;
				}
			}

			return false;
		}

		public static bool operator ==(Stack stack1, Stack stack2)
		{
			return stack1.Equals(stack2);
		}

		public static bool operator !=(Stack stack1, Stack stack2)
		{
			return !stack1.Equals(stack2);
		}
	}

	static class StatisticOperation
	{
		public static int GetSum(Stack stack)
		{
			int sum = 0;
			for (int i = 0; i < stack.getCurrentSize(stack); i++)
			{
				sum += stack[i];
			}
			return sum;
		}

		public static int GetDifferenceMinMax(Stack stack)
		{
			int minValue = int.MaxValue;
			int maxValue = int.MinValue;

			int length = stack.getCurrentSize(stack);
			for (int i = 0; i < length; i++)
			{
				if (stack[i] < minValue)
				{
					minValue = stack[i];
				}

				if (stack[i] > maxValue)
				{
					maxValue = stack[i];
				}
			}

			return maxValue - minValue;
		}

		public static int GetCount(Stack stack)
		{
			return stack.getCurrentSize(stack);
		}

		public static int CountInterrogativeSentences(this string text)
		{
			int count = 0;
			int length = text.Length - 1;
			for (int i = 0; i <= length; i++)
			{
				if ( (i != length && text[i] =='?' && text[i+1] == ' ') || (i == length && text[i] == '?'))
				{
					count++;
				}
			}

			return count;
		}

		public static bool IsStackEmpty(this Stack stack)
		{
			return stack[0] == 0;
		}
	}
	class Showcase
	{
		static void Main(string[] args)
		{
			Stack.Production myProduction = new Stack.Production("BSTU");
			Stack.Developer myDeveloper = new Stack.Developer("Романов Игорь Вячеславович", "ФИТ");
			
			var myStack = new Stack();
			var myStack2 = new Stack(9);
			var myStack3 = new Stack();
			myStack = myStack * 10;
			myStack = myStack * 7;

			myStack2 = myStack2 * 10;
			myStack2 = myStack2 * 7;

			Console.WriteLine($"Стек myStack: {Stack.PrintStack(myStack)}");
			Console.WriteLine($"Стек myStack2: {Stack.PrintStack(myStack2)}");
			Console.WriteLine($"Стек myStack3: {Stack.PrintStack(myStack3)}");

			int element1 = myStack / 0;
			Console.WriteLine($"Последний добавленный элемент в стек myStack: {element1}");

			if (myStack)
			{
				Console.WriteLine("В стеке есть отрицательные элементы");
			}

			else
			{
				Console.WriteLine("В стеке все элементы не отрицательные");
			}

			if (myStack == myStack2)
			{
				Console.WriteLine("Стеки равны");
			}
			else
			{
				Console.WriteLine("Стеки не равны");
			}

			Console.WriteLine($"Сумма элементов стека myStack: {StatisticOperation.GetSum(myStack)}");
			Console.WriteLine($"Разница между минимальным и максимальным элементами стека myStack: {StatisticOperation.GetDifferenceMinMax(myStack)}");

			Console.WriteLine($"Пуст ли стек myStack3? {StatisticOperation.IsStackEmpty(myStack3)}");
			string myText = "ss?wdd? dd?";
			Console.WriteLine($"Количество вопросительных предложений в тексте '{myText}': {StatisticOperation.CountInterrogativeSentences(myText)}");
		}
	}
}
