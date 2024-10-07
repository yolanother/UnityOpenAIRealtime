﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIRealtime.Data.ClientEvents.Sessions
{
    /// <summary>
    /// Represents the session.update event structure.
    /// 
    /// Inherits from BaseClientEvent.
    /// 
    /// Usage example:
    /// var sessionUpdate = new SessionUpdateEvent
    /// {
    ///     EventId = "event_123",
    ///     Session = new Session
    ///     {
    ///         Modalities = new List<string> { "text", "audio" },
    ///         Instructions = "Your knowledge cutoff is 2023-10. You are a helpful assistant.",
    ///         Voice = "alloy",
    ///         InputAudioFormat = "pcm16",
    ///         OutputAudioFormat = "pcm16",
    ///         InputAudioTranscription = new InputAudioTranscription
    ///         {
    ///             Enabled = true,
    ///             Model = "whisper-1"
    ///         },
    ///         TurnDetection = new TurnDetection
    ///         {
    ///             Type = "server_vad",
    ///             Threshold = 0.5f,
    ///             PrefixPaddingMs = 300,
    ///             SilenceDurationMs = 200
    ///         },
    ///         Tools = new List<Tool>
    ///         {
    ///             new Tool
    ///             {
    ///                 Type = "function",
    ///                 Name = "get_weather",
    ///                 Description = "Get the current weather for a location.",
    ///                 Parameters = new Parameters
    ///                 {
    ///                     Type = "object",
    ///                     Properties = new Properties
    ///                     {
    ///                         Location = new Location
    ///                         {
    ///                             Type = "string"
    ///                         }
    ///                     },
    ///                     Required = new List<string> { "location" }
    ///                 }
    ///             }
    ///         },
    ///         ToolChoice = "auto",
    ///         Temperature = 0.8f,
    ///         MaxOutputTokens = null
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(sessionUpdate, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class SessionUpdateEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseClientEvent to specify this event type.
        /// Example: "session.update"
        /// </summary>
        public override string Type { get; set; } = "session.update";

        /// <summary>
        /// Gets or sets the session object which contains session-specific details.
        /// </summary>
        [JsonProperty("session")]
        public Session Session { get; set; }
    }

    /// <summary>
    /// Represents session details.
    /// </summary>
    [Serializable]
    public class Session
    {
        /// <summary>
        /// Gets or sets the modalities of the session.
        /// Example: ["text", "audio"]
        /// </summary>
        [JsonProperty("modalities")]
        public List<string> Modalities { get; set; }

        /// <summary>
        /// Gets or sets the session instructions.
        /// Example: "Your knowledge cutoff is 2023-10. You are a helpful assistant."
        /// </summary>
        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the voice type.
        /// Example: "alloy"
        /// </summary>
        [JsonProperty("voice")]
        public string Voice { get; set; }

        /// <summary>
        /// Gets or sets the input audio format.
        /// Example: "pcm16"
        /// </summary>
        [JsonProperty("input_audio_format")]
        public string InputAudioFormat { get; set; }

        /// <summary>
        /// Gets or sets the output audio format.
        /// Example: "pcm16"
        /// </summary>
        [JsonProperty("output_audio_format")]
        public string OutputAudioFormat { get; set; }

        /// <summary>
        /// Gets or sets the input audio transcription details.
        /// </summary>
        [JsonProperty("input_audio_transcription")]
        public InputAudioTranscription InputAudioTranscription { get; set; }

        /// <summary>
        /// Gets or sets the turn detection details.
        /// </summary>
        [JsonProperty("turn_detection")]
        public TurnDetection TurnDetection { get; set; }

        /// <summary>
        /// Gets or sets the list of tools available in the session.
        /// </summary>
        [JsonProperty("tools")]
        public List<Tool> Tools { get; set; }

        /// <summary>
        /// Gets or sets the tool choice type.
        /// Example: "auto"
        /// </summary>
        [JsonProperty("tool_choice")]
        public string ToolChoice { get; set; }

        /// <summary>
        /// Gets or sets the temperature value for the session.
        /// Example: 0.8
        /// </summary>
        [JsonProperty("temperature")]
        public float Temperature { get; set; }

        /// <summary>
        /// Gets or sets the max output tokens, which can be null.
        /// </summary>
        [JsonProperty("max_output_tokens")]
        public object MaxOutputTokens { get; set; }
    }

    /// <summary>
    /// Represents input audio transcription settings.
    /// </summary>
    [Serializable]
    public class InputAudioTranscription
    {
        /// <summary>
        /// Gets or sets whether transcription is enabled.
        /// Example: true
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the transcription model.
        /// Example: "whisper-1"
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }
    }

    /// <summary>
    /// Represents turn detection settings.
    /// </summary>
    [Serializable]
    public class TurnDetection
    {
        /// <summary>
        /// Gets or sets the turn detection type.
        /// Example: "server_vad"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the threshold value for voice activity detection.
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
    /// Represents a tool used in the session.
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
        /// Example: "get_weather"
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tool description.
        /// Example: "Get the current weather for a location."
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
        /// Gets or sets the parameter type.
        /// Example: "object"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the properties required for the tool.
        /// </summary>
        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        /// <summary>
        /// Gets or sets the required parameters list.
        /// Example: ["location"]
        /// </summary>
        [JsonProperty("required")]
        public List<string> Required { get; set; }
    }

    /// <summary>
    /// Represents the properties of a tool.
    /// </summary>
    [Serializable]
    public class Properties
    {
        /// <summary>
        /// Gets or sets the location property type.
        /// Example: "string"
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    /// <summary>
    /// Represents the location property.
    /// </summary>
    [Serializable]
    public class Location
    {
        /// <summary>
        /// Gets or sets the location type.
        /// Example: "string"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

}