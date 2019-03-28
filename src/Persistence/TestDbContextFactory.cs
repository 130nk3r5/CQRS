using Microsoft.EntityFrameworkCore;
using Persistence.Infrastructure;

namespace Persistence
{
    public class TestDbContextFactory : DesignTimeDbContextFactoryBase<TestDbContext>
    {
        public TestDbContextFactory()
            : base("DefaultDatabase")
        {
        }

        protected override TestDbContext CreateNewInstance(DbContextOptions<TestDbContext> options)
        {
            return new TestDbContext(options);
        }
    }
}
