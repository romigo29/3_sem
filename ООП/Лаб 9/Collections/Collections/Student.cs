using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
	public class Student 
	{
		public string Name { get; set; }
		public string LastName { get; set; }

		public DateTime BirthdayDate { get; set; }

		public Student()
		{
			Name = "Ivan";
			LastName = "Ivanov";
			BirthdayDate = DateTime.Now;
		}

		public Student(string name, string lastName, DateTime birthdayDate)
		{
			Name = name;
			LastName = lastName;
			BirthdayDate = birthdayDate;
		}

		public string GetFullName() => $"{Name}{LastName}";

		public DateTime GetBirthdayDate() => BirthdayDate;

		public int GetCurrentAge()
		{
			var today = DateTime.Now;
			int age = today.Year - BirthdayDate.Year;
			if (BirthdayDate > today.AddYears(-age)) age--;
			return age;
		}

		public override string ToString()
		{
			return GetFullName();
		}
	}

	public class StudentCollection<Student> : IEnumerable<Student>
	{
		public Queue<Student> students = new Queue<Student>();

		public void AddStudent(Student student)
		{
			students.Enqueue(student);
		}

		public Student GetFirstStudent()
		{
			return students.Dequeue();
		}

		public void IsContained(Student student)
		{
			if (students.Contains(student))
			{
				Console.WriteLine($"\nСтудент {student} есть в очереди");
			}
			else
				{
				Console.WriteLine($"\nСтудента {student} нет в очереди");
			}
		}

		public void PrintCollection(IEnumerable<Student> students)
		{
			Console.WriteLine("\nВсе студенты: ");
			foreach(Student student in this)
			{
				Console.WriteLine(student + " ");
			}
		}
		public IEnumerator<Student> GetEnumerator() => students.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
