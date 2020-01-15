using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace UT.Store
{
    public class TestFindByConditionAsync: RepositoryConfig
    {
        public TestFindByConditionAsync() : base()
        {
        }

        [Fact]
        public async Task ReturnSomeDataAsync()
        {
            var result = await SystemUnderTest.FindByConditionAsync(c => c.Id == TestCustomers[0].Id);

            Assert.Single(result);
            Assert.Equal(TestCustomers[0], result.First());
        }
    }
}
