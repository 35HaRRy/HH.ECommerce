using HH.ECommerce.Data.Contracts;
using HH.ECommerce.Data.Repositories;

namespace HH.ECommerce.Tests.Fixtures
{
    public class RepositoryFixture : DatabaseFixture
    {
        public IRepositoryManager RepositoryManager;

        public RepositoryFixture()
        {
            RepositoryManager = new RepositoryManager(DContext);
        }
    }
}
