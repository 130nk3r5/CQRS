using Application.TestEntities.Queries;
using Domain.Enumerations;
using FluentValidation;

namespace Application.TestEntities.Validators
{
    public class GetTestEntityQueryValidator : AbstractValidator<GetTestEntitiesQuery>
    {
        public GetTestEntityQueryValidator()
        {
            RuleFor(query => query.Type).NotEqual(TestEntityType.None).WithMessage("You must supply a specific entity type, 'None' won't do");
        }
    }
}
