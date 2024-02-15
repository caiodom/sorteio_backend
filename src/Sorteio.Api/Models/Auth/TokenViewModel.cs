namespace Sorteio.Api.Models.Auth
{
    public class TokenViewModel
    {
        public string? Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
