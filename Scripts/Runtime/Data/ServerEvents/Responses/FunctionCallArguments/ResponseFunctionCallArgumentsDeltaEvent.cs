using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Responses.FunctionCallArguments
{
    /// <summary>
    /// Represents the response.function_call_arguments.delta event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseFunctionCallArgumentsDeltaEvent = new ResponseFunctionCallArgumentsDeltaEvent
    /// {
    ///     EventId = "event_5354",
    ///     ResponseId = "resp_002",
    ///     ItemId = "fc_001",
    ///     OutputIndex = 0,
    ///     CallId = "call_001",
    ///     Delta = "{\"location\": \"San\""
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseFunctionCallArgumentsDeltaEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseFunctionCallArgumentsDeltaEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.function_call_arguments.delta"
        /// </summary>
        public override string Type { get; set; } = "response.function_call_arguments.delta";

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
        /// Gets or sets the arguments delta as a JSON string.
        /// Example: "{\"location\": \"San\""
        /// </summary>
        [JsonProperty("delta")]
        public string Delta { get; set; }
    }
}
