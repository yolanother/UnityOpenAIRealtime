using OpenAIRealtime.Data.ServerEvents;
using OpenAIRealtime.EventProcessors;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ThirdParty.OpenAI.Realtime.EventProcessors
{
    public class ErrorEventProcessor : BaseEventProcessorMonoBehaviour<ErrorEvent>
    {
        [SerializeField] private UnityEvent<string> onError = new UnityEvent<string>();
        protected override void OnEventProcessed(ErrorEvent data)
        {
            onError?.Invoke(data.ErrorDetails.Message);
            Debug.LogError($"Error [{data.ErrorDetails.Code}]: {data.ErrorDetails.Message}");
        }
    }
}