using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Infrastructure
{
    public class RequestLoggerPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLoggerPreProcessor(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            // TODO: Add user details

            _logger.LogInformation("Request: {Name} {@Request}", requestName, request);

            return Task.CompletedTask;
        }
    }
}
