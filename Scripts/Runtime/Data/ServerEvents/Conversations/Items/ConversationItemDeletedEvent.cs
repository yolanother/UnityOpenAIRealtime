using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Conversations.Items
{
    /// <summary>
    /// Represents the conversation.item.deleted event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var conversationItemDeletedEvent = new ConversationItemDeletedEvent
    /// {
    ///     EventId = "event_2728",
    ///     ItemId = "msg_005"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(conversationItemDeletedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationItemDeletedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "conversation.item.deleted"
        /// </summary>
        public override string Type { get; set; } = "conversation.item.deleted";

        /// <summary>
        /// Gets or sets the ID of the item that was deleted.
        /// Example: "msg_005"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }
}