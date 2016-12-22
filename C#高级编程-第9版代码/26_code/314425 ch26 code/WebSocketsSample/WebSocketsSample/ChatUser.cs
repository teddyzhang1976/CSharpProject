using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebSocketsSample
{
    public class ChatUser
    {
        WebSocketContext _context;
        public string UserName { get; set; }

        public async Task HandleWebSocket(WebSocketContext wsContext)
        {   
            _context = wsContext;
            const int maxMessageSize = 1024;
            byte[] receiveBuffer = new byte[maxMessageSize];
            WebSocket socket = _context.WebSocket;

            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult receiveResult = await socket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);

                if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else if (receiveResult.MessageType == WebSocketMessageType.Binary)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "Cannot accept binary frame", CancellationToken.None);
                }
                else
                {
                    var receivedString = Encoding.UTF8.GetString(receiveBuffer, 0, receiveResult.Count);
                    var echoString = string.Concat(UserName, " said: ", receivedString);
                    ArraySegment<byte> outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(echoString));

                    ChatApp.BroadcastMessage(echoString);
                }
            }
        }
        public async Task SendMessage(string message)
        {
            if (_context != null && _context.WebSocket.State == WebSocketState.Open)
            {
                var outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
                await _context.WebSocket.SendAsync(outputBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

    }
}