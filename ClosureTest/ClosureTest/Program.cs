using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosureTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = foo();
            bar(a);
        }
        
        public static Action foo()
        {
            int i = 100;

            //Action a = () =>
            //{
            //    Console.Write($"{i} ");
            //    Console.WriteLine("Another line...");
            //    Console.ReadKey();
            //};

            void a()
            {
                Console.Write($"{i} ");
                Console.WriteLine("Another line...");
                Console.ReadKey();
            }

            return a;
        }
        
        public static void bar(Action a)
        {
            a();
        }
    }
}
