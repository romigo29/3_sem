using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Reflection
{
	public static class Reflector
	{
		private static string Path = @"..\..\..\log.txt";
		private static string InvokePath = @"..\..\..\invoke.txt";
		private static string InvokePath2 = @"..\..\..\invoke2.txt";

		static public void GetTypeInfo(Type type, string? parameter = null)
		{
			string? info = $"Информация о классе: {type.Name}\n";
			List<string>? Result =
			[
				info,
				GetAssemblyName(type),
				HasPublicConstructors(type),
				"\nМетоды: \n",
				.. GetPublicMethods(type),
			];

			var fields_properties = GetFieldAndPropertiesInfo(type);
			if (fields_properties.Any()) 
			{
				Result.Add("\nПоля: \n");
				Result.AddRange(fields_properties); 
			}
			else 
			{
				Result.Add("\nВ классе нет публичных полей и свойств\n");
			}

			var interfaces = GetInterfaces(type);
			if (interfaces.Any())
			{
				Result.Add("\nИнтерфейсы: \n");
				Result.AddRange(interfaces);
			}
			else {
				Result.Add("\nВ классе не реализованы интерфейсы\n");
			}

			Result.Add(GetMethodsByParameters(type, parameter));
			File.WriteAllLines(Path, Result);

			Invoke(type, "CreateRectangle", InvokePath);
			/*Invoke(type, "ContainsElement", InvokePath2);*/
			Console.WriteLine($"Результат Create: {Create<Rectangle>(["Rectangle", 2, 4, 2, 4])}");
		}

		static string GetAssemblyName(Type type)
		{
			string? name = "Имя сборки: ";
			name += type.Assembly.FullName + "\n";
			return name;
		}

		static string HasPublicConstructors(Type type)
		{
			foreach (var c in type.GetConstructors())
			{
				if (c.IsPublic)
				{
					return "В классе есть публичные конструкторы\n";
				}
			}

			return "В классе нет публичных конструкторов\n";
		}

		static IEnumerable<string> GetPublicMethods(Type type)
		{
			return type.GetMethods()
				.Where(m => m.IsPublic)
				.Select(m => m.ToString() ?? "Неизвестный метод");
		}

		static IEnumerable<string> GetFieldAndPropertiesInfo(Type type)
		{
			var fields = type.GetFields()
				.Where (f => f.IsPublic)
				.Select(f => $"Имя поля: {f.Name}" ?? "Неизвестное поле");

			var properties = type.GetProperties()
				.Select(p => $"Имя свойства: {p.Name}" ?? "Неизвестное свойство");

			return fields.Concat(properties);

		}

		static IEnumerable<string> GetInterfaces(Type type)
		{
			return type.GetInterfaces()
				.Where(i => i.IsInterface)
				.Select(i => i.Name);
		}

		static string GetMethodsByParameters(Type type, string parameter)
		{
			if (string.IsNullOrEmpty(parameter))
				return "Тип параметра не указан.";

			Type? CheckParameter = Type.GetType(parameter);

			if (CheckParameter == null)
				return $"Тип параметра '{parameter}' не найден.";

			string? methods = "";

			methods += $"Методы с параметром: '{parameter}'\n";
			foreach (var m in type.GetMethods())
			{
				foreach (var p in m.GetParameters())
				{
					if (p.ParameterType == CheckParameter)
					{
						methods += $"{m.Name}\n"; 
						break; 
					}
				}
			}

			return methods;
		}

		static void Invoke(Type type, string methodname, string readfile)
		{
			if (type is null)
			{
				throw new NullReferenceException("Попытка работы с типом Null");
			}

			MethodInfo? method = type.GetMethod(methodname);

			if (method is null)
			{
				throw new MissingMethodException($"В классе {type} не удалось найти методы");
			}

			ParameterInfo[] parameters = method.GetParameters();
			object[] arguements = new object[parameters.Length];

			if (File.Exists(readfile))
			{
				string[] fileParameters = File.ReadAllLines(readfile);

				if (fileParameters.Length < parameters.Length)
				{
					throw new ArgumentException($"Параметров в файле '{InvokePath}' оказалось меньше, чем предполагалось"); 
				}

				for (int i = 0; i < parameters.Length; i++)
				{
					string ParameterWithoutSpaces = fileParameters[i].Trim();
					if (ParameterWithoutSpaces != null)
					{
						arguements[i] = Convert.ChangeType(ParameterWithoutSpaces, parameters[i].ParameterType);	
					}

					else
					{
						arguements[i] = GenerateValue(parameters[i].ParameterType);
					}
				}
			}

			else
			{
				for (int i = 0; i < parameters.Length; i++)
				{
					arguements[i] = GenerateValue(parameters[i].ParameterType);
				}
			}

			object? classObject = Activator.CreateInstance(type);

			if (classObject == null)
			{
				throw new Exception($"Объект '{classObject}' не удалось создать");
			}

			object result = method.Invoke(classObject, arguements);
			Console.WriteLine($"Результат выполнения метода {method}: {result}");

		}

		private static object? GenerateValue(Type type)
		{
			if (type.IsValueType)
			{
				return GenerateValue(type);
			}

			return null;
		}

		public static T? Create<T>(object[] parameters) where T : class
		{
			Type type = typeof(T);

			ConstructorInfo? constructor = type.GetConstructor(parameters.Select(arg => arg.GetType()).ToArray());

			if (constructor == null) 
			{ 
				throw new Exception($"Нет публичного конструктора типа '{type}' для создания объекта");
			}

			return (T?)constructor.Invoke(parameters);
		}


	}
}
