using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UT.DomainLogic
{
    public class TestDeleteCustomers : CustomerManagerConfig
    {
        public TestDeleteCustomers() : base()
        {
        }

        [Fact]
        public async Task CustomerIsDeletedSuccessfully()
        {
            MockUnitOfWOrk.Setup(p => p.CustomerRepository.DeleteAsync(It.IsAny<Guid>()));
            MockUnitOfWOrk.Setup(m => m.SaveAsync())
                .ReturnsAsync(() =>
                new List<Guid>() { TestCustomers[0].Id }.AsEnumerable());

            var result = await SystemUnderTest.DeleteCustomerAsync(TestCustomers[0].Id.ToString());

            Assert.Equal(TestCustomers[0].Id, result);
        }
    }
}
