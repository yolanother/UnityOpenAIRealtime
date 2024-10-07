using OpenAIRealtime.Data.ClientEvents.Conversations.Items;
using OpenAIRealtime.Data.ClientEvents.Responses;
using UnityEditor;
using UnityEngine;

namespace OpenAIRealtime.Events
{
    public class TextEvent : MonoBehaviour
    {
        [Range(0, 1f)]
        [SerializeField] private float temperature = .8f;
        [SerializeField] private int maxTokens = 1024;
        [SerializeField] private OpenAIRealtimeStreamer streamer;
        
        private static long messageId = 0;
        
        public void SendText(string text)
        {
            /*
             previous_item_id = conversationHistory.Count > 0 ? conversationHistory[conversationHistory.Count - 1].item.id : null,
            item = new Item
            {
                id = "msg_" + conversationHistory.Count,
                objectType = "realtime.item",
                type = "message",
                status = "completed",
                role = "user",
                content = new List<Content>
                {
                    new Content
                    {
                        type = "input_text",
                        text = userText
                    }
                }
            }*/
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
    [CustomEditor(typeof(TextEvent))]
    public class TextEventEditor : Editor
    {
        private string textToSend = "Hello, how are you?";
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var textEvent = (TextEvent) target;
            textToSend = EditorGUILayout.TextField("Text to send", textToSend);
            if (GUILayout.Button("Send"))
            {
                textEvent.SendText(textToSend);
            }
        }
    }
    #endif
}