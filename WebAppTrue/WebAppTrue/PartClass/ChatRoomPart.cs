using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTrue.Models
{
    public partial class ChatRoom
    {
        public string LastMessage
        {
            get
            {
                string message = "Нет";

                try
                {
                    message = ChatMessage.LastOrDefault()?.textMessage ?? "Нет сообщений";
                    return message;
                }
                catch
                {
                    return message;
                }
            }
        }
    }
}