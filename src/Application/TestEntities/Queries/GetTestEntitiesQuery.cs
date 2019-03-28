using Application.TestEntities.Models;
using Domain.Enumerations;
using MediatR;

namespace Application.TestEntities.Queries
{
    public class GetTestEntitiesQuery : IRequest<TestEntityModel[]>
    {
        public TestEntityType Type { get; set; }
    }
}
