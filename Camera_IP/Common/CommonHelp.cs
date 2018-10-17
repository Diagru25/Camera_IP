using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Camera_IP.Common
{
    public class CommonHelp
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string AccountPath
        {
            get
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Assets/data/XMLAccount.xml");            
                return path;
            }
        }
        public static string RolePath
        {
            get
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Assets/data/XMLRole.xml");            
                return path;
            }
        }
        public static string CameraPath
        {
            get
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Assets/data/XMLFile1.xml");
                return path;
            }
        }
    }
}