using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Conversations
{
    /// <summary>
    /// Represents the conversation.created event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var conversationCreatedEvent = new ConversationCreatedEvent
    /// {
    ///     EventId = "event_9101",
    ///     Conversation = new Conversation
    ///     {
    ///         Id = "conv_001",
    ///         ObjectType = "realtime.conversation"
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(conversationCreatedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationCreatedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "conversation.created"
        /// </summary>
        public override string Type { get; set; } = "conversation.created";

        /// <summary>
        /// Gets or sets the conversation object that was created.
        /// </summary>
        [JsonProperty("conversation")]
        public Conversation Conversation { get; set; }
    }

    /// <summary>
    /// Represents the conversation object used in conversation-related events.
    /// </summary>
    [Serializable]
    public class Conversation
    {
        /// <summary>
        /// Gets or sets the unique ID of the conversation.
        /// Example: "conv_001"
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the object type of the conversation.
        /// Must be "realtime.conversation".
        /// Example: "realtime.conversation"
        /// </summary>
        [JsonProperty("object")]
        public string ObjectType { get; set; }
    }
}