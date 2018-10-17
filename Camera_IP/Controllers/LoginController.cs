using Camera_IP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Camera_IP.Common;


namespace Camera_IP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UserLogin(string userName, string password)
        {
            try
            {
                XElement root = XElement.Load(Common.CommonHelp.AccountPath);
                List<XElement> listNodeAccount = root.Elements("Account").ToList();
                foreach (XElement node in listNodeAccount)
                {
                    string _userName = node.Element("User_Name").Value.ToString();
                    string _password = node.Element("Password").Value.ToString();
                    int _role_id = Convert.ToInt32(node.Element("Role_ID").Value);
                    int status = Convert.ToInt32(node.Element("Status").Value);
                    Session.Add(CommonHelp.USER_SESSION, _role_id);
                    if (_userName == userName && _password == password && status == 1)
                        return Json(new
                        {
                            status = true
                        });
                }
                return Json(new
                {
                    status = false
                });
            }
            catch
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        public ActionResult Logout()
        {
            Session[CommonHelp.USER_SESSION] = null;
            return RedirectToAction("Index");
        }
        public ActionResult Register()
        {
            List<Role> listRole = new List<Role>();
            XElement root = XElement.Load(Common.CommonHelp.RolePath);
            List<XElement> listNodeRole = root.Elements("Role").ToList();
            foreach(XElement node in listNodeRole)
            {
                Role role = new Role();
                role.Role_ID = Convert.ToInt32(node.Element("Role_ID").Value);
                role.Role_Name = node.Element("Role_Name").Value.ToString();
                listRole.Add(role);
            }
            return View(listRole);
        }
        public JsonResult UserRegister(string userName, string password, int role_id)
        {
            try
            {
                string path = Common.CommonHelp.AccountPath;
                XElement root = XElement.Load(path);
                List<XElement> listNodeAccount = root.Elements("Account").ToList();
                foreach(XElement item in listNodeAccount)
                {
                    if (item.Element("User_Name").Value == userName) return Json(new
                    {
                        status = "duplicate"
                });
                }
                XElement node = new XElement("Document",
                    new XElement("Account",
                        new XElement("Account_ID", listNodeAccount.Count + 1),
                        new XElement("User_Name", userName),
                        new XElement("Password", password),
                        new XElement("Role_ID", role_id),
                        new XElement("Status",0)
                        )
                    );
                root.Add(from el in node.Elements()
                         where Convert.ToInt32(el.Element("Account_ID").Value) > 0
                         select el 
                         );
                root.Save(path);
                return Json(new
                {
                    status = "success"
                });
            }
            catch
            {
                return Json(new
                {
                    status = "error"
                });
            }
        }
        public ActionResult Error401()
        {
            return View();
        }
    }
}