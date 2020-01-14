using AlintaAssignment.Domain.Models;
using AlintaAssignment.DomainLogic;
using AlintaAssignment.Store;
using AutoFixture;
using Moq;
using System.Collections.Generic;

namespace UT.DomainLogic
{
    public class CustomerManagerConfig : BaseTest
    {
        protected List<Customer> TestCustomers { get; set; }
        protected Mock<IUnitOfWork> MockUnitOfWOrk { get; set; }
        protected CustomerManager SystemUnderTest { get; set; }

        protected CustomerManagerConfig()
        {
            base.SetUp();
            TestCustomers = new List<Customer>();
            TestCustomers.AddRange(BaseFixture.CreateMany<Customer>(3));
            MockUnitOfWOrk = new Mock<IUnitOfWork>();
            SystemUnderTest = new CustomerManager(MockUnitOfWOrk.Object);
        }
    }
}