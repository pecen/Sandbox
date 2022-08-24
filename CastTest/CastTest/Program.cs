using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CastTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Func<int> myFunc = () => 10;
            Expression<Func<int>> myExpr = () => 10;

            object[] doubles = { 1.0, 2.0, 3.0, 4.0, 3.0 };
            IEnumerable<double> d = doubles.Cast<double>();
            var e = d.Where(c => c == 3);
            foreach (var item in e)
            {
                WriteLine(item);
            }
            //WriteLine(e);
            ReadKey();
        }
    }
}
