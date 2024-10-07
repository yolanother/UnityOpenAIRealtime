using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIRealtime.Data.ServerEvents.Responses
{

    /// <summary>
    /// Represents the response object used in response.done events.
    /// </summary>
    [Serializable]
    public class Response
    {
        /// <summary>
        /// Gets or sets the unique ID of the response.
        /// Example: "resp_001"
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the object type of the response.
        /// Must be "realtime.response".
        /// Example: "realtime.response"
        /// </summary>
        [JsonProperty("object")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the status of the response.
        /// Example: "completed"
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the status details of the response, if available.
        /// Example: null
        /// </summary>
        [JsonProperty("status_details")]
        public string StatusDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of output items from the response.
        /// </summary>
        [JsonProperty("output")]
        public List<ResponseItem> Output { get; set; }

        /// <summary>
        /// Gets or sets the usage details of the response.
        /// </summary>
        [JsonProperty("usage")]
        public Usage Usage { get; set; }
    }

    /// <summary>
    /// Represents a response item within the response output.
    /// </summary>
    [Serializable]
    public class ResponseItem
    {
        /// <summary>
        /// Gets or sets the unique ID of the item.
        /// Example: "msg_006"
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
        /// Example: "assistant"
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
    /// Represents the content within a response item.
    /// </summary>
    [Serializable]
    public class Content
    {
        /// <summary>
        /// Gets or sets the type of the content.
        /// Example: "text"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the text content, if applicable.
        /// Example: "Sure, how can I assist you today?"
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}