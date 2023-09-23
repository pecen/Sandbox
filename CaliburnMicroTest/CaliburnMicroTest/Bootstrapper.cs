using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroTest
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer? _container;

        // ... Other Bootstrapper Config

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container.Singleton<IEventAggregator, EventAggregator>();
        }

        // ... Other Bootstrapper Config
    }
}
