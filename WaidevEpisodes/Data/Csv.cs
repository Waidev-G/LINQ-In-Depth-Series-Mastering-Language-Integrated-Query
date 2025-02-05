using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WaidevEpisodes.Data
{
    public class Csv : ICsv
    {
        private readonly ICustomerService _customerService;
        private  string path  = @"D:\WaidevEpisodes\WaidevTest\Episode-2\LinqIntro_Waidev\Data\Output.csv";

        public Csv(ICustomerService customerService)
        {
            _customerService = customerService;
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
            catch (Exception _)
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
    }
}
