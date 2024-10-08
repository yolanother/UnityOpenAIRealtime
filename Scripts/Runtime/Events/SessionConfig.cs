using DoubTech.ThirdParty.OpenAI.Realtime.Data.ClientEvents.Sessions;
using DoubTech.ThirdParty.OpenAI.Realtime.Data.Common;
using DoubTech.ThirdParty.OpenAI.Realtime.Data.ServerEvents.Sessions;
using OpenAIRealtime.EventProcessors;
using UnityEngine;

namespace DoubTech.ThirdParty.OpenAI.Realtime.Events
{
    public enum Voices
    {
        Default,
        Alloy,
        Echo,
        Shimmer
    }
    
    /// <summary>
    /// A component to change session settings including instructions.
    /// </summary>
    public class SessionConfig : MultiEventProcessorMonoBehaviour
    {
        /// <summary>
        /// Instructions to be used for the session, loaded from a text asset.
        /// </summary>
        [Header("Session Instructions")]
        [Tooltip("Text asset containing the instructions for the session.")]
        [SerializeField] private TextAsset instructions;

        /// <summary>
        /// Voice setting for the session.
        /// </summary>
        [Header("Voice Settings")]
        [Tooltip("Voice setting to be used for the session.")]
        [SerializeField] private Voices voice;
        
        public Session Session { get; private set; }

        /// <summary>
        /// Processes the session creation event and updates the session settings.
        /// </summary>
        /// <param name="data">The session creation event data.</param>
        protected virtual void OnSessionInitialized(Session session)
        {
            Session = session;
            bool modified = false;
            var sessionUpdate = new SessionUpdateEvent
            {
                Session = session
            };
            if (instructions)
            {
                sessionUpdate.Session.Instructions = instructions.text;
                modified = true;
            }

            if (voice != Voices.Default)
            {
                sessionUpdate.Session.Voice = voice.ToString().ToLower();
                modified = true;
            }

            if (modified)
            {
                Streamer.SendEvent(sessionUpdate);
            }
        }

        protected override void OnRegisterEventProcessors(MultiEventProcessor multiEventProcessor)
        {
            multiEventProcessor.Add((SessionCreatedEvent e) =>
            {
                OnSessionInitialized(e.Session);
            });
            multiEventProcessor.Add((SessionUpdatedEvent e) =>
            {
                e.Session = e.Session;
            });
        }
    }
    
    #if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(SessionConfig))]
    public class SessionConfigEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            // Display a json dump of the session settings
            var sessionConfig = target as SessionConfig;
            if (sessionConfig?.Session != null)
            {
                UnityEditor.EditorGUILayout.Space();
                UnityEditor.EditorGUILayout.LabelField("Session Settings", UnityEditor.EditorStyles.boldLabel);
                // Use JsonConvert to pretty print session settings
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(sessionConfig.Session, Newtonsoft.Json.Formatting.Indented);
                UnityEditor.EditorGUILayout.TextArea(json, UnityEditor.EditorStyles.textArea);
            }
        }
    }
    #endif
}