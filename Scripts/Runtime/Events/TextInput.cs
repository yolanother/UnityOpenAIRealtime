using OpenAIRealtime.Data.ClientEvents.Conversations.Items;
using OpenAIRealtime.Data.ClientEvents.Responses;
using UnityEditor;
using UnityEngine;

namespace OpenAIRealtime.Events
{
    public class TextInput : MonoBehaviour
    {
        [Range(0, 1f)]
        [SerializeField] private float temperature = .8f;
        [SerializeField] private int maxTokens = 1024;
        [SerializeField] private OpenAIRealtimeStreamer streamer;
        
        private static long messageId = 0;
        
        public void SendText(string text)
        {
            var id = "msg_" + messageId++;
            var textEvent = new ConversationItemCreateEvent
            {
                Item = new()
                {
                    Id = id,
                    Type = "message",
                    Status = "completed",
                    Role = "user",
                    Content = new()
                    {
                        new()
                        {
                            Type = "input_text",
                            Text = text
                        }
                    }
                }
            };
            streamer.SendEvent(textEvent);
            var createResponse = new ResponseCreateEvent
            {
                Response = new Response()
                {
                    MaxOutputTokens = maxTokens,
                    Temperature = temperature
                }
            };
            streamer.SendEvent(createResponse);
        }
    }
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(TextInput))]
    public class TextEventEditor : Editor
    {
        private string textToSend = "Hello, how are you?";
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var textEvent = (TextInput) target;
            textToSend = EditorGUILayout.TextField("Text to send", textToSend);
            if (GUILayout.Button("Send"))
            {
                textEvent.SendText(textToSend);
            }
        }
    }
    #endif
}