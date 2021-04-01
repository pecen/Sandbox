using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
