using System;
using Application.Tests.Infrastructure;
using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public TestDbContext Context { get; }

        public IMapper Mapper { get; }

        public QueryTestFixture()
        {
            Context = TestDbContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            TestDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition(CollectionName)]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {
        public const string CollectionName = "QueryCollection";
    }
}