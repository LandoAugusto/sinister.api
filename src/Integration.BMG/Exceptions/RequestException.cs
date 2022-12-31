using Flurl.Http;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;

namespace Integration.BMG.Exceptions
{

    [Serializable]
    [ExcludeFromCodeCoverage]
    public class RequestException : Exception
    {
        public RequestException()
        {
        }

        public RequestException(string message)
            : base(message)
        {
        }

        public RequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected RequestException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        public string OriginalMessage { get; set; }

        public string Body { get; set; }

        public string Url { get; set; }

        public HttpStatusCode? StatusCode { get; set; }

        public bool ServiceUnavailable => StatusCode.HasValue
                                          && (StatusCode == HttpStatusCode.BadGateway ||
                                              StatusCode == HttpStatusCode.GatewayTimeout ||
                                              StatusCode == HttpStatusCode.Unauthorized ||
                                              StatusCode == HttpStatusCode.ServiceUnavailable);

        public static async Task<RequestException> FromFlurlException(FlurlHttpException fex) => new(fex.Message, fex)
        {
            OriginalMessage = fex.Message,
            Url = fex.Call.Request.Url.ToString(),
            StatusCode = (HttpStatusCode?)fex.Call?.Response?.StatusCode,
            Body = await fex.GetResponseStringAsync(),
        };
    }
}
