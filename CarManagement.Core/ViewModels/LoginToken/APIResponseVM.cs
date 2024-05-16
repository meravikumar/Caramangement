namespace CarManagement.Core.ViewModels.LoginToken
{
    public class APIResponseVM<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T ? Data { get; set; }
    }
}
