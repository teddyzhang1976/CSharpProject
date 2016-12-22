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
    /// <summary>
    /// Summary description for ws
    /// </summary>
    public class ws : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                var chatuser = new ChatUser();
                chatuser.UserName = context.Request.QueryString["name"];
                ChatApp.AddUser(chatuser);
                context.AcceptWebSocketRequest(chatuser.HandleWebSocket);
                //context.AcceptWebSocketRequest(HandleWebSocket);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}