using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	public class NullException : NullReferenceException
	{
		public NullException(string message) : base(message) {}
	}

	public class OutOfRangeException : ArgumentOutOfRangeException
	{
		public OutOfRangeException(string message) : base(message) { }
	}

	public class InvalidArgumentException : ArgumentException
	{
		public InvalidArgumentException(string message) : base(message) { }

	}

	public class WindowException : Exception 
	{
		public WindowException(string message) : base(message) { }
	}
}
