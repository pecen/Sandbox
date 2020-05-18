using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateExampleStart {
  public class Employee {
    public string EmployeeName { get; set; }

    // Instead of overriding ToString()
    // use the DisplayMemberPath property to set a path to the value
    // by adding to the Xaml code what you want do display,
    // for instance DisplayMemberPath="Name"
    public override string ToString() {
      return EmployeeName;
    }

  }
}
