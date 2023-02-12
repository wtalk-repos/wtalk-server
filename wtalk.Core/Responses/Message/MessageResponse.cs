
namespace Wtalk.Core.Responses.Message
{
    public class MessageResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public MessageParticipant Receiver { get; set; }
        public int ReceiverId { get; set; }
        public MessageParticipant Sender { get; set; }
        public int SenderId { get; set; }
    }
}
