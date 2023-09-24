using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.LocalDB
{
    public static class Storage
    {
        private static List<Customer> _customerList = new List<Customer>() 
        { 
        new Customer()
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Week"
        },
        };

        public static IEnumerable<Customer> GetCustomers()
        {
            return _customerList;
        }

        public static void AddCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }
    }
}
