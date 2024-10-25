using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
	public interface IGenericInterface<T>
	{
		void AddElement(T element);
		void RemoveElement(T element);

		void ViewElements();
	}

	interface IResize
	{
		void Resize(int height, int weight);
	}
}
