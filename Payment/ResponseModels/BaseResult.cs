namespace WorkFlex.Payment.ResponseModels
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;
        public List<BaseError> Errors { get; set; } = new List<BaseError>();

        public void Set(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }

    public class BaseError
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
