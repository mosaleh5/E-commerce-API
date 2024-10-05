using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.HandleResponses
{
    public class Response
    {
        public Response(int statusCode , string? message = null)
        {
            StatusCode = statusCode;
            Message =message ?? GetDefaultMessageForStatusCode(statusCode); 
        }

        public int StatusCode { get; set; }
        public string  Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        //match patten 
          => statusCode switch
          {
              100 => "Continue",
              101 => "Switching Protocols",
              200 => "OK",
              201 => "Created",
              204 => "No Content",
              >= 100 and < 200 => "Informational",
              >= 200 and < 300 => "Success",
              >= 300 and < 400 => "Redirection",
              400 => "Bad Request",
              401 => "Unauthorized",
              403 => "Forbidden",
              404 => "Not Found",
              >= 400 and < 500 => "Client Error",
              500 => "Internal Server Error",
              502 => "Bad Gateway",
              503 => "Service Unavailable",
              >= 500 and < 600 => "Server Error",
              _ => "Unknown Status Code"

          };
        
    }
}
