using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
	public class Program
	{
		public static void Main()
		{
			try
			{
				Student student1 = new Student();
				Student student2 = new Student("Igor", "Romanov", new DateTime(2006, 05, 02));
				Student student3 = new Student("Yan", "Reny", new DateTime(2005, 12, 13));
				Student student4 = new Student("Златочка", "Офигевшая", new DateTime(2010, 12, 12));

				StudentCollection<Student> students = new StudentCollection<Student>();

				students.AddStudent(student3);
				students.AddStudent(student2);
				students.AddStudent(student1);
				students.PrintCollection(students);

				Console.WriteLine($"Первый студент из очереди {students.GetFirstStudent()} вышел");
				students.PrintCollection(students);

				students.IsContained(student3);

				Queue<int> IntCollection = new Queue<int>();
				IntCollection.Enqueue(13);
				IntCollection.Enqueue(5);
				IntCollection.Enqueue(69);
				IntCollection.Enqueue(29);
				IntCollection.Enqueue(44);

				Console.WriteLine("Элементы целочисленной очереди: ");
				PrintIntCollection(IntCollection);

				Console.Write("Введите n удаляемых элементов: ");
				int n = Convert.ToInt32(Console.ReadLine());
				if (n > IntCollection.Count)
				{
					throw new ArgumentOutOfRangeException("Количество удаляемых элементов превысило число элементов в очереди!");
				}
				for (int i = n; i > 0; i--)
				{
					IntCollection.Dequeue();
				}

				List<int> QueueList = new List<int>(IntCollection);
				Console.WriteLine("\nСписок элементов очереди: ");
				PrintIntCollection(QueueList);

				Console.Write("Введите элемент для проверки ео нахождения в списке: ");
				n = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine($"Содержится ли элемент {n} в списке? - {QueueList.Contains(n)}");


				var ObservedStudents = new ObservableCollection<Student>
				{
					student4,
					student1
				};

				ObservedStudents.CollectionChanged += ObservedStudents_CollectionChanged;
				ObservedStudents.Add(student2);
				ObservedStudents.Remove(student1);
			}

			catch (Exception ex)
			{
				Console.WriteLine($"Произошла ошибка: {ex.Message}");
				Console.WriteLine($"Место {ex.StackTrace}");
			}

			finally
			{
				Console.WriteLine("\nЗавершение работы программы");
			}
		}

		private static void ObservedStudents_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					if (e.NewItems?[0] is Student newStudent)
					{
						Console.WriteLine($"В наблюдаемую коллекцию добавлен новый стдуент: {newStudent}");
					}
					break;

				case NotifyCollectionChangedAction.Remove:
					if (e.OldItems?[0] is Student oldStudent)
					{
						Console.WriteLine($"Из наблюдаемой коллеции удален студент: {oldStudent}");
					}
					break;
			}
		}

		public static void PrintIntCollection(IEnumerable<int> collection)
		{
			foreach (var element in collection)
			{
				Console.WriteLine(element);
			}
		}
	}
}
