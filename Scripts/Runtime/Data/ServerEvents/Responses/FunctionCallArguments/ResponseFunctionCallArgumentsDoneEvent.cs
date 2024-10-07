using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Responses.FunctionCallArguments
{
    /// <summary>
    /// Represents the response.function_call_arguments.done event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseFunctionCallArgumentsDoneEvent = new ResponseFunctionCallArgumentsDoneEvent
    /// {
    ///     EventId = "event_5556",
    ///     ResponseId = "resp_002",
    ///     ItemId = "fc_001",
    ///     OutputIndex = 0,
    ///     CallId = "call_001",
    ///     Arguments = "{\"location\": \"San Francisco\"}"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseFunctionCallArgumentsDoneEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseFunctionCallArgumentsDoneEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.function_call_arguments.done"
        /// </summary>
        public override string Type { get; set; } = "response.function_call_arguments.done";

        /// <summary>
        /// Gets or sets the ID of the response.
        /// Example: "resp_002"
        /// </summary>
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the function call item.
        /// Example: "fc_001"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the index of the output item in the response.
        /// Example: 0
        /// </summary>
        [JsonProperty("output_index")]
        public int OutputIndex { get; set; }

        /// <summary>
        /// Gets or sets the ID of the function call.
        /// Example: "call_001"
        /// </summary>
        [JsonProperty("call_id")]
        public string CallId { get; set; }

        /// <summary>
        /// Gets or sets the final arguments as a JSON string.
        /// Example: "{\"location\": \"San Francisco\"}"
        /// </summary>
        [JsonProperty("arguments")]
        public string Arguments { get; set; }
    }
}
