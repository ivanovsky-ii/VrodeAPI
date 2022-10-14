using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppTrue.Models;

namespace WebAppTrue
{
    public partial class ResponeEmployee
    {
        public ResponeEmployee(Emplyee emplyee)
        {
            id = emplyee.id;
            name = emplyee.name;
            idType = emplyee.idType;   
            userName = emplyee.userName;
            password = emplyee.password;
        }
        public int id { get; set; }
        public string name { get; set; }
        public int idType { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}