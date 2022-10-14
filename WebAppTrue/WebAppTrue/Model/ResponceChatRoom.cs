using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppTrue.Models;

namespace WebAppTrue.Model
{
    public partial class ResponceChatRoom
    {
        public ResponceChatRoom(ChatRoom chatRoom)
        {
            Topic = chatRoom.Topic;
            LastMessage = chatRoom.GetLastMessage;
        }
        public int id { get; set; }
        public string Topic { get; set; }
        public string LastMessage { get; set; } 
    }
}