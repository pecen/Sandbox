using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandDemoApp.Module.Commands {
  public class CalculateCommand : PubSubEvent<double> {
  }
}
