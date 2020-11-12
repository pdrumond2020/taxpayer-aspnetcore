using Newtonsoft.Json;
using System;
using System.Net;
using Taxpayer.Application.Model.RequestResponse;

namespace Taxpayer.Web.Extensions
{
    public class ErrorDetails
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}