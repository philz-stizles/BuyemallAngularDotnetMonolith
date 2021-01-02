namespace BuyEmAll.API.Errors
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string Detail { get; set; }
        public ApiExceptionResponse(int statusCode, string message = null, string detail = null
            ) : base(statusCode, message)
        {
            Detail = detail;
        }
    }
}
