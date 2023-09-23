using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroTest.ViewModel
{
    public class ViewModelBase 
    {
		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

	}
}
