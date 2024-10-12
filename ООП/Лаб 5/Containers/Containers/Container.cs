using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inheritance
{
	public class Container
	{
		public Figure[] FigureContainer;
		public int Count {  get; set; }

		public Container(int size)
		{
			FigureContainer = new Figure[size];
		}

		// Get метод для получения массива фигур
		public Figure[] SetFigures
		{
			get
			{
				// Возвращаем массив фигур с размером count
				Figure[] currentFigures = new Figure[Count];
				Array.Copy(FigureContainer, currentFigures, Count);
				return currentFigures;
			}

			set
			{
				if (value.Length > FigureContainer.Length)
				{
					Console.WriteLine("Массив слишком большой. Невозможно создать");
					return;
				}
				Array.Copy(value, FigureContainer, value.Length);
				Count = value.Length;
			}

		}

		public void AddFigure(Figure figure) 
		{ 

			if (Count >= FigureContainer.Length)
			{
				Console.WriteLine("Массив полностью заполнен! Больше нельзя добавить фигуру.");
				return;
			}

			FigureContainer[Count++] = figure;
		}

		public void RemoveFigure(int index)
		{
			if (index < 0 || index >= Count)
			{
				Console.WriteLine("Невозможно найти фигуру по заданному индексу");
			}

			FigureContainer[index] = null;

			for (int i = index; i < Count - 1; i++)
			{
				FigureContainer[i] = FigureContainer[i + 1];
			}

			FigureContainer[Count - 1] = null;
			Count--;
		}

		public void PrintContainer()
		{
			if (FigureContainer is null)
			{
				Console.WriteLine("Контейнер пуст!");
				return;
			}

			for (int i = 0; i < Count; i++)
			{
				
				Console.WriteLine($"Фигура №{i}: {FigureContainer[i]}");
			}
		}

	}
}
