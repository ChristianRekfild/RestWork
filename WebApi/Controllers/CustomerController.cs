using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.LocalDB;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        [HttpGet("{id:long}")]
        public async Task<Customer> GetCustomerAsync([FromRoute] long id)
        {
            Customer customer = Storage.GetCustomers().FirstOrDefault(x => x.Id == id);

            return customer;
        }

        [HttpPost("")]
        public async Task<long> CreateCustomerAsync([FromBody] Customer customer)
        {
            long newId = Storage.GetCustomers().Max(x => x.Id) + 1;

            Storage.AddCustomer(new Customer()
            {
                Id = newId,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname
            });

            return newId;
        }

    }
}