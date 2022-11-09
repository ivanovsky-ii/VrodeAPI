using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppTrue.Models;

namespace WebAppTrue.Model
{
    public partial class ResponceChatMessage
    {
        public ResponceChatMessage(ChatMessage chatMessage)
        {
            id = chatMessage.id;
            idEmplyee = chatMessage.idEmplyee;  
            idChatRoom = chatMessage.idChatRoom;
            textMessage = chatMessage.textMessage;
            dateTime = chatMessage.dateTime;
            takeMessage = chatMessage.takeMessage;  

        }
        public int id { get; set; }
        public Nullable<int> idEmplyee { get; set; }
        public Nullable<int> idChatRoom { get; set; }
        public string textMessage { get; set; }
        public Nullable<System.DateTime> dateTime { get; set; }
        public string takeMessage { get; set; }
    }
}