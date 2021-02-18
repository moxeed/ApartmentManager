using System;

namespace Asa.ApartmentManagement.Core.Common
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
