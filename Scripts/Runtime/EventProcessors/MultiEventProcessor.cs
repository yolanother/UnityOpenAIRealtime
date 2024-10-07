using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAIRealtime.Data;
using OpenAIRealtime.Data.ServerEvents;
using UnityEngine;

namespace OpenAIRealtime.EventProcessors
{
    public class MultiEventProcessor : IEventProcessor
    {
        public class ProcessedType
        {
            public BaseEvent instance;
            public Action<BaseEvent> onEventProcessed;
        }
        
        public virtual Dictionary<string, ProcessedType> EventTypes { get; set; } = new Dictionary<string, ProcessedType>();
        
        public MultiEventProcessor(Dictionary<string, ProcessedType> eventTypes = null)
        {
            if(null != eventTypes) EventTypes = eventTypes;
        }
        
        public bool CanProcess(ServerEvent serverEvent)
        {
            if(null == serverEvent) return false;
            return EventTypes.ContainsKey(serverEvent.Type);
        }

        public BaseEvent Process(string type, string response)
        {
            if (EventTypes.TryGetValue(type, out var eventType))
            {
                // Update it with the json content of the response
                JsonConvert.PopulateObject(response, eventType.instance);
                eventType.onEventProcessed(eventType.instance);
                return eventType.instance;
            }
            
            throw new Exception($"Event type {type} not found in EventTypes dictionary.");
        }

        public MultiEventProcessor Add<T>(Action<T> onEventProcessed) where T : BaseEvent
        {
            // Create a type of T and read its type value
            var type = Activator.CreateInstance<T>();
            var processedType = new ProcessedType
            {
                instance = type,
                onEventProcessed = (e) => onEventProcessed(e as T)
            };
            EventTypes.Add(type.Type, processedType);
            return this;
        }
    }
}