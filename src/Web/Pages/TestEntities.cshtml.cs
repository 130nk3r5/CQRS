using System.Threading.Tasks;
using Application.TestEntities.Commands;
using Application.TestEntities.Models;
using Application.TestEntities.Queries;
using Domain.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
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

        public async Task<IActionResult> Post(CreateTestEntityCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ? RedirectToPage("Index") : (IActionResult) Page();
        }
    }
}
