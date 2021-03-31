using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ControlAViewModel : BindableBase
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public ControlAViewModel()
        {
            Text = "Hello from ControlAViewModel";
        }
    }
}
