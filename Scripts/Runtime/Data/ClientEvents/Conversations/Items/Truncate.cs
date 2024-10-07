using System;
using Newtonsoft.Json;

namespace OpenAIRealtime.Data.ClientEvents.Conversations.Items
{
    /// <summary>
    /// Represents the conversation.item.truncate event structure.
    /// 
    /// Inherits from BaseClientEvent.
    /// 
    /// Usage example:
    /// var conversationItemTruncate = new ConversationItemTruncateEvent
    /// {
    ///     EventId = "event_678",
    ///     ItemId = "msg_002",
    ///     ContentIndex = 0,
    ///     AudioEndMs = 1500
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(conversationItemTruncate, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationItemTruncateEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseClientEvent to specify this event type.
        /// Example: "conversation.item.truncate"
        /// </summary>
        public override string Type { get; set; } = "conversation.item.truncate";

        /// <summary>
        /// Gets or sets the identifier of the item that is being truncated.
        /// Example: "msg_002"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the index of the content in the item that is being truncated.
        /// Example: 0
        /// </summary>
        [JsonProperty("content_index")]
        public int ContentIndex { get; set; }

        /// <summary>
        /// Gets or sets the timestamp in milliseconds indicating where the audio ends after truncation.
        /// Example: 1500
        /// </summary>
        [JsonProperty("audio_end_ms")]
        public int AudioEndMs { get; set; }
    }
}