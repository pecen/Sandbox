using PrismUnityApp.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismUnityApp.Dal.Dto;
using EBooking.DalMock.MockDb;

namespace PrismUnityApp.DalMock
{
	public class PersonDal : IPersonDal
	{
		public IList<PersonDto> Fetch()
		{
			var data = from r in MockDb.Users
									select new PersonDto { Id = r.Id, FirstName = r.FirstName, LastName = r.LastName, LastUpdated = r.LastUpdated };
			return data.ToList();
		}

		public PersonDto Fetch(int id)
		{
			var data = (from r in MockDb.Users
									where r.Id == id
									select new PersonDto { Id = r.Id, FirstName = r.FirstName, LastName = r.LastName, LastUpdated = r.LastUpdated }
									).FirstOrDefault();
			return data;
		}
	}
}
