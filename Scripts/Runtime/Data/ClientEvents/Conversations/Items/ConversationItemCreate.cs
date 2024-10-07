using System;
using Newtonsoft.Json;

namespace OpenAIRealtime.Data.ClientEvents.Conversations.Items
{
    /// <summary>
    /// Represents the conversation.item.create event structure.
    /// 
    /// Inherits from BaseClientEvent.
    /// 
    /// Usage example:
    /// var conversationItemCreate = new ConversationItemCreateEvent
    /// {
    ///     EventId = "event_345",
    ///     PreviousItemId = null,
    ///     Item = new Item
    ///     {
    ///         Id = "msg_001",
    ///         Type = "message",
    ///         Status = "completed",
    ///         Role = "user",
    ///         Content = new List<Content>
    ///         {
    ///             new Content
    ///             {
    ///                 Type = "input_text",
    ///                 Text = "Hello, how are you?"
    ///             }
    ///         }
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(conversationItemCreate, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationItemCreateEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseClientEvent to specify this event type.
        /// Example: "conversation.item.create"
        /// </summary>
        public override string Type { get; set; } = "conversation.item.create";

        /// <summary>
        /// Gets or sets the previous item identifier.
        /// Example: null or a previous message ID.
        /// </summary>
        [JsonProperty("previous_item_id")]
        public string PreviousItemId { get; set; }

        /// <summary>
        /// Gets or sets the item object, representing the created conversation item.
        /// </summary>
        [JsonProperty("item")]
        public Item Item { get; set; }
    }
}