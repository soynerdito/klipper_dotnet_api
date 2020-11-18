using Microsoft.Extensions.Logging;
using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KApinet
{
	/// <summary>
	/// Reads and writes data to the uds port
	/// </summary>
    public class KlippyMessager
    {
		/// <summary>
		/// Every message should end with this character as per Klipper documentation
		/// </summary>
		private const byte ETX = 0x03;
		/// <summary>
		/// UDS file path
		/// </summary>
        public string Path { get; }
        public ILogger<KlippyMessager> Logger { get; }

        public KlippyMessager(string path, ILogger<KlippyMessager> logger)
        {
            Path = path;
            Logger = logger;
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
		public async Task<string> CallMethod(string method)			
		{
			return await this.Send(new Model.KMessage(1, method, new object()));
		}
			/// <summary>
			/// Justs flushes the message to the uds port (socket)
			/// </summary>
			/// <typeparam name="TMessage"></typeparam>
			/// <param name="message"></param>
			/// <returns></returns>
			public async Task<string> Send<TMessage>(TMessage message)
			where TMessage : class
        {
			//var unixSocket = "/tmp/klippy_uds";
			using var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
			socket.Connect(new UnixDomainSocketEndPoint(Path));
			var data = new byte[1];
			var options = new JsonSerializerOptions
			{
				WriteIndented = false,
			};
			Logger?.LogDebug("Writing to klipper");
			Logger?.LogDebug(JsonSerializer.Serialize(message, new JsonSerializerOptions
			{
				WriteIndented = true,
			}));
			var outData = System.Text.Encoding.ASCII.GetBytes(JsonSerializer.Serialize(message, options));			
			socket.Send(outData);			
			socket.Send(new byte[] { ETX });
			return await ReadResponse(socket);
		}

		
	}
}
