using Microsoft.AspNetCore.Mvc;
using static OcdServiceMono.Lib.Common.Consts;
using static OcdServiceMono.Lib.Enums.Enums;

namespace OcdServiceMono.Lib.Models
{
    public static class ResponseMessage
    {
        private static OkObjectResult ObjectResult (object data, string message, bool success, int statusCode)
        {
            ResponseResult result = new ResponseResult();
            result.Data = data;
            result.StatusCode = statusCode;
            result.Success = success;
            result.Message = message;
            return new OkObjectResult(result);
        }
        public static OkObjectResult Success(object data = null, string message = Message.SERVICE_SUCCESS, int statusCode = (int)StatusCode.Success)
        {
            return ObjectResult(data, message, true, statusCode);
        }
        public static OkObjectResult Success(object data = null)
        {
            return ObjectResult(data, Message.SERVICE_SUCCESS, true, (int)StatusCode.Success);            
        }
        public static OkObjectResult Success()
        {
            return ObjectResult(null, Message.SERVICE_SUCCESS, true, (int)StatusCode.Success);
        }
        public static OkObjectResult Error(string Message, object data, int statusCode)
        {
            return ObjectResult(null, Message, false, statusCode);
        }
        public static OkObjectResult Error(string Message)
        {
            return ObjectResult(null, Message, false, (int)StatusCode.InternalError);
        }
        public static OkObjectResult Error()
        {
            return ObjectResult(null, Message.SERVICE_ERROR, false, (int)StatusCode.InternalError);
        }
    }
}
