using System.Threading.Tasks;
using Xunit;
using AlintaAssignment.Domain.Models;
using System;

namespace UT.Store
{
    public class TestCreateAsync : RepositoryConfig
    {
        public TestCreateAsync() : base()
        {
        }

        [Fact]
        public void AddSomeData()
        {
            var id = Guid.NewGuid();
            var result = SystemUnderTest.Create(new Customer { DateOfBirth = DateTime.Now, FirstName = "asd", LastName= "asds", Id = id });

            Assert.Equal(id, result.Id);
        }
    }
}
