using quickify_persistence.Model;
using quickify_service.Proyect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace quickify_web.Controllers
{
    [Authorize]
    public class ProyectController : Controller
    {
        private ProyectService proyectService = new ProyectService();
        public static string Static_Name { get; set; }

        public ActionResult Index()
        {
            return View(proyectService.getProjectsByEmailFromTheUser(AuthController.Static_Email));  
        }


        public ActionResult PassKanban(string name)
        {
            Static_Name = name;
            return RedirectToAction("Kanban", "Board");
        }

        public class Role {
            public string name { get; set; }
        }

        public ActionResult Create()
        {
            IEnumerable<Role> role = new List<Role>() {
                new Role { name="Analista"},
                new Role { name="Desarrollador"},
            }.AsEnumerable();

            ViewBag.Usuario_Id = new SelectList(proyectService.getUsers(AuthController.Static_Email), "name", "name");
            ViewBag.Role_Id = new SelectList(role, "name", "name");

            return View();
        }


        public ActionResult SaveEquipo(string nameProyect, Users[] users)
        {
            string result = "Error! Proyect Is Not Complete!";
            Users temp = new Users();
            temp.password = "Administrador";
            temp.name = proyectService.getNameUSer(AuthController.Static_Email);
            

            users = users.Concat(new Users[] { temp }).ToArray();

            proyectService.addProyect(nameProyect, users);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
