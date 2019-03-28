using System;
using Persistence;

namespace Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly TestDbContext _context;

        public CommandTestBase()
        {
            _context = TestDbContextFactory.Create();
        }

        public void Dispose()
        {
            TestDbContextFactory.Destroy(_context);
        }
    }
}