using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camera_IP.Models
{
    public class camera
    {
        public int ID { get; set; }
        public string ten { get; set; }
        public string diachi_ip { get; set; }
        public string cong { get; set; }
        public string vitri { get; set; }
        public string loai { get; set; }
        public string trangthai { get; set; }
        public string duongdan { get; set; } // đây là cái để cho vào src trong thẻ img
    }
}