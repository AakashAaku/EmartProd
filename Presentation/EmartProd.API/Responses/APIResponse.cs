
namespace EmartProd.API.Responses
{
    public class APIResponse
    {
        public APIResponse(int statusCode,string message =null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultStatusMessage(statusCode);
        }
        public int StatusCode{get;set;}
        public string Message {get;set;}

        private string GetDefaultStatusMessage(int statusCode)
        {
            switch (statusCode)
            {
                case 400: return "You have made BAD REQUEST";
                case 401: return "You are NOT AUTHORIZED";
                case 404: return "Resource you are looking is NOT FOUND";
                case 500: return "You have done somethings wrong on the code so got EXCEPTION";
                //case 500: return "Errors are the path to the dark side.Errors lead to anger.Anger leads to hate.Hate leads to carrer change.";
                default: return null;
            };
        }
    }
}