using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Infrastructure
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        private readonly Stopwatch _timer;
        private const int LongRunningRequestThreshold = 500;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > LongRunningRequestThreshold)
            {
                var requestName = typeof(TRequest).Name;

                // TODO: Add user details

                _logger.LogWarning("Analyzr long running request: {Name} ({ElapsedMilliseconds} ms) {@Request}", requestName, _timer.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}
