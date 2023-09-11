using MsngBack.Models.Conversation;
using MsngBack.Models.User;

namespace MsngBack.Models.Message;

public class MessageBase
{
    public Guid Id { get; init; }
    public string Content { get; set; } = String.Empty;         // TODO: can be made spatial class 
    public DateTime SendTime { get; init; }
    
    public required ConversationBase Conversation { get; init; }
    public required UserBase Sender { get; init; }
}