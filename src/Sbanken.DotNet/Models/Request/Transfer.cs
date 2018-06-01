namespace Sbanken.DotNet.Models.Request
{
    public class Transfer
    {
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Message { get; set; }
    }
}