using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using Camera_IP.Models;

namespace Camera_IP.Controllers
{
    public class ManageController : Controller
    {

        static string path = @"C:\Users\Diagr\OneDrive\Desktop\Git\Camera_IP\Camera_IP\Assets\data\XMLFile1.xml";

        List<camera> list = new List<camera>();

        // load file xml
        XmlDocument xmlDoc = new XmlDocument();

        // GET: Manage
        public ActionResult Index()
        {
            xmlDoc.Load(path);
            XmlNodeList nodelist = xmlDoc.DocumentElement.SelectNodes("/document/camera");


            foreach (XmlNode node in nodelist)
            {
                camera item = new camera();

                item.ID = Convert.ToInt32(node.SelectSingleNode("ID").InnerText);
                item.ten = node.SelectSingleNode("ten").InnerText;
                item.diachi_ip = node.SelectSingleNode("diachi_ip").InnerText;
                item.cong = node.SelectSingleNode("cong").InnerText;
                item.vitri = node.SelectSingleNode("vitri").InnerText;
                item.loai = node.SelectSingleNode("loai").InnerText;
                item.trangthai = node.SelectSingleNode("trangthai").InnerText;

                switch (item.loai)
                {
                    case "Panasonic":
                        item.duongdan = "http://" + item.diachi_ip + "/nphMotionJpeg?Resolution=192x144&Quality=Standard";
                        break;

                    case "SmartPhone":
                        item.duongdan = "http://" + item.diachi_ip + ":" + item.cong + "/video";
                        break;

                    case "Webcam": item.duongdan = "videoElement"; break; // đây là cái id của thẻ <video> show webcam

                    default: item.duongdan = ""; break;
                }

                list.Add(item);
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Add_Camera()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add_abc_Camera(string ten, string diachi_ip, string cong, string vitri, string loai, string trangthai)
        {
            try
            {

                xmlDoc.Load(path);

                XmlNode add_camera = xmlDoc.CreateNode(XmlNodeType.Element, "camera", null);

                //var a = list.Max(t => t.ID);
                //string id = a.ToString();
                XmlNode _ID = xmlDoc.CreateElement("ID");
                _ID.InnerText = "10";
                XmlNode _ten = xmlDoc.CreateElement("ten");
                _ten.InnerText = ten;
                XmlNode _diachi_ip = xmlDoc.CreateElement("diachi_ip");
                _diachi_ip.InnerText = diachi_ip;
                XmlNode _cong = xmlDoc.CreateElement("cong");
                _cong.InnerText = cong;
                XmlNode _vitri = xmlDoc.CreateElement("vitri");
                _vitri.InnerText = vitri;
                XmlNode _loai = xmlDoc.CreateElement("loai");
                _loai.InnerText = loai;
                XmlNode _trangthai = xmlDoc.CreateElement("trangthai");
                _trangthai.InnerText = trangthai;

                add_camera.AppendChild(_ID);
                add_camera.AppendChild(_ten);
                add_camera.AppendChild(_diachi_ip);
                add_camera.AppendChild(_cong);
                add_camera.AppendChild(_vitri);
                add_camera.AppendChild(_loai);
                add_camera.AppendChild(_trangthai);

                xmlDoc.DocumentElement.AppendChild(add_camera);
                xmlDoc.Save(path);

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
        [HttpGet]
        public ActionResult Edit_Camera(int id)
        {
            camera item = new camera();

            xmlDoc.Load(path);
            XmlNodeList nodelist = xmlDoc.DocumentElement.SelectNodes("/document/camera");

            foreach (XmlNode node in nodelist)
            {
                int id_temp = Convert.ToInt32(node.SelectSingleNode("ID").InnerText);

                if (id_temp == id)
                {

                    item.ID = id;
                    item.ten = node.SelectSingleNode("ten").InnerText;
                    item.diachi_ip = node.SelectSingleNode("diachi_ip").InnerText;
                    item.cong = node.SelectSingleNode("cong").InnerText;
                    item.vitri = node.SelectSingleNode("vitri").InnerText;
                    item.loai = node.SelectSingleNode("loai").InnerText;
                    item.trangthai = node.SelectSingleNode("trangthai").InnerText;
                    break;
                }
            }
            return View(item);
        }

        [HttpPost]
        public JsonResult Edit_abc_Camera(int id, string ten, string diachi_ip, string cong, string vitri, string loai, string trangthai)
        {
            try
            {

                xmlDoc.Load(path);
                XmlNodeList nodelist = xmlDoc.DocumentElement.SelectNodes("/document/camera");

                foreach (XmlNode node in nodelist)
                {
                    int id_temp = Convert.ToInt32(node.SelectSingleNode("ID").InnerText);

                    if (id_temp == id)
                    {
                        node.SelectSingleNode("ten").InnerText = ten;
                        node.SelectSingleNode("diachi_ip").InnerText = diachi_ip;
                        node.SelectSingleNode("cong").InnerText = cong;
                        node.SelectSingleNode("vitri").InnerText = vitri;
                        node.SelectSingleNode("loai").InnerText = loai;
                        node.SelectSingleNode("trangthai").InnerText = trangthai;
                        break;
                    }
                }
                xmlDoc.Save(path);

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

        public JsonResult Delete_camera(int id)
        {
            try
            {
                xmlDoc.Load(path);
                XmlNodeList nodelist = xmlDoc.DocumentElement.SelectNodes("/document/camera");

                foreach(XmlNode item in nodelist)
                {
                    int id_temp = Convert.ToInt32(item.SelectSingleNode("ID").InnerText);

                    if(id_temp == id)
                    {
                        xmlDoc.SelectSingleNode("/document").RemoveChild(item);
                        xmlDoc.Save(path);
                        break;
                    }
                }

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