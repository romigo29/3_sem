using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
	partial class Stack
	{
		public class Production
		{
			Guid Id { get; set; }
			string OrganizationName { get; set; }


			public Production(string name)
			{
				Id = Guid.NewGuid();
				OrganizationName = name;
			}
		}

		public class Developer
		{
			string FullName { get; set; }
			Guid Id { get; set; }
			string Department { get; set; }


			public Developer(string name, string dep)
			{
				FullName = name;
				Id = Guid.NewGuid();
				Department = dep;
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

		readonly int[] arrStack;
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

		public int GetCurrentSize(Stack stack)
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

			result += '\n';
			return result;
		}

		public static Stack operator *(Stack stack, int element)
		{
			if (stack.currentSize >= stack.stackSize)
			{
				Console.WriteLine("Стек переполнен! Не удалось добавить элемент");
				return stack;
			}
			stack.arrStack[stack.currentSize++] = element;
			return stack;
		}

		public static int operator /(Stack stack, int _)
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

		public override string ToString()
		{
			return PrintStack(this);
		}
	}
}
