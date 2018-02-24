namespace Sbanken.DotNet.Models.Request
{
    public class Transfer
    {
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal Amount { get; set; }
        public string Message { get; set; }
    }
}