using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlintaAssignment.Domain.Models;
using AlintaAssignment.DomainLogic;
using AlintaEnergy.WebAPi.Extensions;

namespace AlintaEnergy.WebApi.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(CustomLoggingExceptionFilter))]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> FindCustomers(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var customers = await _customerManager.FindCustomerByNameAsync(name);
            if (customers == null)
                return NotFound();

            return Ok(customers);
        }

        // PUT: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<ActionResult<Guid>> PutCustomer(Customer customer)
        {
            var updatedId = await _customerManager.EditCustomerAsync(customer);
            if (updatedId == null)
                return BadRequest();

            return Ok(updatedId);
        }

        // POST: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Guid>> PostCustomer(Customer customer)
        {
            return await _customerManager.AddCustomerAsync(customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteCustomer(string id)
        {
            var DeletedId = await _customerManager.DeleteCustomerAsync(id);
            return DeletedId;
        }
    }
}
