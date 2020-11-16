using KApiSharp.Model;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace KApinet.Services
{
    /// <summary>
    /// Handles communication with the klippy
    /// </summary>
    public class KlippyLinkService : IHostedService
    {
  //      private async Task Sample()
  //      {
		//	Console.WriteLine("Hello World!");
		//	var unixSocket = "/tmp/klippy_uds";
		//	using var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
		//	socket.Connect(new UnixDomainSocketEndPoint(unixSocket));

		//	var data = new byte[1];
		//	Console.WriteLine("Connected? who knows");
		//	var options = new JsonSerializerOptions
		//	{
		//		WriteIndented = false,
		//	};
		//	var message = JsonSerializer.Serialize(new KlippyMessage<object>()
		//	{
		//		id = 128,
		//		method = "info"
		//	}, options);
		//	//{"id": 123, "method": "objects/list"}		
		//	var outData = System.Text.Encoding.ASCII.GetBytes($"{message}");
		//	//outData = System.Text.Encoding.ASCII.GetBytes("{\"id\": 125, \"method\": \"info\", \"params\": {} }\n");
		//	Console.WriteLine($"{message}{(char)0x3A}");
		//	Console.WriteLine($"{message}{(char)0x3A}".Length);
		//	Console.WriteLine(outData.Length);
		//	Console.WriteLine((char)outData[outData.Length - 1]);
		//	Console.WriteLine("press any key to send data");
		//	Console.ReadKey();
		//	socket.Send(outData);
		//	socket.Send(new byte[] { 0x03 });
		//	// while(true){
		//	byte etx = 0x03;
		//	do
		//	{
		//		var recCount = await socket.ReceiveAsync(new ArraySegment<byte>(data), SocketFlags.None);
		//		//Console.WriteLine($"Received {recCount}");
		//		Console.Write(System.Text.Encoding.ASCII.GetString(data, 0, recCount));
		//	} while (data[0] != etx);
		//	Console.WriteLine("done");
		//}
		public async Task StartAsync(CancellationToken cancellationToken)
        {
			//throw new NotImplementedException();
			await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
			await Task.CompletedTask;
		}
    }
}
