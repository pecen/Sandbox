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
  public class PersonInfo : ReadOnlyBase<PersonInfo>
  {
		#region Properties

		public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
		public int Id
		{
			get { return GetProperty(IdProperty); }
			set { LoadProperty(IdProperty, value); }
		}
		public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
		public string FirstName
		{
			get { return GetProperty(FirstNameProperty); }
			set { LoadProperty(FirstNameProperty, value); }
		}
		public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
		public string LastName
		{
			get { return GetProperty(LastNameProperty); }
			set { LoadProperty(LastNameProperty, value); }
		}
		public static readonly PropertyInfo<DateTime> LastUpdatedProperty = RegisterProperty<DateTime>(c => c.LastUpdated);
		public DateTime LastUpdated
		{
			get { return GetProperty(LastUpdatedProperty); }
			set { LoadProperty(LastUpdatedProperty, value); }
		}

		#endregion

		#region Factory Methods

		public static PersonInfo GetPerson(int Id)
		{
			return DataPortal.Fetch<PersonInfo>(Id);
		}

		#endregion

		#region Data Access

		private void Child_Fetch(PersonDto item)
		{
			Id = item.Id;
			FirstName = item.FirstName;
			LastName = item.LastName;
			LastUpdated = item.LastUpdated;
		}

		private void DataPortal_Fetch(int id)
		{
			using (var dalManager = DalFactory.GetManager()) {
				//using (var dal = dalManager.GetProvider<IPersonDal>()) {
				var dal = dalManager.GetProvider<IPersonDal>();
					var data = dal.Fetch(id);

					Id = data.Id;
					FirstName = data.FirstName;
					LastName = data.LastName;
					LastUpdated = data.LastUpdated;
				//}
			}
		}

		#endregion
	}
}
