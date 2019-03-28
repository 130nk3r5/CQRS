using System.Threading;
using System.Threading.Tasks;
using Application.TestEntities.Queries;
using Application.Tests.Infrastructure;
using Domain.Enumerations;
using FluentAssertions;
using Xunit;

namespace Application.Tests.TestEntities.Queries
{
    [Collection(QueryCollection.CollectionName)]
    public class GetTestEntitiesQueryHandlerTests
    {
        private readonly QueryTestFixture _fixture;

        public GetTestEntitiesQueryHandlerTests(QueryTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Execute()
        {
            var handler = new GetTestEntitiesQueryHandler(_fixture.Context, _fixture.Mapper);

            var result = await handler.Handle(new GetTestEntitiesQuery{Type = TestEntityType.Type2}, new CancellationToken());

            result.Should().HaveCount(1);
            result[0].Name.Should().Be("Test3");
            result[0].Type.Should().Be(TestEntityType.Type2);
        }
    }
}
