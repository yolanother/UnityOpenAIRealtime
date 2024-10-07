using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Common
{
    /// <summary>
    /// Represents a content part in a response.
    /// 
    /// Usage example:
    /// var contentPart = new ContentPart
    /// {
    ///     Type = "text",
    ///     Text = "Sample text"
    /// };
    /// </summary>
    [Serializable]
    public class ContentPart
    {
        /// <summary>
        /// Gets or sets the type of the content part.
        /// Example: "text"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the text content, if applicable.
        /// Example: "Sample text"
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}