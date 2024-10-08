using OpenAIRealtime;
using UnityEngine;

namespace DoubTech.ThirdParty.OpenAI.Realtime.Utilities
{
    public class BaseStreamerClientMonoBehaviour : MonoBehaviour
    {
        private OpenAIRealtimeStreamer _streamer;

        public OpenAIRealtimeStreamer Streamer
        {
            get
            {
                if (!_streamer) _streamer = GetComponentInParent<OpenAIRealtimeStreamer>();
                return _streamer;
            }
            set => _streamer = value;
        }
    }
}