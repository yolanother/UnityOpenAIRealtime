using OpenAIRealtime.Data;
using OpenAIRealtime.Data.ServerEvents;
using UnityEngine;

namespace OpenAIRealtime.EventProcessors
{
    public abstract class MultiEventProcessorMonoBehaviour : MonoBehaviour, IEventProcessor
    {
        private MultiEventProcessor _multiEventProcessor = new MultiEventProcessor();
        protected virtual void Awake()
        {
            OnRegisterEventProcessors(_multiEventProcessor);
        }

        protected abstract void OnRegisterEventProcessors(MultiEventProcessor multiEventProcessor);

        public virtual bool CanProcess(ServerEvent serverEvent)
        {
            return _multiEventProcessor.CanProcess(serverEvent);
        }

        public virtual BaseEvent Process(string type, string response)
        {
            return _multiEventProcessor.Process(type, response);
        }
    }
}