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
    [HasPermission(RoleID = 1)]
    public class AccountController : SecurityController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RequestAccount()
        {
            List<Account> listAccount = new List<Account>();
            XElement root = XElement.Load(Common.CommonHelp.AccountPath);
            //XElement request = new XElement("Document",null);
            //request.Add(from el in root.Elements()
            //            where el.Element("Status").Value == "0"
            //        select el
            //            );
            List<XElement> listNodeAccount = root.Elements("Account").ToList();
            foreach (XElement node in listNodeAccount)
            {
                if (Convert.ToInt32(node.Element("Status").Value) == 0)
                {
                    Account Account = new Account();
                    Account.Account_ID = Convert.ToInt32(node.Element("Account_ID").Value);
                    Account.User_Name = node.Element("User_Name").Value.ToString();
                    Account.Password = node.Element("Password").Value.ToString();
                    Account.Role_ID = Convert.ToInt32(node.Element("Role_ID").Value);
                    if (Convert.ToInt32(node.Element("Role_ID").Value)== 1)
                    {
                        Account.Role_Name = "Root";

                    }
                    else
                    {
                        Account.Role_Name = "Admin";
                    }
                    listAccount.Add(Account);
                }

            }
            return View(listAccount);
        }
        public JsonResult AcceptAccount(int Account_ID)
        {
            try
            {
                string path = Common.CommonHelp.AccountPath;
                XElement root = XElement.Load(path);
                List<XElement> listNodeAccount = root.Elements("Account").ToList();
                XElement _root = new XElement("Document");
                foreach (XElement node in listNodeAccount)
                {
                    if (node.Element("Account_ID").Value == Account_ID.ToString())
                    {
                        XElement _node = new XElement("Document",
                    new XElement("Account",
                        new XElement("Account_ID", node.Element("Account_ID").Value),
                        new XElement("User_Name", node.Element("User_Name").Value),
                        new XElement("Password", node.Element("Password").Value),
                        new XElement("Role_ID", node.Element("Role_ID").Value),
                        new XElement("Status", 1)
                        )
                    );
                        _root.Add(from el in _node.Elements()
                                  where Convert.ToInt32(el.Element("Account_ID").Value) > 0
                                  select el);
                    }
                    else
                    {
                        XElement _node = new XElement("Document",
                   new XElement("Account",
                        new XElement("Account_ID", node.Element("Account_ID").Value),
                        new XElement("User_Name", node.Element("User_Name").Value),
                        new XElement("Password", node.Element("Password").Value),
                        new XElement("Role_ID", node.Element("Role_ID").Value),
                       new XElement("Status", node.Element("Status").Value)
                       ));
                        _root.Add(from el in _node.Elements()
                                  where Convert.ToInt32(el.Element("Account_ID").Value) > 0
                                  select el);
                    }
                }
                _root.Save(path);
                return Json(new
                {
                    status = true
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
        public JsonResult DenyAccount(int Account_ID)
        {
            try
            {
                string path = Common.CommonHelp.AccountPath;
                XElement root = XElement.Load(path);
                List<XElement> listNodeAccount = root.Elements("Account").ToList();
                XElement _root = new XElement("Document");
                foreach (XElement node in listNodeAccount)
                {
                    if (node.Element("Account_ID").Value != Account_ID.ToString())
                    {
                        XElement _node = new XElement("Document",
                    new XElement("Account",
                         new XElement("Account_ID", node.Element("Account_ID").Value),
                         new XElement("User_Name", node.Element("User_Name").Value),
                         new XElement("Password", node.Element("Password").Value),
                         new XElement("Role_ID", node.Element("Role_ID").Value),
                        new XElement("Status", node.Element("Status").Value)
                        ));
                        _root.Add(from el in _node.Elements()
                                  where Convert.ToInt32(el.Element("Account_ID").Value) > 0
                                  select el);
                    }
                }
                _root.Save(path);
                return Json(new
                {
                    status = true
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

        public ActionResult RoleAccount()
        {
            List<Account> listAccount = new List<Account>();
            XElement root = XElement.Load(Common.CommonHelp.AccountPath);
            //XElement request = new XElement("Document",null);
            //request.Add(from el in root.Elements()
            //            where el.Element("Status").Value == "0"
            //        select el
            //            );
            List<XElement> listNodeAccount = root.Elements("Account").ToList();
            foreach (XElement node in listNodeAccount)
            {
                if (Convert.ToInt32(node.Element("Status").Value) == 1)
                {
                    Account Account = new Account();
                    Account.Account_ID = Convert.ToInt32(node.Element("Account_ID").Value);
                    Account.User_Name = node.Element("User_Name").Value.ToString();
                    Account.Password = node.Element("Password").Value.ToString();
                    Account.Role_ID = Convert.ToInt32(node.Element("Role_ID").Value);
                    if (Convert.ToInt32(node.Element("Role_ID").Value) == 1)
                    {
                        Account.Role_Name = "Root";

                    }
                    else
                    {
                        Account.Role_Name = "Admin";
                    }
                    listAccount.Add(Account);
                }

            }
            return View(listAccount);
        }
        public JsonResult ChangeRoleAccount(int Account_ID, int Role_ID )
        {
            try
            {
                string path = Common.CommonHelp.AccountPath;
                XElement root = XElement.Load(path);
                List<XElement> listNodeAccount = root.Elements("Account").ToList();
                XElement _root = new XElement("Document");
                foreach (XElement node in listNodeAccount)
                {
                    if (node.Element("Account_ID").Value == Account_ID.ToString())
                    {
                        XElement _node = new XElement("Document",
                    new XElement("Account",
                        new XElement("Account_ID", node.Element("Account_ID").Value),
                        new XElement("User_Name", node.Element("User_Name").Value),
                        new XElement("Password", node.Element("Password").Value),
                        new XElement("Role_ID", Role_ID.ToString()),
                        new XElement("Status", 1)
                        )
                    );
                        _root.Add(from el in _node.Elements()
                                  where Convert.ToInt32(el.Element("Account_ID").Value) > 0
                                  select el);
                    }
                    else
                    {
                        XElement _node = new XElement("Document",
                   new XElement("Account",
                        new XElement("Account_ID", node.Element("Account_ID").Value),
                        new XElement("User_Name", node.Element("User_Name").Value),
                        new XElement("Password", node.Element("Password").Value),
                        new XElement("Role_ID", node.Element("Role_ID").Value),
                       new XElement("Status", node.Element("Status").Value)
                       ));
                        _root.Add(from el in _node.Elements()
                                  where Convert.ToInt32(el.Element("Account_ID").Value) > 0
                                  select el);
                    }
                }
                _root.Save(path);
                return Json(new
                {
                    status = true
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

        public JsonResult DeleteAccount(int Account_ID)
        {
            try
            {
                string path = Common.CommonHelp.AccountPath;
                XElement root = XElement.Load(path);
                List<XElement> listNodeAccount = root.Elements("Account").ToList();
                XElement _root = new XElement("Document");
                foreach (XElement node in listNodeAccount)
                {
                    if (node.Element("Account_ID").Value != Account_ID.ToString())
                    {
                        XElement _node = new XElement("Document",
                    new XElement("Account",
                         new XElement("Account_ID", node.Element("Account_ID").Value),
                         new XElement("User_Name", node.Element("User_Name").Value),
                         new XElement("Password", node.Element("Password").Value),
                         new XElement("Role_ID", node.Element("Role_ID").Value),
                        new XElement("Status", node.Element("Status").Value)
                        ));
                        _root.Add(from el in _node.Elements()
                                  where Convert.ToInt32(el.Element("Account_ID").Value) > 0
                                  select el);
                    }
                }
                _root.Save(path);
                return Json(new
                {
                    status = true
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

    }
}