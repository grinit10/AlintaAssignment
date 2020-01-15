using System.Linq;
using Xunit;

namespace UT.Store
{
    public class TestUpdateAsync : RepositoryConfig
    {
        public TestUpdateAsync() : base()
        {
        }

        [Fact]
        public void EditSomeData()
        {
            TestCustomers[0].LastName = "LastName";
            SystemUnderTest.Update(TestCustomers[0]);

            Assert.NotNull(MockDbContext.Object.Customers.Where(c => c.LastName == "LastName"));
        }
    }
}
