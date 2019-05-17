using System;
using System.Net;
using Newtonsoft.Json;
using SurviveOnSotka.DataAccess.RateReviews;

namespace SurviveOnSotka.Middlewares
{
    public class ErrorDetails
    {
        public  int StatusCode { get; }
        public  string Message { get; }
        private ErrorDetails(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public static ErrorDetails GetErrorDetailsByException(Exception exception)
        {
            var message = exception.Message;
            var statusCode = (int)HttpStatusCode.InternalServerError;
            switch (exception)
            {
                case CannotCreateOrUpdateRateReviewException _:
                    message = exception.Message;
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }
            return new ErrorDetails(message,statusCode);
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}