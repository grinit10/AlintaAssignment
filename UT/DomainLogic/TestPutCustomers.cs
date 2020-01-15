using AlintaAssignment.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UT.DomainLogic
{
    public class TestPutCustomers : CustomerManagerConfig
    {
        public TestPutCustomers() : base()
        {
        }

        [Fact]
        public async Task CustomerIsUpdatedSuccessfully()
        {
            MockUnitOfWOrk.Setup(p => p.CustomerRepository.Update(It.IsAny<Customer>()));
            MockUnitOfWOrk.Setup(m => m.SaveAsync())
                .ReturnsAsync(() =>
                new List<Guid>() { TestCustomers[0].Id }.AsEnumerable());

            var result = await SystemUnderTest.EditCustomerAsync(TestCustomers[0]);

            Assert.Equal(TestCustomers[0].Id, result);
        }
    }
}
