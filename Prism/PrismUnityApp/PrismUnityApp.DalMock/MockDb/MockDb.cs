using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBooking.DalMock.MockDb
{
    public static class MockDb
    {
        public static List<UserData> Users { get; private set; } 

        static MockDb()
        {
            Users = new List<UserData>{
                new UserData{ Id = 0, FirstName = "Peter", LastName = "Centellini", LastUpdated = new DateTime(2014, 10, 21) },
                new UserData{ Id = 1, FirstName = "Elmira", LastName = "Daminova", LastUpdated = new DateTime(2014, 12, 21) },
                new UserData{ Id = 2, FirstName = "Matilda", LastName = "Centellini", LastUpdated = new DateTime(2014, 10, 11) },
                new UserData{ Id = 3, FirstName = "Amanda", LastName = "Niesel", LastUpdated = new DateTime(2013, 10, 21) }
            };
        }
    }
}
