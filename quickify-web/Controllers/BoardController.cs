using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quickify_web.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Kanban()
        {
            return View();
        }
    }
}