using PrismUnityApp.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp.Dal
{
	public interface IPersonDal
	{
		IList<PersonDto> Fetch();
		PersonDto Fetch(int id);
	}
}
