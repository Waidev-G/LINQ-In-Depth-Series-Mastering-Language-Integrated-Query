using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WaidevEpisodes.Data
{
    public sealed class Csv : ICsv
    {
        private const int TableWidth = 100;
        private readonly ICustomerService _customerService=default!;
        private  string path  = @"D:\WaidevEpisodes\WaidevTest\Episode-2\LinqIntro_Waidev\Data\Output.csv";

        public Csv(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public Csv()
        {
                
        }
        public void Create()
        {
            var customers = new CustomerService().getCustomers();
           // var file = @"D:\WaidevEpisodes\WaidevTest\Episode-2\LinqIntro_Waidev\Data\Output.csv";
            if (File.Exists(path))
                return;
            String separator = ",";
            StringBuilder output = new StringBuilder();
            String[] headings = { "CustomerId", "FirstName", "LastName", "FullName", "Email", "PhoneNumber", "Address", "City", "Country", "DateOfBirth", "RegistrationDate", "IsActive", "Salary" };
            output.AppendLine(string.Join(separator, headings));

            foreach (var customer in customers)
            {
                String[] newLine =  {
                    customer.CustomerId.ToString(),
                    customer.FirstName,
                    customer.LastName,
                    //customer.FullName,
                    customer.Email,
                    customer.PhoneNumber,
                    customer.Address,
                    customer.City,
                    customer.Country,
                    customer.DateOfBirth.ToString(),
                    customer.RegistrationDate.ToString(),
                    customer.IsActive.ToString(),
                    customer.Salary.ToString()
                };
                output.AppendLine(string.Join(separator, newLine));
            }
            try
            {
                File.AppendAllText(path, output.ToString());
                Console.WriteLine("Output.csv created");
            }
            catch 
            {
                Console.WriteLine("Data could not be written to the CSV file.");
                return;
            }
        }
        public IEnumerable<Customer> Read()
        {
            if (!File.Exists(path)) return Enumerable.Empty<Customer>();
            return File.ReadAllLines(path)
                  .Skip(1)
                  .Select(MapCustomer);
                
        }


      


        #region Helpers
        private static Customer MapCustomer(string customerString)
        {
            var customer = customerString.Split(",");
            return new Customer
           (
               customerId: Convert.ToInt32(customer[0]),
               firstName: customer[1],
               lastName: customer[2],

               email: customer[3],
               phoneNumber: customer[4],
               address: customer[5],
               city: customer[6],
               country: customer[7],
               dateOfBirth: Convert.ToDateTime(customer[8]),
               registrationDate: Convert.ToDateTime(customer[9]),
               isActive: Convert.ToBoolean(customer[10]),
               salary: Convert.ToDecimal(customer[11])
           );
        }

        #endregion

        #region Old
        // public void PrintCustomers(IEnumerable<Customer> customers)
        // {
        //     warmup();


        //     foreach (var customer in customers)
        //     {
        //         PrintRow(customer.getCompactCustomer().ToArray());
        //     }
        // }


        // private void warmup()
        // {
        //     Console.Clear();
        //     PrintLine();
        //     PrintRow("CustomerId", "FullName", "Country", "DateOfBirth", "RegistrationDate", "Salary", "IsActive");
        //     PrintLine();
        //     PrintRow("", "", "", "");
        //     PrintRow("", "", "", "");
        //     PrintLine();
        // }
        //private  void PrintLine()
        // {
        //     Console.WriteLine(new string('-', TableWidth));
        // }

        //private  void PrintRow(params string[] columns)
        // {
        //     int width = (TableWidth - columns.Length) / columns.Length;
        //     string row = "|";

        //     foreach (string column in columns)
        //     {
        //         row += AlignCentre(column, width) + "|";
        //     }

        //     Console.WriteLine(row);
        // }

        //  string AlignCentre(string text, int width)
        // {
        //     text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        //     if (string.IsNullOrEmpty(text))
        //     {
        //         return new string(' ', width);
        //     }
        //     else
        //     {
        //         return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        //     }
        // }
        #endregion
    }
}
