using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SafeWater.Application.TestEntities.Models;
using SafeWater.Application.TestEntities.Queries;
using SafeWater.Domain.Enumerations;

namespace SafeWater.Web.Pages
{
    public class TestEntitiesModel : PageModel
    {
        private readonly IMediator _mediator;

        public TestEntitiesModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public TestEntityModel[] Entities { get; set; }

        public async Task OnGet()
        {
            Entities = await _mediator.Send(new GetTestEntitiesQuery {Type = TestEntityType.Type1});
        }
    }
}
