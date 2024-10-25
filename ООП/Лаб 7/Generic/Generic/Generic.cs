using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{

	public class CollectionType<T> : IGenericInterface<T> where T : class
	{
		public List<T> collection;

		public CollectionType()
		{
			collection = new List<T>();
		}
		public CollectionType(int size)
		{
			if (size > 0)
			{
				collection = new List<T>(size);
			}

			else
			{
				throw new ArgumentException("Размер должен быть положительным!");

			}
		}

		public CollectionType(List<T> collection)
		{
			this.collection = collection;
		}

		public T this[int size]
		{
			get { return collection[size]; }
			set
			{
				if (size > 0)
				{
					collection[size] = value;
				}

				else
				{
					throw new ArgumentException("Размер должен быть положительным!");

				}
			}
		}

		public void AddElement(T element)
		{
			try
			{
				collection.Add(element);
			}

			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка добавленния элемента в коллекцию: {ex.Message}");
			}

			finally
			{
				Console.WriteLine("Завершение добавление элемента");
			}
		}

		public void RemoveElement(T element)
		{
			try
			{
				collection.Remove(element);
			}

			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка удаления элемента из коллекции: {ex.Message}");
			}

			finally
			{
				Console.WriteLine("Завершение удаление элемента");
			}
		}

		public void ViewElements()
		{
			try
			{
				foreach (T item in collection)
				{
					Console.WriteLine(item);
				}
			}

			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка вывода элементов в консоль {ex.Message}");
			}

			finally
			{
				Console.WriteLine("Завершение вывода элементов");
			}
		}

		public T GetByPredicate(Predicate<T> predicate)
		{
			return collection.FindAll(predicate).FirstOrDefault();
		}

		public void WriteToFile(ref CollectionType<T> collection)
		{
			string filePath = @"..\..\..\log.txt";
			Console.WriteLine("Записываю данные в файл...");
			using (var file = new StreamWriter(filePath, false))
			{
				foreach (var item in collection.collection)
				{
					file.WriteLine(item);
				}
			}
		}

		public void ReadFromFile()
		{
			using (var file = new StreamReader(@"..\..\..\log.txt", true))
			{
				Console.WriteLine($"Полученные данные из файла: {file.ReadToEnd()}");
			}
		}
	}
	}
