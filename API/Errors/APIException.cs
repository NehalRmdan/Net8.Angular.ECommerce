using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class APIException : APIResponse
    {
        public string Details { get; set; }
        public APIException(int statusCode, string message = null, string details= null) 
        : base(statusCode, message)
        {
            Details= details;
        }
    }
}