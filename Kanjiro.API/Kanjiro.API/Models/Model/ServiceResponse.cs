namespace Kanjiro.API.Models.Model
{
    public class ServiceResponse<T>
    {
        public T? ReturnData { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public static ServiceResponse<T> SuccessResponse(T data) => new ServiceResponse<T> { ReturnData = data };
        public static ServiceResponse<T> FailResponse(string message) => new ServiceResponse<T> { Success = false, Message = message };

    }
}
