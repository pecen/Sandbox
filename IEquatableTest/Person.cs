using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEquatableTest
{
	public class Person : IEquatable<Person>
	{
		public readonly string _name;
		public Person(string name)
		{
			_name = name;
		}

		public bool Equals(Person other)
		{
			if(other == null) {
				return false;
			}

			return StringComparer.Ordinal.Equals(_name, other._name);
		}

		public override int GetHashCode()
		{
			return this._name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			Person p = obj as Person;
			if (p == null)
				return false;

			return Equals(p);
		}
	}
}
