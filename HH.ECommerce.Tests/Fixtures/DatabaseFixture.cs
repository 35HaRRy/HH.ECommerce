using HH.ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace HH.ECommerce.Tests.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public ApplicationContext DContext { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "HHCommerce")
                .Options;

            DContext = new ApplicationContext(options);
        }

        public void Dispose()
        {
            DContext.Dispose();
        }
    }
}
