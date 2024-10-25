using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
	static class StatisticOperation
	{
		public static int GetSum(Stack stack)
		{
			int sum = 0;
			for (int i = 0; i < stack.GetCurrentSize(stack); i++)
			{
				sum += stack[i];
			}
			return sum;
		}

		public static int GetDifferenceMinMax(Stack stack)
		{
			int minValue = int.MaxValue;
			int maxValue = int.MinValue;

			int length = stack.GetCurrentSize(stack);
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
			return stack.GetCurrentSize(stack);
		}

		public static int CountInterrogativeSentences(this string text)
		{
			int count = 0;
			int length = text.Length - 1;
			for (int i = 0; i <= length; i++)
			{
				if ((i != length && text[i] == '?' && text[i + 1] == ' ') || (i == length && text[i] == '?'))
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
	}
