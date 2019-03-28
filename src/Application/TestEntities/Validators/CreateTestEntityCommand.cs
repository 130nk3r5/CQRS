using Application.TestEntities.Commands;
using FluentValidation;

namespace Application.TestEntities.Validators
{
    class CreateTestEntityCommandValidator : AbstractValidator<CreateTestEntityCommand>
    {
        public CreateTestEntityCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
