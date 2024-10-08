using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAIRealtime.Data.ServerEvents;

namespace DoubTech.ThirdParty.OpenAI.Realtime.Data.Common
{
    /// <summary>
    /// Represents the session object used in various session-related events.
    /// 
    /// Usage example:
    /// var session = new Session
    /// {
    ///     Id = "sess_001",
    ///     ObjectType = "realtime.session",
    ///     Model = "gpt-4o-realtime-preview-2024-10-01",
    ///     Modalities = new List<string> { "text", "audio" },
    ///     Instructions = "",
    ///     Voice = "alloy",
    ///     InputAudioFormat = "pcm16",
    ///     OutputAudioFormat = "pcm16",
    ///     InputAudioTranscription = null,
    ///     TurnDetection = new TurnDetection
    ///     {
    ///         Type = "server_vad",
    ///         Threshold = 0.5f,
    ///         PrefixPaddingMs = 300,
    ///         SilenceDurationMs = 200
    ///     },
    ///     Tools = new List<Tool>(),
    ///     ToolChoice = "auto",
    ///     Temperature = 0.8f,
    ///     MaxOutputTokens = null
    /// };
    /// </summary>
    [Serializable]
    public class Session
    {
        /// <summary>
        /// Gets or sets the default model used for this session.
        /// Example: "gpt-4o-realtime-preview-2024-10-01"
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; } = "gpt-4o-realtime-preview-2024-10-01";

        /// <summary>
        /// Gets or sets the set of modalities the model can respond with.
        /// Example: ["text", "audio"]
        /// </summary>
        [JsonProperty("modalities")]
        public List<string> Modalities { get; set; } = new List<string> { "text", "audio" };

        /// <summary>
        /// Gets or sets the default system instructions for this session.
        /// Example: ""
        /// </summary>
        [JsonProperty("instructions")]
        public string Instructions { get; set; } = "Please assist the user.";

        /// <summary>
        /// Gets or sets the voice the model uses to respond.
        /// Example: "alloy"
        /// </summary>
        [JsonProperty("voice")]
        public string Voice { get; set; } = "alloy";

        /// <summary>
        /// Gets or sets the format of input audio.
        /// Example: "pcm16"
        /// </summary>
        [JsonProperty("input_audio_format")]
        public string InputAudioFormat { get; set; } = "pcm16";

        /// <summary>
        /// Gets or sets the format of output audio.
        /// Example: "pcm16"
        /// </summary>
        [JsonProperty("output_audio_format")]
        public string OutputAudioFormat { get; set; } = "pcm16";

        /// <summary>
        /// Gets or sets the input audio transcription configuration.
        /// Can be null.
        /// </summary>
        [JsonProperty("input_audio_transcription")]
        public InputAudioTranscription InputAudioTranscription { get; set; } = new InputAudioTranscription();

        /// <summary>
        /// Gets or sets the turn detection configuration.
        /// </summary>
        [JsonProperty("turn_detection")]
        public TurnDetection TurnDetection { get; set; }

        /// <summary>
        /// Gets or sets the tools available to the model.
        /// </summary>
        [JsonProperty("tools")]
        public List<Tool> Tools { get; set; }

        /// <summary>
        /// Gets or sets how the model chooses tools.
        /// Example: "auto"
        /// </summary>
        [JsonProperty("tool_choice")]
        public string ToolChoice { get; set; } = "auto";

        /// <summary>
        /// Gets or sets the sampling temperature.
        /// Example: 0.8
        /// </summary>
        [JsonProperty("temperature")]
        public float Temperature { get; set; } = 0.8f;
    }

    /// <summary>
    /// Represents the turn detection configuration.
    /// </summary>
    [Serializable]
    public class TurnDetection
    {
        /// <summary>
        /// Gets or sets the type of turn detection.
        /// Example: "server_vad"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the threshold for turn detection.
        /// Example: 0.5
        /// </summary>
        [JsonProperty("threshold")]
        public float Threshold { get; set; }

        /// <summary>
        /// Gets or sets the prefix padding in milliseconds.
        /// Example: 300
        /// </summary>
        [JsonProperty("prefix_padding_ms")]
        public int PrefixPaddingMs { get; set; }

        /// <summary>
        /// Gets or sets the silence duration in milliseconds.
        /// Example: 200
        /// </summary>
        [JsonProperty("silence_duration_ms")]
        public int SilenceDurationMs { get; set; }
    }

    /// <summary>
    /// Represents a tool available in the session.
    /// </summary>
    [Serializable]
    public class Tool
    {
        /// <summary>
        /// Gets or sets the type of tool.
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
        /// Gets or sets the description of the tool.
        /// Example: "Calculates the sum of two numbers."
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parameters required by the tool.
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
        /// Gets or sets the type of the parameters.
        /// Example: "object"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the properties for the parameters.
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<string, Property> Properties { get; set; }

        /// <summary>
        /// Gets or sets the required parameters.
        /// Example: ["a", "b"]
        /// </summary>
        [JsonProperty("required")]
        public List<string> Required { get; set; }
    }

    /// <summary>
    /// Represents a property used in the tool parameters.
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
