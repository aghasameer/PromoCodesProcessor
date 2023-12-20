using System.Net;
using System.Text.Json.Serialization;

namespace PromoCodesProcessor.Models
{
    public class Response
    {
        //public bool issuccess { get; set; }
        [JsonIgnore]
        public HttpStatusCode statuscode { get; set; } = HttpStatusCode.OK;
        
        public string message { get; set; }
        public object? result { get; set; }

        public Response()
        {
            message = this.statuscode.ToString();
        }
    }
}
