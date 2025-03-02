using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaidevEpisodes
{
    public class Customer
    {

        #region properties
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }  // New property for salary
       // Computed property to calculate accurate age
        public (int Years ,int Months,int Days) Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;

                // Check if the birthday has occurred this year
                if (DateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }

                // Calculate months and days
                var lastBirthday = DateOfBirth.AddYears(age);
                var months = 0;
                var days = 0;

                if (today > lastBirthday)
                {
                    var monthDifference = today.Month - lastBirthday.Month;
                    if (monthDifference < 0)
                    {
                        monthDifference += 12;
                    }
                    months = monthDifference;

                    var dayDifference = today.Day - lastBirthday.Day;
                    if (dayDifference < 0)
                    {
                        var previousMonth = today.AddMonths(-1);
                        days = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month) - lastBirthday.Day + today.Day;
                    }
                    else
                    {
                        days = dayDifference;
                    }
                }
                int years = age;
                return (years, months , days);
            }
        }
        #endregion

        public Customer()
        {
                
        }
        #region Constructor for creating a new customer
        public Customer(int customerId, string firstName, string lastName, string email, string phoneNumber, string address, string city, string country, DateTime dateOfBirth, DateTime registrationDate, decimal salary, bool isActive = true)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            Country = country;
            DateOfBirth = dateOfBirth;
            RegistrationDate = registrationDate;
            Salary = salary;
            IsActive = isActive;
        }
        #endregion
        public IEnumerable<string> getCompactCustomer()
        {
            yield return CustomerId.ToString();
            yield return FirstName.ToString();
            //yield return Email;
            //yield return City;
            yield return Country.ToString();
            yield return new DateOnly( DateOfBirth.Year,DateOfBirth.Month,DateOfBirth.Day).ToString();
            yield return new DateOnly(RegistrationDate.Year, RegistrationDate.Month, RegistrationDate.Day).ToString();
           
            yield return Salary.ToString();
            yield return IsActive.ToString();

        }
    }



}
