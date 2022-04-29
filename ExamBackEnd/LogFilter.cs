using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.WebApi
{
    public class LogFilter : DelegatingHandler, ILogFilter
    {
        private readonly ILogger _logger;
        public LogFilter(ILogger logger)
        {
            _logger = logger;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken).ContinueWith(t =>
            {
                _logger.LogInformation(request.ToString());
                var responseBody = t.Result.Content;
                var requestPath = request.RequestUri.LocalPath;
                return t.Result;
            });
            return response;
        }
    }
}
