using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIRealtime.Data
{
    [Serializable]
    public class BaseEvent
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// Example: "event_789"
        /// </summary>
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// Example: "input_audio_buffer.commit"
        /// </summary>
        [JsonProperty("type")]
        public virtual string Type { get; set; }
    }

    /// <summary>
    /// Represents the item in the conversation.
    /// </summary>
    [Serializable]
    public class Item
    {
        /// <summary>
        /// Gets or sets the identifier of the item.
        /// Example: "msg_001"
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

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
        /// Gets or sets the role of the item.
        /// Example: "user"
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the content of the item, which can be a list of different types of content.
        /// </summary>
        [JsonProperty("content")]
        public List<Content> Content { get; set; }
    }

    /// <summary>
    /// Represents the content inside the conversation item.
    /// </summary>
    [Serializable]
    public class Content
    {
        /// <summary>
        /// Gets or sets the type of the content.
        /// Example: "input_text"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the text content of the message.
        /// Example: "Hello, how are you?"
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}