using System.Net;

namespace Contracts
{
    public class ServiceResultHandler
    {
        public static ServiceResult Ok(string message = "")
        {
            ServiceResult result = new();
            result.Message = message;
            result.IsSuccess = true;
            result.Status = HttpStatusCode.OK;
            return result;
        }
        public static ServiceResult<TData> Ok<TData>(TData data, string message = "")
        {
            ServiceResult<TData> result = new();
            result.Message = message;
            result.IsSuccess = true;
            result.Status = HttpStatusCode.OK;
            result.Data = data;
            return result;
        }
        public static ServiceResult Failed(string message = "", HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            ServiceResult result = new();
            result.Message = message;
            result.IsSuccess = false;
            result.Status = status;
            return result;
        }

    }
}
