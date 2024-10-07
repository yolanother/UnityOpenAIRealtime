using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OpenAIRealtime.Data.ServerEvents
{
    /// <summary>
    /// Represents the rate_limits.updated event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var rateLimitsUpdatedEvent = new RateLimitsUpdatedEvent
    /// {
    ///     EventId = "event_5758",
    ///     RateLimits = new List<RateLimit>
    ///     {
    ///         new RateLimit
    ///         {
    ///             Name = "requests",
    ///             Limit = 1000,
    ///             Remaining = 999,
    ///             ResetSeconds = 60
    ///         },
    ///         new RateLimit
    ///         {
    ///             Name = "tokens",
    ///             Limit = 50000,
    ///             Remaining = 49950,
    ///             ResetSeconds = 60
    ///         }
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(rateLimitsUpdatedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class RateLimitsUpdatedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "rate_limits.updated"
        /// </summary>
        public override string Type { get; set; } = "rate_limits.updated";

        /// <summary>
        /// Gets or sets the list of rate limits.
        /// </summary>
        [JsonProperty("rate_limits")]
        public List<RateLimit> RateLimits { get; set; }
    }

    /// <summary>
    /// Represents individual rate limit information.
    /// </summary>
    [Serializable]
    public class RateLimit
    {
        /// <summary>
        /// Gets or sets the name of the rate limit.
        /// Example: "requests"
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the maximum limit.
        /// Example: 1000
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount before the limit resets.
        /// Example: 999
        /// </summary>
        [JsonProperty("remaining")]
        public int Remaining { get; set; }

        /// <summary>
        /// Gets or sets the time in seconds before the limit resets.
        /// Example: 60
        /// </summary>
        [JsonProperty("reset_seconds")]
        public int ResetSeconds { get; set; }
    }
}
