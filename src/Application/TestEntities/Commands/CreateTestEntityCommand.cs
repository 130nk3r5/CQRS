using Application.Infrastructure;
using Application.TestEntities.Models;
using Domain.Enumerations;
using MediatR;

namespace Application.TestEntities.Commands
{
    public class CreateTestEntityCommand : IRequest<CommandResult<TestEntityModel>>
    {
        public string Name { get; set; }

        public TestEntityType Type { get; set; }
    }
}
