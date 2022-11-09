using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppTrue.Models;

namespace WebAppTrue.Model
{
    public class ResponceChatRoomEmployee
    {
        public ResponceChatRoomEmployee(ChatRoomEmploee roomEmploee)
        {
            id = roomEmploee.id;
            idChatRoom = (int)roomEmploee.idChatRoom;
            idEmplyee = (int)roomEmploee.idEmplyee;
        }
        public int id { get; set; }
        public int idChatRoom { get; set; }
        public int idEmplyee { get; set; }
    }
}