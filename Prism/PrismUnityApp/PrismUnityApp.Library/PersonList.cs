using Csla;
using PrismUnityApp.Dal;
using PrismUnityApp.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp.Library
{
	[Serializable]
	public class PersonList : ReadOnlyListBase<PersonList, PersonInfo>
	{
		#region Factory Methods

		//public static PersonInfo GetPerson(int id)
		//{
		//	return DataPortal.Fetch<PersonInfo>(id);
		//}

		public static PersonList GetPersonList()
		{
			return DataPortal.Fetch<PersonList>();
		}

		#endregion

		#region Data Access

		private void DataPortal_Fetch()
		{
			bool rlce = RaiseListChangedEvents;
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			using (var dalManager = DalFactory.GetManager()) {
				IPersonDal dal = dalManager.GetProvider<IPersonDal>();
				IList<PersonDto> data = dal.Fetch();

				foreach (var item in data) {
					Add(DataPortal.FetchChild<PersonInfo>(item));
				}
			}
		}

		#endregion
	}
}
