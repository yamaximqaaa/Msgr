namespace MsngBack.Models.Conversation;

public class ConversationBase
{
    public Guid Id { get; init; }
    public string Title { get; set; }
    public bool IsOneToOne { get; set; }
}