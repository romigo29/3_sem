using System;
using System.Xml.Linq;
using System.Xml.Resolvers;
using System.Xml.XPath;

namespace Serialization
{
	class Progrma
	{
		static void Main()
		{

			Rectangle[] rectangles = new Rectangle[]
			{
				new Rectangle(4, 5, 100, 200),
				new Rectangle(7, 8, 150, 250),
				new Rectangle(1, 4, 300, 200)
			};

			ISerializer binarySerializer = new BinaryFormatSerializer();
			binarySerializer.Serialize(rectangles, "rectangles.bin");

			ISerializer soapSerializer = new SoapFormatterSerializer();
			soapSerializer.Serialize(rectangles, "rectangles.soap");

			ISerializer xmlSerializer = new XMLFormatSerializer();
			xmlSerializer.Serialize(rectangles, "rectangles.xml");

			ISerializer jsonSerializer = new JSONFormatSerializer();
			jsonSerializer.Serialize(rectangles, "rectangles.json");


			Rectangle[] binaryDeserialized = binarySerializer.Deserializer<Rectangle[]>("rectangles.bin");
			Rectangle[] soapDeserialized = soapSerializer.Deserializer<Rectangle[]>("rectangles.soap");
			Rectangle[] xmlDeserialized = xmlSerializer.Deserializer<Rectangle[]>("rectangles.xml");
			Rectangle[] jsonDeserialized = jsonSerializer.Deserializer<Rectangle[]>("rectangles.json");


			PrintFigures(binaryDeserialized);
			PrintSeparator();
			PrintFigures(soapDeserialized);
			PrintSeparator();
			PrintFigures(xmlDeserialized);
			PrintSeparator();
			PrintFigures(jsonDeserialized);


			XPathDocument doc = new XPathDocument("rectangles.xml");
			XPathNavigator nav = doc.CreateNavigator();

			Console.WriteLine("Все прямоугольники: ");
			XPathNodeIterator allRectangles = nav.Select("//Rectangle");
			while (allRectangles.MoveNext())
			{
				string x = allRectangles.Current.SelectSingleNode("X").Value;
				string y = allRectangles.Current.SelectSingleNode("Y").Value;
				string height = allRectangles.Current.SelectSingleNode("Height").Value;
				string width = allRectangles.Current.SelectSingleNode("Width").Value;

				Console.WriteLine($"Rectangle: X={x}, Y={y}, Height={height}, Width={width}");
			}

			Console.WriteLine("Все прямоугольнники с высотой > 100 и шириной > 200");
			XPathNodeIterator largerRectangles = nav.Select("//Rectangle [Height > 100] [Width > 200]");

			while (largerRectangles.MoveNext())
			{
				string x = largerRectangles.Current.SelectSingleNode("X").Value;
				string y = largerRectangles.Current.SelectSingleNode("Y").Value;
				string height = largerRectangles.Current.SelectSingleNode("Height").Value;
				string width = largerRectangles.Current.SelectSingleNode("Width").Value;

				Console.WriteLine($"Rectangle: X={x}, Y={y}, Height={height}, Width={width}");
			}

			PrintSeparator();

			XDocument XMLRectangles = new XDocument(new XElement("Rectangles",
				new XElement("Rectangle",
					new XElement("X", 4),
					new XElement("Y", 5),
					new XElement("Height", 100),
					new XElement("Width", 200)),
				new XElement("Rectangle",
					new XElement("X", 7),
					new XElement("Y", 8),
					new XElement("Height", 150),
					new XElement("Width", 250)),
				new XElement("Rectangle",
					new XElement("X", 1),
					new XElement("Y", 4),
					new XElement("Height", 300),
					new XElement("Width", 200))));
			XMLRectangles.Save("XMLRectangles.xml");

			var XMLAllRectangles = from rect in XMLRectangles.Root.Elements("Rectangle")
								   select new
								   {
									   X = rect.Element("X").Value,
									   Y = rect.Element("Y").Value,
									   Height = rect.Element("Height").Value,
									   Width = rect.Element("Width").Value
								   };

			Console.WriteLine("Все прямоугольники через Linq to XML: ");
			foreach (var rect in XMLAllRectangles)
			{
				Console.WriteLine($"Rectangle: X={rect.X}, Y={rect.Y}, Height={rect.Height}, Width={rect.Width}");
			}

			var XMLLargerRectangles = from rect in XMLRectangles.Root.Elements("Rectangle")
									  where Convert.ToInt32(rect.Element("Height").Value) > 100 &&
									  Convert.ToInt32(rect.Element("Width").Value) > 200
									  select new
									  {
										  X = rect.Element("X").Value,
										  Y = rect.Element("Y").Value,
										  Height = rect.Element("Height").Value,
										  Width = rect.Element("Width").Value
									  };

			Console.WriteLine("Все прямоугольники с высотой > 100 и шириной > 200 через Linq to XML: ");
			foreach (var rect in XMLLargerRectangles)
			{
				Console.WriteLine($"Rectangle: X={rect.X}, Y={rect.Y}, Height={rect.Height}, Width={rect.Width}");
			}
		}
		public static void PrintFigures(Rectangle[] figures)
			{ 
				foreach(Rectangle rect in figures)
				{
				Console.WriteLine(rect.ToString());
				}
			}
		public static void PrintSeparator() => Console.WriteLine("-------------------------------------------");
		
	}
}