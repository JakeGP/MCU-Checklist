using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCUChecklist.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string ProfilePhoto { get; set; }
        public string LoginMessage { get; set; }

        public List<Film> Films { get; set; }
    }
}