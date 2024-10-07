using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIRealtime.Data.ClientEvents.Responses
{
    /// <summary>
    /// Represents the response.create event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseCreate = new ResponseCreateEvent
    /// {
    ///     EventId = "event_234",
    ///     Response = new Response
    ///     {
    ///         Modalities = new List<string> { "text", "audio" },
    ///         Instructions = "Please assist the user.",
    ///         Voice = "alloy",
    ///         OutputAudioFormat = "pcm16",
    ///         Tools = new List<Tool>
    ///         {
    ///             new Tool
    ///             {
    ///                 Type = "function",
    ///                 Name = "calculate_sum",
    ///                 Description = "Calculates the sum of two numbers.",
    ///                 Parameters = new Parameters
    ///                 {
    ///                     Type = "object",
    ///                     Properties = new Properties
    ///                     {
    ///                         A = new Property { Type = "number" },
    ///                         B = new Property { Type = "number" }
    ///                     },
    ///                     Required = new List<string> { "a", "b" }
    ///                 }
    ///             }
    ///         },
    ///         ToolChoice = "auto",
    ///         Temperature = 0.7f,
    ///         MaxOutputTokens = 150
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseCreate, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseCreateEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.create"
        /// </summary>
        public override string Type { get; set; } = "response.create";

        /// <summary>
        /// Gets or sets the response object containing the response details.
        /// </summary>
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    /// <summary>
    /// Represents the response details.
    /// </summary>
    [Serializable]
    public class Response
    {
        /// <summary>
        /// Gets or sets the modalities for the response.
        /// Example: ["text", "audio"]
        /// </summary>
        [JsonProperty("modalities")]
        public List<string> Modalities { get; set; } = new List<string> { "text", "audio" };

        /// <summary>
        /// Gets or sets the response instructions.
        /// Example: "Please assist the user."
        /// </summary>
        [JsonProperty("instructions")]
        public string Instructions { get; set; } = "Please assist the user.";

        /// <summary>
        /// Gets or sets the voice used for the response.
        /// Example: "alloy"
        /// </summary>
        [JsonProperty("voice")]
        public string Voice { get; set; } = "alloy";

        /// <summary>
        /// Gets or sets the output audio format.
        /// Example: "pcm16"
        /// </summary>
        [JsonProperty("output_audio_format")]
        public string OutputAudioFormat { get; set; } = "pcm16";

        /// <summary>
        /// Gets or sets the tools available for the response.
        /// </summary>
        [JsonProperty("tools")]
        public List<Tool> Tools { get; set; }

        /// <summary>
        /// Gets or sets the tool choice for the response.
        /// Example: "auto"
        /// </summary>
        [JsonProperty("tool_choice")]
        public string ToolChoice { get; set; } = "auto";

        /// <summary>
        /// Gets or sets the temperature setting for the response generation.
        /// Example: 0.7
        /// </summary>
        [JsonProperty("temperature")]
        public float Temperature { get; set; } = .7f;

        /// <summary>
        /// Gets or sets the maximum number of output tokens for the response.
        /// Example: 150
        /// </summary>
        [JsonProperty("max_output_tokens")]
        public int MaxOutputTokens { get; set; } = 1024;
    }

    /// <summary>
    /// Represents a tool used in the response.
    /// </summary>
    [Serializable]
    public class Tool
    {
        /// <summary>
        /// Gets or sets the tool type.
        /// Example: "function"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the tool.
        /// Example: "calculate_sum"
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tool description.
        /// Example: "Calculates the sum of two numbers."
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parameters for the tool.
        /// </summary>
        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }
    }

    /// <summary>
    /// Represents the parameters for a tool.
    /// </summary>
    [Serializable]
    public class Parameters
    {
        /// <summary>
        /// Gets or sets the parameter type.
        /// Example: "object"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the properties for the parameters.
        /// </summary>
        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        /// <summary>
        /// Gets or sets the required parameters list.
        /// Example: ["a", "b"]
        /// </summary>
        [JsonProperty("required")]
        public List<string> Required { get; set; }
    }

    /// <summary>
    /// Represents the properties for the parameters of a tool.
    /// </summary>
    [Serializable]
    public class Properties
    {
        /// <summary>
        /// Gets or sets the property for parameter 'a'.
        /// Example: { "type": "number" }
        /// </summary>
        [JsonProperty("a")]
        public Property A { get; set; }

        /// <summary>
        /// Gets or sets the property for parameter 'b'.
        /// Example: { "type": "number" }
        /// </summary>
        [JsonProperty("b")]
        public Property B { get; set; }
    }

    /// <summary>
    /// Represents a single property used in the parameters of a tool.
    /// </summary>
    [Serializable]
    public class Property
    {
        /// <summary>
        /// Gets or sets the type of the property.
        /// Example: "number"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
