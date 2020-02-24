using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Common
{
    public class ServiceError
    {
        public string Message { get; }

        public Exception Exception { get; }

        public ServiceError(string message)
        {
            Message = message;
            Exception = null;
        }

        public ServiceError(Exception ex)
        {
            Message = ex.Message;
            Exception = ex;
        }

        public ServiceError(string message, Exception ex)
        {
            Message = message;
            Exception = ex;
        }
    }
}
