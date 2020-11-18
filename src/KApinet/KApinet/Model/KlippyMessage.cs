using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KApinet.Model
{
    public class KlippyMessage<T> : KlippySimpleMessage
		where T : class, new()
    {
	
		[JsonPropertyName("params")]
		public T Parameters { get; set; } = new T();
	}
}
