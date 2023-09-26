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
        public async Task<IActionResult> GetCustomerAsync([FromRoute] long id)
        {
            Customer customer = Storage.GetCustomers().FirstOrDefault(x => x.Id == id);
            if (customer is null) return NotFound();

            return Ok(customer);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer)
        {
            var existsCustomer = Storage.GetCustomers().FirstOrDefault(x => x.Id == customer.Id);
            if (existsCustomer != null)
                return StatusCode(409);

            Storage.AddCustomer(customer);

            return Ok();
        }

    }
}