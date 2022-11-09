using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTrue.Models
{
    public partial class ChatMessage
    {
        private ForAPIEntities db = new ForAPIEntities();
        public string takeMessage
        {
            get
            {
                var emp = db.Emplyee.Where(i => i.id == idEmplyee).FirstOrDefault();
                string mess = $"{emp.userName} : {textMessage} : [{dateTime}]";
                return mess;
            }
        }
    }
}