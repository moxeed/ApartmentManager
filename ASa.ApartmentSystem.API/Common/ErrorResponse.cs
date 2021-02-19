using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Common
{
    public class ErrorResponse
    {
        internal ErrorResponse(ModelStateDictionary modelState, string path, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Errors = modelState.ToDictionary(m => m.Key, m => m.Value.Errors.Select(e => e.ErrorMessage));
            Self = path;
            Status = statusCode;
        }
        
        internal ErrorResponse(string error, string path, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Errors = new Dictionary<string, IEnumerable<string>> 
            {
                { "Message", new List<string>{ error }}
            };
            Self = path;
            Status = statusCode;
        }

        public IDictionary<string, IEnumerable<string>> Errors { get; private set; }
        public HttpStatusCode Status { get; private set; }
        public string Self { get; private set; }
    }
}
