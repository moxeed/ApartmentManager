using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Common.Extenstions
{
    public static class ApiResponseExtensions
    {
        public static ApiBaseResponse<T> Wrap<T>(this T data, string path, HttpStatusCode statusCode = HttpStatusCode.OK)
            => ApiBaseResponse<T>.Wrap(data, path, statusCode);

    }
}
