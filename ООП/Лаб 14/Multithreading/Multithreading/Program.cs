using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;

using System.Diagnostics;
using System.IO;
using Multithreading;

namespace Multithreading_NETFRAME
{
	class Program
	{
		static void Main(string[] args)
		{
			/*//1
			Processes.ShowcaseProcesses();
			//2
			Domains.ShowcaseDomains();*/

			//3
			//PrimeNumbers.ShowProcess();

			//4
			/*Synchronization.ChangedPriority();*/

			/*Synchronization.PrintEvenOdd();*/

			Synchronization.PrintOneByOne();

			/*//5
			MyStopwatch.Showcase();*/

		}
	}
}