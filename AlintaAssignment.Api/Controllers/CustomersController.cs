using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlintaAssignment.Domain.Models;
using AlintaAssignment.DomainLogic;
using AlintaAssignment.Api.Extensions;

namespace AlintaAssignment.Api.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomLoggingExceptionFilter))]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(string name)
        {
           var customers = await _customerManager.FindCustomerByNameAsync(name);
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(customers);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<Guid> PutCustomer(Customer customer)
        {
            return await _customerManager.EditCustomerAsync(customer);
        }

        // POST: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<Guid> PostCustomer(Customer customer)
        {
            return await _customerManager.AddCustomerAsync(customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task DeleteCustomer(string id)
        {
            await _customerManager.DeleteCustomer(id);
        }
    }
}
