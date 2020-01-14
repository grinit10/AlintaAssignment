using AlintaAssignment.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UT.DomainLogic
{
    public class TestPostCustomers : CustomerManagerConfig
    {
        public TestPostCustomers() : base()
        {
        }

        [Fact]
        public async Task CustomerIsAddedSuccessfully()
        {
            MockUnitOfWOrk.Setup(p => p.CustomerRepository.Create(It.IsAny<Customer>()))
                .Returns(() => TestCustomers[0]);
            MockUnitOfWOrk.Setup(m => m.SaveAsync()).ReturnsAsync(() => new List<Guid>() { TestCustomers[0].Id }.AsEnumerable());

            var result = await SystemUnderTest.AddCustomerAsync(TestCustomers[0]);

            Assert.Equal(TestCustomers[0].Id, result);
        }
    }
}
