using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KApiSharp.Model
{
    public class KlippySimpleMessage : IKlippyMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("method")]
        public string Method { get; set; }
    }
}
