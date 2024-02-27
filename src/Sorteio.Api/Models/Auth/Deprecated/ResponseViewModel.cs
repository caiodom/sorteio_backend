namespace Sorteio.Api.Models.Auth.Deprecated
{
    public class ResponseViewModel
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
