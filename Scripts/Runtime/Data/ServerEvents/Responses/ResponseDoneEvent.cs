using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OpenAIRealtime.Data.ServerEvents.Responses
{
    /// <summary>
    /// Represents the response.done event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseDoneEvent = new ResponseDoneEvent
    /// {
    ///     EventId = "event_3132",
    ///     Response = new Response
    ///     {
    ///         Id = "resp_001",
    ///         ObjectType = "realtime.response",
    ///         Status = "completed",
    ///         StatusDetails = null,
    ///         Output = new List<ResponseItem>
    ///         {
    ///             new ResponseItem
    ///             {
    ///                 Id = "msg_006",
    ///                 ObjectType = "realtime.item",
    ///                 Type = "message",
    ///                 Status = "completed",
    ///                 Role = "assistant",
    ///                 Content = new List<Content>
    ///                 {
    ///                     new Content
    ///                     {
    ///                         Type = "text",
    ///                         Text = "Sure, how can I assist you today?"
    ///                     }
    ///                 }
    ///             }
    ///         },
    ///         Usage = new Usage
    ///         {
    ///             TotalTokens = 50,
    ///             InputTokens = 20,
    ///             OutputTokens = 30
    ///         }
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseDoneEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseDoneEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.done"
        /// </summary>
        public override string Type { get; set; } = "response.done";

        /// <summary>
        /// Gets or sets the response resource.
        /// </summary>
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    /// <summary>
    /// Represents the usage details of the response.
    /// </summary>
    [Serializable]
    public class Usage
    {
        /// <summary>
        /// Gets or sets the total number of tokens used.
        /// Example: 50
        /// </summary>
        [JsonProperty("total_tokens")]
        public int TotalTokens { get; set; }

        /// <summary>
        /// Gets or sets the number of input tokens used.
        /// Example: 20
        /// </summary>
        [JsonProperty("input_tokens")]
        public int InputTokens { get; set; }

        /// <summary>
        /// Gets or sets the number of output tokens used.
        /// Example: 30
        /// </summary>
        [JsonProperty("output_tokens")]
        public int OutputTokens { get; set; }
    }
}
