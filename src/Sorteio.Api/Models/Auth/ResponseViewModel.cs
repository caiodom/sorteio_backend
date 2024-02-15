namespace Sorteio.Api.Models.Auth
{
    public class ResponseViewModel
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
