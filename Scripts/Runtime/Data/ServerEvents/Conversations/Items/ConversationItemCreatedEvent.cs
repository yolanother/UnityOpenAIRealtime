using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OpenAIRealtime.Data.ServerEvents.Conversations.Items
{
    /// <summary>
    /// Represents the conversation.item.created event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var conversationItemCreatedEvent = new ConversationItemCreatedEvent
    /// {
    ///     EventId = "event_1920",
    ///     PreviousItemId = "msg_002",
    ///     Item = new ConversationItem
    ///     {
    ///         Id = "msg_003",
    ///         ObjectType = "realtime.item",
    ///         Type = "message",
    ///         Status = "completed",
    ///         Role = "user",
    ///         Content = new List<Content>
    ///         {
    ///             new Content
    ///             {
    ///                 Type = "input_audio",
    ///                 Transcript = null
    ///             }
    ///         }
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(conversationItemCreatedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationItemCreatedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "conversation.item.created"
        /// </summary>
        public override string Type { get; set; } = "conversation.item.created";

        /// <summary>
        /// Gets or sets the ID of the preceding item.
        /// Example: "msg_002"
        /// </summary>
        [JsonProperty("previous_item_id")]
        public string PreviousItemId { get; set; }

        /// <summary>
        /// Gets or sets the created conversation item.
        /// </summary>
        [JsonProperty("item")]
        public ConversationItem Item { get; set; }
    }

    /// <summary>
    /// Represents a conversation item.
    /// </summary>
    [Serializable]
    public class ConversationItem
    {
        /// <summary>
        /// Gets or sets the unique ID of the item.
        /// Example: "msg_003"
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the object type of the item.
        /// Must be "realtime.item".
        /// Example: "realtime.item"
        /// </summary>
        [JsonProperty("object")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// Example: "message"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the status of the item.
        /// Example: "completed"
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the role associated with the item.
        /// Example: "user"
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the content of the item.
        /// </summary>
        [JsonProperty("content")]
        public List<Content> Content { get; set; }
    }

    /// <summary>
    /// Represents the content of a conversation item.
    /// </summary>
    [Serializable]
    public class Content
    {
        /// <summary>
        /// Gets or sets the type of the content.
        /// Example: "input_audio"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the transcript of the content, if available.
        /// Example: null
        /// </summary>
        [JsonProperty("transcript")]
        public string Transcript { get; set; }
    }
}
