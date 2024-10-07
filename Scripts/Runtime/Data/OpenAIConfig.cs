using UnityEngine;

namespace OpenAIRealtime.Data
{
    [CreateAssetMenu(fileName = "OpenAIConfig", menuName = "AI/Open AI Config")]
    public class OpenAIConfig : ScriptableObject
    {
        [SerializeField] public string apiUrl = "wss://api.openai.com/v1/realtime";
        [SerializeField] public string apiKey = "YOUR_OPENAI_API_KEY";
        [SerializeField] public string model = "gpt-4o-realtime-preview-2024-10-01";
    }
}