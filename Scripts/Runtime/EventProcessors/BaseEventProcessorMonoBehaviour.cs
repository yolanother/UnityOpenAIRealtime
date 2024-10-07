using Newtonsoft.Json;
using OpenAIRealtime.Data;
using OpenAIRealtime.Data.ServerEvents;
using UnityEngine;

namespace OpenAIRealtime.EventProcessors
{
    public abstract class BaseEventProcessorMonoBehaviour<T> : MonoBehaviour, IEventProcessor where T : BaseEvent, new()
    {
        public string Type => _instance.Type;
        
        // Reference instance
        private T _instance = new T();
        
        public bool CanProcess(ServerEvent serverEvent)
        {
            if(null == serverEvent) return false;
            return serverEvent.Type == Type;
        }

        public BaseEvent Process(string type, string responseEvent)
        {
            JsonConvert.PopulateObject(responseEvent, _instance);
            OnEventProcessed(_instance);
            return _instance;
        }

        protected abstract void OnEventProcessed(T data);
    }
}