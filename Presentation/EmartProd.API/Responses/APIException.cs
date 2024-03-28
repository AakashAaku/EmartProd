namespace EmartProd.API.Responses
{
    public class APIException : APIResponse
    {
        public string Detail {get;set;}
        public APIException(int statusCode, string message = null,string detail=null) 
        : base(statusCode, message)
        {
            Detail = detail;
        }
    }
}