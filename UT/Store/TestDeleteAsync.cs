using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UT.Store
{
    public class TestDeleteAsync : RepositoryConfig
    {
        public TestDeleteAsync() : base()
        {
        }

        [Fact]
        public async Task DeleteSomeDataWithoutException()
        {
            await SystemUnderTest.DeleteAsync(TestCustomers[0].Id);
        }

        [Fact]
        public async Task DeleteFailsWithException()
        {
            await Assert.ThrowsAsync<Exception>(() => SystemUnderTest.DeleteAsync(Guid.NewGuid()));
        }
    }
}
