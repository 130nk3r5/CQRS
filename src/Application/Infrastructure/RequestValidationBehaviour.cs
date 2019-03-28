using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Infrastructure
{
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);

            var validationFailures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(v => v.Errors)
                .Where(failure => failure != null)
                .ToArray();

            if (validationFailures.Any())
            {
                throw new ValidationException(validationFailures);
            }

            return next();
        }
    }
}
