using AlintaAssignment.Domain.Models;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace UT.DomainLogic
{
    public class TestFindCustomers: CustomerManagerConfig
    {
        public TestFindCustomers(): base()
        {
        }
        [Fact]
        public async Task ReturnEmptyWhenNoDataReturnedFromRepoAsync()
        {
            MockUnitOfWOrk.Setup(p => p.CustomerRepository.FindByConditionAsync(It.IsAny<Expression<Func<Customer, bool>>>()))
                .ReturnsAsync(() => new List<Customer>());
            var result = await SystemUnderTest.FindCustomerByNameAsync("Arnab");

            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnEmptyWhenSomeDataReturnedFromRepoAsync()
        {
            MockUnitOfWOrk.Setup(p => p.CustomerRepository.FindByConditionAsync(It.IsAny<Expression<Func<Customer, bool>>>()))
                .ReturnsAsync(() => TestCustomers);
            var result = await SystemUnderTest.FindCustomerByNameAsync("Arnab");

            Assert.Equal(3, result.Count());
            Assert.Equal(TestCustomers[0], result.First());
        }
    }
}
