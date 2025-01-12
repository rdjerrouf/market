namespace market.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public User Sender { get; set; } = default!;
        public User Receiver { get; set; } = default!;
    }
}