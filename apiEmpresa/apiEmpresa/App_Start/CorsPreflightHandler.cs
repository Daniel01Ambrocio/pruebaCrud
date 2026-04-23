using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace apiEmpresa
{
    internal class CorsPreflightHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Options)
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                return Task.FromResult(response);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}