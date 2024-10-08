using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Meta.Net.NativeWebSocket;
using Newtonsoft.Json;
using OpenAIRealtime.Data;
using OpenAIRealtime.Data.ServerEvents;
using UnityEngine.Events;

namespace OpenAIRealtime
{
    public class OpenAIRealtimeStreamer : MonoBehaviour, IEventSender
    {
        [SerializeField] private OpenAIConfig config;

        private WebSocket ws;
        private StringBuilder responseText = new StringBuilder();

        // List of registered event processors
        private List<IEventProcessor> eventProcessors = new List<IEventProcessor>();

        void Start()
        {
            SetUpWebSocketConnection();
            RegisterEventProcessors();
        }

        async void SetUpWebSocketConnection()
        {
            var headers = new Dictionary<string, string>
            {
                { "Authorization", "Bearer " + config.apiKey },
                { "OpenAI-Beta", "realtime=v1" }
            };

            ws = new WebSocket($"{config.apiUrl}?model={config.model}", headers);

            ws.OnOpen += () => { Debug.Log("Connected to server."); };

            ws.OnMessage += (bytes) =>
            {
                var message = Encoding.UTF8.GetString(bytes);
                Debug.Log(message);

                var responseEvent = JsonConvert.DeserializeObject<ServerEvent>(message);
                if (responseEvent != null)
                {
                    bool processed = false;
                    foreach (var processor in eventProcessors)
                    {
                        if (processor.CanProcess(responseEvent))
                        {
                            processor.Process(responseEvent.Type, message);
                        }
                    }
                }
            };

            ws.OnError += (errorMsg) => { Debug.LogError("WebSocket error: " + errorMsg); };

            ws.OnClose += (closeCode) => { Debug.Log("WebSocket connection closed with code: " + closeCode); };

            await ws.Connect();
        }

        void Update()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            ws?.DispatchMessageQueue();
#endif
        }

        public void SendEvent<T>(T ev) where T : BaseEvent
        {
            if (ws != null && ws.State == WebSocketState.Open)
            {
                var jsonEvent = JsonConvert.SerializeObject(ev);
                ws.SendText(jsonEvent);
            }
        }

        private void RegisterEventProcessors()
        {
            eventProcessors.AddRange(GetComponentsInChildren<IEventProcessor>());
        }

        private async void OnApplicationQuit()
        {
            if (ws != null)
            {
                await ws.Close();
            }
        }

        public void SendEvent(string jsonEvent)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IEventSender
    {
        void SendEvent<T>(T jsonEvent) where T : BaseEvent;
    }

    public interface IEventProcessor
    {
        bool CanProcess(ServerEvent serverEvent);
        BaseEvent Process(string type, string response);
    }
}