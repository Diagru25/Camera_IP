using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Camera_IP.Controllers
{
    public class Monitor_CameraController : Controller
    {

        VideoCapture graber;
        Image<Bgr, Byte> currentFrame;
        // GET: Monitor_Camera
        public ActionResult Index()
        {
            return View();
        }
    }
}