
using WaidevEpisodes.Data;
using WaidevEpisodes.DynamicCollections;

//using System.Linq;

namespace WaidevEpisodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            //IEnumerator<int> enumerator = list.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //    // Console.WriteLine("Inside movenext function");
            //}
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }










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
        }

       
    }
}
