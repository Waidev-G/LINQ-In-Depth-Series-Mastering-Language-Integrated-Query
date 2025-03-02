

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
           var First3Elements= list.Take(3);
            //var First3Elements = list.Take(new Range(10,20));
            
            First3Elements.Display(x => new
            {
                x.CustomerId,
                x.FullName,
                x.Salary,
                x.DateOfBirth,
                x.City,
                x.RegistrationDate,
                x.IsActive
            });

            #region Old
            // list.DisplayAll();
            // Console.WriteLine(GetCutomersExample1().First().Age.Years);

            // var csv = new Csv();
            // var list= csv.Read();
            // list.DisplayAll();
            //list.Display(x => new { x.CustomerId, x.FullName,x.Salary,x.DateOfBirth,x.City,x.RegistrationDate,x.IsActive });
            //var fistnames=  list.Select((c,i) => new {SerialNo=i+1, c.FirstName,c.LastName , c.Salary });
            //  fistnames.Display(x => new {x.SerialNo, x.FirstName, x.LastName, x.Salary });
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
        public static IEnumerable<Customer> GetCutomersExample1()
        {
           return new List<Customer>
          {
                new Customer(
                1,
                "John",
                "Doe",
                "john.doe@example.com",
                "123-456-7890",
                "123 Main St",
                "New York",
                "USA",
                new DateTime(1985, 5, 15),
                new DateTime(2020, 1, 10),
                75000,
                true
            ),
                new Customer(
                    2,
                    "Jane",
                    "Smith",
                    "jane.smith@example.com",
                    "234-567-8901",
                    "456 Elm St",
                    "Los Angeles",
                    "USA",
                    new DateTime(1990, 8, 25),
                    new DateTime(2021, 3, 22),
                    60000,
                    true
                ),
                new Customer(
                    3,
                    "Alice",
                    "Johnson",
                    "alice.johnson@example.com",
                    "345-678-9012",
                    "789 Oak St",
                    "Chicago",
                    "USA",
                    new DateTime(1978, 12, 5),
                    new DateTime(2019, 7, 14),
                    90000,
                    false
                ),
                new Customer(
                    4,
                    "Bob",
                    "Brown",
                    "bob.brown@example.com",
                    "456-789-0123",
                    "321 Pine St",
                    "Houston",
                    "USA",
                    new DateTime(1995, 3, 30),
                    new DateTime(2022, 5, 18),
                    55000,
                    true
                ),
                new Customer(
                    5,
                    "Charlie",
                    "Davis",
                    "charlie.davis@example.com",
                    "567-890-1234",
                    "654 Birch St",
                    "Phoenix",
                    "USA",
                    new DateTime(1982, 7, 12),
                    new DateTime(2023, 2, 28),
                    80000,
                    true
                ),
                new Customer(
                    6,
                    "Diana",
                    "Evans",
                    "diana.evans@example.com",
                    "678-901-2345",
                    "987 Cedar St",
                    "Philadelphia",
                    "USA",
                    new DateTime(1992, 9, 20),
                    new DateTime(2021, 11, 9),
                    70000,
                    false
                ),
                new Customer(
                    7,
                    "Ethan",
                    "Green",
                    "ethan.green@example.com",
                    "789-012-3456",
                    "135 Maple St",
                    "San Antonio",
                    "USA",
                    new DateTime(1988, 11, 8),
                    new DateTime(2020, 8, 3),
                    65000,
                    true
                ),
                new Customer(
                    8,
                    "Fiona",
                    "Harris",
                    "fiona.harris@example.com",
                    "890-123-4567",
                    "246 Walnut St",
                    "San Diego",
                    "USA",
                    new DateTime(1975, 4, 18),
                    new DateTime(2018, 4, 12),
                    95000,
                    true
                ),
                new Customer(
                    9,
                    "George",
                    "Clark",
                    "george.clark@example.com",
                    "901-234-5678",
                    "369 Spruce St",
                    "Dallas",
                    "USA",
                    new DateTime(1998, 6, 22),
                    new DateTime(2022, 9, 5),
                    50000,
                    false
                ),
                new Customer(
                    10,
                    "Hannah",
                    "Lewis",
                    "hannah.lewis@example.com",
                    "012-345-6789",
                    "159 Cherry St",
                    "San Jose",
                    "USA",
                    new DateTime(1980, 2, 14),
                    new DateTime(2021, 6, 19),
                    85000,
                    true
                ),
                new Customer(
                    11,
                    "Ian",
                    "Walker",
                    "ian.walker@example.com",
                    "123-456-7890",
                    "753 Willow St",
                    "Toronto",
                    "Canada",
                    new DateTime(1993, 10, 7),
                    new DateTime(2020, 12, 1),
                    72000,
                    true
                ),
                new Customer(
                    12,
                    "Jessica",
                    "Hall",
                    "jessica.hall@example.com",
                    "234-567-8901",
                    "852 Palm St",
                    "Vancouver",
                    "Canada",
                    new DateTime(1987, 1, 29),
                    new DateTime(2019, 9, 25),
                    68000,
                    false
                ),
                new Customer(
                    13,
                    "Kevin",
                    "Allen",
                    "kevin.allen@example.com",
                    "345-678-9012",
                    "456 Oak St",
                    "Montreal",
                    "Canada",
                    new DateTime(1976, 3, 17),
                    new DateTime(2022, 7, 30),
                    78000,
                    true
                ),
                new Customer(
                    14,
                    "Laura",
                    "Young",
                    "laura.young@example.com",
                    "456-789-0123",
                    "963 Pine St",
                    "Ottawa",
                    "Canada",
                    new DateTime(1991, 5, 9),
                    new DateTime(2021, 4, 14),
                    62000,
                    true
                ),
                new Customer(
                    15,
                    "Michael",
                    "King",
                    "michael.king@example.com",
                    "567-890-1234",
                    "741 Birch St",
                    "Calgary",
                    "Canada",
                    new DateTime(1984, 8, 3),
                    new DateTime(2020, 10, 8),
                    88000,
                    false
                )
};
        }

        //private static (string FirstName, string LastName, decimal Salary)PartialCustomer(Customer customer)
        //{
        //    (string FirstName, string LastName, decimal Salary) c =
        //        (customer.FirstName, customer.LastName, customer.Salary);
        //    return c;
        //}
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