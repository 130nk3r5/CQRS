using System;
using Domain.Enumerations;

namespace Domain.Entities
{
    public class TestEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TestEntityType Type { get; set; }
    }
}
