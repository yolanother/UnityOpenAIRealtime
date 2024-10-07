using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Conversations.Items
{
    /// <summary>
    /// Represents the conversation.item.truncated event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var conversationItemTruncatedEvent = new ConversationItemTruncatedEvent
    /// {
    ///     EventId = "event_2526",
    ///     ItemId = "msg_004",
    ///     ContentIndex = 0,
    ///     AudioEndMs = 1500
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(conversationItemTruncatedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationItemTruncatedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "conversation.item.truncated"
        /// </summary>
        public override string Type { get; set; } = "conversation.item.truncated";

        /// <summary>
        /// Gets or sets the ID of the assistant message item that was truncated.
        /// Example: "msg_004"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the index of the content part that was truncated.
        /// Example: 0
        /// </summary>
        [JsonProperty("content_index")]
        public int ContentIndex { get; set; }

        /// <summary>
        /// Gets or sets the duration up to which the audio was truncated, in milliseconds.
        /// Example: 1500
        /// </summary>
        [JsonProperty("audio_end_ms")]
        public int AudioEndMs { get; set; }
    }
}