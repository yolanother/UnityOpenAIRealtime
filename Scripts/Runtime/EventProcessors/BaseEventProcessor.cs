using Newtonsoft.Json;
using OpenAIRealtime.Data;
using OpenAIRealtime.Data.ServerEvents;

namespace OpenAIRealtime.EventProcessors
{
    public abstract class BaseEventProcessor<T> : IEventProcessor where T : BaseEvent, new()
    {
        public string Type => _instance.Type;

        // Reference instance
        private T _instance = new T();

        public bool CanProcess(ServerEvent serverEvent)
        {
            if (null == serverEvent) return false;
            return serverEvent.Type == Type;
        }

        public BaseEvent Process(string type, string responseEvent)
        {
            // Populate the _instance with the json content of the response
            JsonConvert.PopulateObject(responseEvent, _instance);
            OnEventProcessed(_instance);
            return _instance;
        }

        protected abstract void OnEventProcessed(T data);
    }
}