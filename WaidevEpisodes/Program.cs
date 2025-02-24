

using System.Collections.Generic;
using WaidevEpisodes;
using WaidevEpisodes.Data;

namespace WaidevEpisodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var csv = new Csv();
           var list= csv.Read();
             //list.Display(x => new { x.FirstName, LastName = x.LastName  });
           var fistnames=  list.Select((c,i) => new {SerialNo=i+1, c.FirstName,c.LastName , c.Salary });
             fistnames.Display(x => new {x.SerialNo, x.FirstName, x.LastName, x.Salary });

            #region Old
            //CustomList<int> list = new CustomList<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            ////IEnumerator<int> enumerator = list.GetEnumerator();
            ////while (enumerator.MoveNext())
            ////{
            ////    Console.WriteLine(enumerator.Current);
            ////    // Console.WriteLine("Inside movenext function");
            ////}
            //foreach (int item in list)
            //{
            //    Console.WriteLine(item);
            //}










            //var csv= new Csv(new CustomerService());
            // csv.Create();
            //var customers= csv.Read();

            // var customerData = new CustomerData(new CustomerService());


            // //var customers = customerData.getCusttomer();

            //var Filteredcutomers= customers.Filter(x => x.Salary < 40000);
            // var Filteredcutomers2 = customers.Filter(x => x.Salary > 40000);
            // var Filteredcutomers3 = customers.Filter(x => x.DateOfBirth < DateTime.Now);
            // var Filteredcutomers4 = customers.Filter(x => x.FullName.StartsWith("J"));
            // customerData.Print(Filteredcutomers);
            #endregion
        }

        private static (string FirstName, string LastName, decimal Salary)PartialCustomer(Customer customer)
        {
            (string FirstName, string LastName, decimal Salary) c =
                (customer.FirstName, customer.LastName, customer.Salary);
            return c;
        }
    }
}
//var fistnames = LinqExtentions.Select(list, c => new { c.FirstName });
//foreach (var f in fistnames)
//{
//    Console.WriteLine(f.FirstName);


//}

//var fistnames = list.Select((c, i) =>
//{
//    if (c.Salary < 40000)
//    {
//        return new { c.FirstName, LastName = c.LastName + "-", c.Salary };
//    }
//    return new { c.FirstName, c.LastName, c.Salary };
//});