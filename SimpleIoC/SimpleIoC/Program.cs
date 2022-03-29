using System;

namespace SimpleIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleIoC ioc = new SimpleIoC();

            ioc.Register<ICustomer, Customer>();
            ioc.Register<ICustomerRepository, CustomerRepository>();
            ioc.Register<IDbGateway, DbGateway>();
            ioc.Register<MainViewModel, MainViewModel>();

            var mainViewModel = ioc.Resolve<MainViewModel>();

            Console.ReadKey();
        }
    }
}
