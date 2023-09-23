using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroTest.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            Title = "My Caliburn.Micro Test";

            _eventAggregator.PublishOnUIThreadAsync($@"...and here's the Title again: ""{Title}""");
        }
    }
}
