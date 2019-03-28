using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.TestEntities.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.TestEntities.Queries
{
    public class GetTestEntitiesQueryHandler : IRequestHandler<GetTestEntitiesQuery, TestEntityModel[]>
    {
        private readonly TestDbContext _context;
        private readonly IMapper _mapper;

        public GetTestEntitiesQueryHandler(TestDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TestEntityModel[]> Handle(GetTestEntitiesQuery request, CancellationToken cancellationToken)
        {
            var testEntities = await _context.TestEntities
                .Where(e => e.Type == request.Type)
                .ToArrayAsync(cancellationToken);

            return _mapper.Map<TestEntityModel[]>(testEntities);
        }
    }
}
