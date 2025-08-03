namespace Kanjiro.API.Models.Model
{
    public class ServiceResponse<T>
    {
        public T? ReturnData { get; set; }
        public bool Success { get; set; } = true;
        public string Message {  get; set; } = string.Empty;
    }
}
