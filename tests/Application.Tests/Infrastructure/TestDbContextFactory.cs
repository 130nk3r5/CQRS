using System;
using Domain.Entities;
using Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tests.Infrastructure
{
    public class TestDbContextFactory
    {
        public static TestDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new TestDbContext(options);

            context.Database.EnsureCreated();

            context.TestEntities.AddRange(new[] {
                new TestEntity{Id = Guid.NewGuid(), Name = "Test1", Type = TestEntityType.Type1},
                new TestEntity{Id = Guid.NewGuid(), Name = "Test2", Type = TestEntityType.Type1},
                new TestEntity{Id = Guid.NewGuid(), Name = "Test3", Type = TestEntityType.Type2}
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(TestDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}