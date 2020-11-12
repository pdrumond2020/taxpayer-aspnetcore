using System.Collections.Generic;
using System.Net;

namespace Taxpayer.Application.Model.RequestResponse
{
    public class MessageResponse<TResponse>
    {
        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; }

        public TResponse Data { get; set; }

        public int Count { get; set; }

        public List<Inconsistencies> Inconsistencies { get; set; }
    }
}