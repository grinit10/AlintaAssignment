using AlintaAssignment.Data;
using AlintaAssignment.Domain.Models;
using AlintaAssignment.Repositories.Store;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UT.Store
{
    public class RepositoryConfig : BaseTest
    {
        protected List<Customer> TestCustomers { get; set; }
        protected Mock<DbSet<Customer>> DbSetTestCustomers { get; set; }
        protected Mock<ICustomerDbContext> MockDbContext { get; set; }
        protected RepositoryBase<Customer> SystemUnderTest { get; set; }

        protected RepositoryConfig()
        {
            base.SetUp();
            TestCustomers = new List<Customer>();
            TestCustomers.AddRange(BaseFixture.CreateMany<Customer>(3));
            MockDbContext = new Mock<ICustomerDbContext>();
            IQueryable<Customer> queryableCustomerList = TestCustomers.AsQueryable();

            DbSetTestCustomers = new Mock<DbSet<Customer>>();
            DbSetTestCustomers.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(queryableCustomerList.Provider);
            DbSetTestCustomers.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(queryableCustomerList.Expression);
            DbSetTestCustomers.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(queryableCustomerList.ElementType);
            DbSetTestCustomers.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(queryableCustomerList.GetEnumerator());

            DbSetTestCustomers.Object.AddRange(TestCustomers);
            SystemUnderTest = new RepositoryBase<Customer>(MockDbContext.Object);

            MockDbContext.Setup(db => db.Set<Customer>()).Returns(() => DbSetTestCustomers.Object);
            MockDbContext.Setup(db => db.Customers).Returns(() => DbSetTestCustomers.Object);
            //MockDbContext.Setup(db => db.Set<Customer>().Remove(TestCustomers[0])).Returns(() => DbSetTestCustomers.Object);
        }
    }
}
