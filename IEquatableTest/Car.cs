using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEquatableTest
{
	public class Car : IEquatable<Car>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }

		public bool Equals(Car other)
		{
			if (other == null) return false;

			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			var c = obj as Car;
			if (c == null) return false;

			return Equals(c);
		}

		public override int GetHashCode()
		{
			return Id;
		}
	}

	public class Lorry : IEqualityComparer<Lorry>
	{
		public bool Equals(Lorry x, Lorry y)
		{
			throw new NotImplementedException();
		}

		public int GetHashCode(Lorry obj)
		{
			throw new NotImplementedException();
		}
	}
}
