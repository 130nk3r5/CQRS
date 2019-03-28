using System;
using System.Linq;
using Domain.Entities;
using Domain.Enumerations;

namespace Persistence
{
    public static class SeedData
    {
        public static void SeedToDatabase(TestDbContext context)
        {
            if (context.TestEntities.Any())
            {
                return;
            }

            context.TestEntities.AddRange(new[]
            {
                new TestEntity{Id = Guid.NewGuid(), Name = "Test1", Type = TestEntityType.Type1},
                new TestEntity{Id = Guid.NewGuid(), Name = "Test2", Type = TestEntityType.Type1},
                new TestEntity{Id = Guid.NewGuid(), Name = "Test3", Type = TestEntityType.Type2}
            });

            context.SaveChanges();
        }
    }
}
