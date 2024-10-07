using System;
using Newtonsoft.Json;

namespace OpenAIRealtime.Data.ClientEvents.Conversations.Items
{
    /// <summary>
    /// Represents the conversation.item.delete event structure.
    /// 
    /// Inherits from BaseClientEvent.
    /// 
    /// Usage example:
    /// var conversationItemDelete = new ConversationItemDeleteEvent
    /// {
    ///     EventId = "event_901",
    ///     ItemId = "msg_003"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(conversationItemDelete, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationItemDeleteEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseClientEvent to specify this event type.
        /// Example: "conversation.item.delete"
        /// </summary>
        public override string Type { get; set; } = "conversation.item.delete";

        /// <summary>
        /// Gets or sets the identifier of the item to be deleted.
        /// Example: "msg_003"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }
}