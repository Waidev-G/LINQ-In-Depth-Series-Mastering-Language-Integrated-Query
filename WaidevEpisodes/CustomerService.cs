using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaidevEpisodes
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> getCustomers()
        {
            // List to store 100 customers
            List<Customer> customers = new List<Customer>();

            // Random data generation
            Random rand = new Random();

            // Sample data arrays for random selection
            string[] firstNames = { "John", "Jane", "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "Austin" };
            string[] countries = { "USA", "Canada", "UK", "Australia", "Germany", "France", "Spain", "Italy", "India", "Mexico" };

            // Generating 100 customers
            for (int i = 1; i <= 100; i++)
            {
                var firstName = firstNames[rand.Next(firstNames.Length)];
                var lastName = lastNames[rand.Next(lastNames.Length)];
                var email = $"{firstName.ToLower()}.{lastName.ToLower()}@example.com";
                var phoneNumber = $"({rand.Next(100, 999)}) {rand.Next(100, 999)}-{rand.Next(1000, 9999)}";
                var address = $"{rand.Next(1, 9999)} Main St";
                var city = cities[rand.Next(cities.Length)];
                var country = countries[rand.Next(countries.Length)];
                var dateOfBirth = new DateTime(rand.Next(1970, 2000), rand.Next(1, 13), rand.Next(1, 29)); // Random DOB
                var registrationDate = DateTime.Now.AddDays(-rand.Next(1, 1000)); // Random registration date within the last 3 years
                var isActive = rand.Next(0, 2) == 0; // Random active status (true or false)
                var salary = rand.Next(30000, 100000); // Random salary between 30,000 and 100,000

                // Creating and adding a new customer to the list
                customers.Add(new Customer(i, firstName, lastName, email, phoneNumber, address, city, country, dateOfBirth, registrationDate, salary, isActive));
            }
            return customers;

        }

        public IEnumerable<Customer> getAllCustomers()
        {
            // List to store 100 customers
            IEnumerable<Customer> customers = new List<Customer>();

            // Random data generation
            Random rand = new Random();

            // Sample data arrays for random selection
            string[] firstNames = { "John", "Jane", "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "Austin" };
            string[] countries = { "USA", "Canada", "UK", "Australia", "Germany", "France", "Spain", "Italy", "India", "Mexico" };

            // Generating 100 customers
            for (int i = 1; i <= 100; i++)
            {
                var firstName = firstNames[rand.Next(firstNames.Length)];
                var lastName = lastNames[rand.Next(lastNames.Length)];
                var email = $"{firstName.ToLower()}.{lastName.ToLower()}@example.com";
                var phoneNumber = $"({rand.Next(100, 999)}) {rand.Next(100, 999)}-{rand.Next(1000, 9999)}";
                var address = $"{rand.Next(1, 9999)} Main St";
                var city = cities[rand.Next(cities.Length)];
                var country = countries[rand.Next(countries.Length)];
                var dateOfBirth = new DateTime(rand.Next(1970, 2000), rand.Next(1, 13), rand.Next(1, 29)); // Random DOB
                var registrationDate = DateTime.Now.AddDays(-rand.Next(1, 1000)); // Random registration date within the last 3 years
                var isActive = rand.Next(0, 2) == 0; // Random active status (true or false)
                var salary = rand.Next(30000, 100000); // Random salary between 30,000 and 100,000

                // Creating and adding a new customer to the list
             yield return new Customer(i, firstName, lastName, email, phoneNumber, address, city, country, dateOfBirth, registrationDate, salary, isActive);
            }
            //return customers;

        }

    }
}
