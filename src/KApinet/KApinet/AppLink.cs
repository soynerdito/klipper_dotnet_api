using KApinet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace KApinet
{
    public class AppLink
    {
        //public Channel<> MyProperty { get; set; }
        public Channel<IKlippyMessage> CommandChannel { get; set; }
        public Channel<object> ReponseChannel { get; set; }

        public AppLink()
        {
            CommandChannel = Channel.CreateUnbounded<IKlippyMessage>();
            ReponseChannel = Channel.CreateUnbounded<object>();
        }

        public async Task SendCommand<TMessage>(TMessage command)
            where TMessage : IKlippyMessage
        {
            await CommandChannel.Writer.WriteAsync(command);
        }
    }
}
