using DoubTech.ThirdParty.OpenAI.Realtime.Utilities;
using Newtonsoft.Json;
using OpenAIRealtime.Data;
using OpenAIRealtime.Data.ServerEvents;

namespace OpenAIRealtime.EventProcessors
{
    public abstract class BaseEventProcessorMonoBehaviour<T> : BaseStreamerClientMonoBehaviour, IEventProcessor where T : BaseEvent, new()
    {
        public string Type => _eventInstance.Type;
        
        // Reference instance
        private T _eventInstance = new T();
        
        public bool CanProcess(ServerEvent serverEvent)
        {
            if(null == serverEvent) return false;
            return serverEvent.Type == Type;
        }

        public BaseEvent Process(string type, string responseEvent)
        {
            JsonConvert.PopulateObject(responseEvent, _eventInstance);
            OnEventProcessed(_eventInstance);
            return _eventInstance;
        }

        protected abstract void OnEventProcessed(T data);
    }
}