using congestion.calculator;
using System.Diagnostics;

namespace congestion_tax_calculator_test
{
    [TestClass]
    public class TaxCalculatorTest
    {
        [TestMethod]
        public void CheckRandomDatesTest()
        {
            var mc = new Motorbike();
            var car = new Car();
            var dates = SetDates().ToList();

            var taxCalculator = new CongestionTaxCalculator();

            int index = 0;
            IList<int> TollFreeDatesIndexes = new List<int>();  

            foreach(var date in dates)
            {
                if (index == 16)
                    Debug.Write("16");
                if(taxCalculator.GetTollFee(date, car) == 0)
                {
                    TollFreeDatesIndexes.Add(index);
                }

                index++;
            }

            Assert.IsTrue(TollFreeDatesIndexes.Count != 0);
        }

        [TestMethod]
        public void CheckVehicleHasCorrectNameTest()
        {
            var mc = new Motorbike();
            var car = new Car();

            var taxCalculator = new CongestionTaxCalculator();

            //var sum = taxCalculator.GetTax(vehicle, dateTimes);


            //Assert.IsTrue(sum == 0);

            //bool isSame = taxCalculator.
        }

        [TestMethod]
        public void CheckTollFreeVehiclesNotTaxedTest()
        {
            var vehicle = new Motorbike();
            DateTime[] dateTimes = SetDates();

            var taxCalculator = new CongestionTaxCalculator();

            var sum = taxCalculator.GetTax(vehicle, dateTimes);

            Assert.IsTrue(sum == 0);
        }

        private DateTime[] SetDates()
        {
            return new DateTime[]
            {
                new DateTime(2013, 10, 1, 15, 27, 00),
                new DateTime(2013, 10, 2, 18, 45, 03),
                new DateTime(2013,01,14,21,00,00),

                new DateTime(2013,01,15,21,00,00),

                new DateTime(2013,02,07,06,23,27),

                new DateTime(2013,02,07,15,27,00),

                new DateTime(2013,02,08,06,27,00),

                new DateTime(2013,02,08,06,20,27),

                new DateTime(2013,02,08,14,35,00),

                new DateTime(2013,02,08,15,29,00),

                new DateTime(2013,02,08,15,47,00),

                new DateTime(2013,02,08,16,01,00),

                new DateTime(2013,02,08,16,48,00),

                new DateTime(2013,02,08,17,49,00),

                new DateTime(2013,02,08,18,29,00),

                new DateTime(2013,02,08,18,35,00),

                new DateTime(2013,03,26,14,25,00),

                new DateTime(2013,03,28,14,07,27)
            };
        }

        private DateTime[] SetTollFreeDates()
        {
            return new DateTime[]
            { new DateTime()};
        }
    }
}