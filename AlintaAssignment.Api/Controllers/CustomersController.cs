using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlintaAssignment.Domain.Models;
using AlintaAssignment.DomainLogic;

namespace AlintaAssignment.Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<Customer>> GetCustomers(string name)
        {
            return await _customerManager.FindCustomerByNameAsync(name);
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
            return await _customerManager.EditCustomerAsync(customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task DeleteCustomer(string id)
        {
            await _customerManager.DeleteCustomer(id);
        }
    }
}
