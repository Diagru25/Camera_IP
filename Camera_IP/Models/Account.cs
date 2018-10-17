using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camera_IP.Models
{
    public class Account
    {
        public int Account_ID { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public int Role_ID { get; set; }
        public string Role_Name { get; set; }

    }
}