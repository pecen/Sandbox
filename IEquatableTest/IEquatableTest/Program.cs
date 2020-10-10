using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IEquatableTest
{
	class Program
	{
		static void Main(string[] args)
		{
			EqualityCheck();

			ReadKey();
		}

		static void EqualityCheck()
		{
			//var p = new Person("Peter");
			//var list = new ArrayList();
			//list.Add(p);

			//WriteLine(list.Contains(p));
			//WriteLine(list.Contains(new Person("Peter")));

			object carOne = new Car() { Id = 1, Name = "Volvo", Age = 3 };
			Car carTwo = new Car() { Id = 1, Name = "Volvo", Age = 3 };

			WriteLine(carOne.Equals(carTwo));
		}
	}
}
