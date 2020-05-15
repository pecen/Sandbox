using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSerializerTest {
  public class Employee {
    public string EmpName;
    public string EmpID;
    public Employee() { }
    public Employee(string empName, string empID) {
      EmpName = empName;
      EmpID = empID;
    }
  }
}
