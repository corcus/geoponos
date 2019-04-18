using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Dto.UseCaseResponses
{
    public abstract class BaseUseCaseResponse
    {
        public bool Success { get; }
        public string Message { get; }

        protected BaseUseCaseResponse(bool success = false, string message = null)
        {
            this.Success = success;
            this.Message = message;
        }
    }   
}
