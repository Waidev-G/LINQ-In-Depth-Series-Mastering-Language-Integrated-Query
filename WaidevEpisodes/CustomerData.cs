using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaidevEpisodes
{
    public class CustomerData : ICustomerData
    {
        private readonly ICustomerService _CustomerService;

        public CustomerData(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

       

        public List<Customer> getCusttomer()
        {
            return _CustomerService.getCustomers();
        }

        public void Print(IEnumerable<Customer> filteredList)
        {
            Console.WriteLine($"CustomerId\t\tName\t\tSalary");
            Console.WriteLine($"=====================================================================================");
            foreach (var item in filteredList)
            {
                Console.WriteLine($"{item.CustomerId}\t\t{item.FullName}\t\t{item.Salary}");
            }
        }
    }
}
