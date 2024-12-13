using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace Serialization
{
	public interface ISerializer
	{
		void Serialize<T>(T obj, string fileName);
		T Deserializer<T>(string fileName);
	}


	public class BinaryFormatSerializer : ISerializer
	{
		public void Serialize<T>(T obj, string fileName)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, obj);
			}

		}

		public T Deserializer<T>(string fileName)
		{


			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) 
			{
				return (T)formatter.Deserialize(fs);
			}
		}
	}

	public class SoapFormatterSerializer : ISerializer
	{
		
		public void Serialize<T>(T obj, string fileName)
		{
			SoapFormatter formatter = new SoapFormatter();

			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, obj);
			}
		}

		public T Deserializer<T>(string fileName)
		{
			SoapFormatter formatter = new SoapFormatter();

			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				return (T)formatter.Deserialize(fs);
			}
		}
	}

	public class XMLFormatSerializer : ISerializer
	{

		public void Serialize<T>(T obj, string fileName)
		{
			XmlSerializer xSer = new XmlSerializer(typeof(T));

			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				xSer.Serialize(fs, obj);
			}
		}


		public T Deserializer<T>(string fileName)
		{
			XmlSerializer xSer = new XmlSerializer(typeof(T));

			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				return (T)xSer.Deserialize(fs)!;
			}

		}
	}

	public class JSONFormatSerializer : ISerializer
	{
		public void Serialize<T>(T obj, string fileName)
		{
			string json = JsonSerializer.Serialize(obj);
			File.WriteAllText(fileName, json);
		}

		public T Deserializer<T>(string fileName)
		{
			string json = File.ReadAllText(fileName);

			return JsonSerializer.Deserialize<T>(json)!;
		}

	}
}

