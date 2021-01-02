using System;

namespace BuyEmAll.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            { 
                400 => "Bad request",
                401 => "Unauthorized",
                404 => "Resource was not found",
                500 => "Try again",
                _=> null
            };
        }
    }
}
