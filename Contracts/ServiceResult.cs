using System.Net;

namespace Contracts
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }
    public class ServiceResult<TData> : ServiceResult
    {
        public TData? Data { get; set; }
    }
}
