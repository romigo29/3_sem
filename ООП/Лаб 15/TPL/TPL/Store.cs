using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	static public class Store
	{
		static BlockingCollection<string> Warehouse = new BlockingCollection<string>();
		static Random random = new Random();
		static readonly int NProducers = 5; 
		static readonly int NConsumers = 10;

		static public List<string> products = new List<string>
			{
			"Холодильник", "Стиральная машина", "Телевизор",
			"Микроволновка", "Пылесос", "Кондиционер",
			"Духовка", "Утюг", "Чайник", "Тостер"
			};

		static public void Showcase()
		{
			Task[] producers = new Task[NProducers]; 
			for (int i = 0; i < NProducers; i++)
			{
				int producerID = i + 1;
				producers[i] = Task.Run(() => Producer(producerID));
			}

			Task[] consumers = new Task[NConsumers];
			for (int i = 0; i < NConsumers; i++)
			{
				int consumerId = i + 1;
				consumers[i] = Task.Run(() => Consumer(consumerId));
			}

			Task.Delay(7000).Wait();
			Warehouse.CompleteAdding();

			Task.WaitAll(producers);
			Task.WaitAll(consumers);

			Console.WriteLine("Работа со складом завершена");
		}

		static public void Producer(int ProducerID)
		{
			while (!Warehouse.IsAddingCompleted)
			{
				string RandomProduct = products[random.Next(products.Count)];

				Thread.Sleep(random.Next(500, 1000));

				if (!Warehouse.IsAddingCompleted && Warehouse.TryAdd(RandomProduct))
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine($"Поставщик №{ProducerID} завез на склад товар: {RandomProduct}");
					Console.ForegroundColor = ConsoleColor.White;
					PrintWarehouseState();
				}
			}
		}

		static public void Consumer(int ConsumerID)
		{
			while (!Warehouse.IsCompleted)
			{
				Thread.Sleep(random.Next(1500, 3000));
				if (Warehouse.TryTake(out string product))
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Счастливый покупатель №{ConsumerID} взял с полок товар {product}");
					Console.ForegroundColor = ConsoleColor.White;
					PrintWarehouseState();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(($"Разочарованный покупатель №{ConsumerID} покинул магазин"));
					Console.ForegroundColor = ConsoleColor.White;
				}
				Thread.Sleep(1000);
			}
		}
		static public void PrintWarehouseState()
		{
			Console.WriteLine("Склад: " + string.Join(", ", Warehouse));
		}
	}
}