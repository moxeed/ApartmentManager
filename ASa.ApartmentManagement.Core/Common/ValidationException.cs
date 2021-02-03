using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.Common
{
    public sealed class ValidationException : Exception
    {
        public int ErrorCode { get; }
        public ValidationException(int errorCode, string message, Exception innerExcption = null) : base(message, innerExcption)
        {
            ErrorCode = errorCode;
        }
    }
}
