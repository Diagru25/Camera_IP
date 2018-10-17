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
    public class Monitor_CameraController : SecurityController
    {
        string path = Common.CommonHelp.CameraPath;

        // GET: Monitor_Camera
        public ActionResult Index()
        {
            // tạo list
            List<camera> list = new List<camera>();

            // load file xml
            XmlDocument xmlDoc = new XmlDocument();
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
    }
}