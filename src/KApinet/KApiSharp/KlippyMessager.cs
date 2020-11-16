using KApiSharp.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KApiSharp
{
    public class KlippyMessager
    {
		private const byte ETX = 0x03;

        public string Path { get; }

        public KlippyMessager(string path)
        {
            Path = path;
        }
		private async Task<string> ReadResponse(Socket socket)
        {
			StringBuilder responseMessage = new StringBuilder();
			var data = new byte[1];
			do
			{
				var recCount = await socket.ReceiveAsync(new ArraySegment<byte>(data), SocketFlags.None);
				if (data[0] != ETX)
				{
					responseMessage.Append(System.Text.Encoding.ASCII.GetString(data, 0, recCount));
				}
				else
				{
					break;
				}
			} while (true); //(data[0] != ETX);
			return responseMessage.ToString();
		}
		public async Task<string> Send<TMessage>(TMessage message)
			where TMessage : class
        {
			//var unixSocket = "/tmp/klippy_uds";
			using var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
			socket.Connect(new UnixDomainSocketEndPoint(Path));
			var data = new byte[1];
			Console.WriteLine("Connected? who knows");
			var options = new JsonSerializerOptions
			{
				WriteIndented = false,
			};			
			var outData = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(message, options));
			socket.Send(outData);			
			socket.Send(new byte[] { ETX });
			return await ReadResponse(socket);
		}

		//private async Task Sample()
		//{
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
		//		Id = 128,
		//		Method = "info"
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
	}
}
