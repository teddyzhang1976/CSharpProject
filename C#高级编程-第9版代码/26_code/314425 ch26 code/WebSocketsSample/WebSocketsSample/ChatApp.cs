using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSocketsSample
{
    public class ChatApp
    {
        static IList<ChatUser> _users = new List<ChatUser>();

        public static void AddUser(ChatUser chatUser)
        {
            _users.Add(chatUser);
            foreach(var user in _users)
            {
                user.SendMessage(chatUser.UserName + " joined the chat!");
            }
        }

        public static void BroadcastMessage(string message)
        {
            foreach (var user in _users)
            {
                user.SendMessage(message);
            }
        }
    }
}