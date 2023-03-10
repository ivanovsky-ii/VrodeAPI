//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppTrue.Models
{
    using System;
    using System.Collections.Generic;
    using static WebAppTrue.Controllers.ChatMessagesController;

    public partial class ChatMessage
    {
        public int id { get; set; }
        public Nullable<int> idEmplyee { get; set; }
        public Nullable<int> idChatRoom { get; set; }
        public string textMessage { get; set; }
        public Nullable<System.DateTime> dateTime { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
        public virtual Emplyee Emplyee { get; set; }
    }
    public partial class ChatMessage
    {
        public ChatMessage(SimpleChatMessage simple)
        {
            id = 1;
            this.idEmplyee = simple.idEmplyee;
            this.idChatRoom = simple.idChatRoom;
            this.textMessage = simple.textMessage;
            this.dateTime = simple.dateTime;
        }
        public ChatMessage() { }
    }
}
