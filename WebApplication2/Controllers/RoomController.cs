using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        [HttpGet]
        public ActionResult RoomList()
        {
            //var Browser = HttpContext.Request.;
           

            List<Room> rooms = new List<Room>();
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                rooms = db.Rooms.ToList();
            }

            TempData["roomsCount"] = rooms.Count;
            HttpCookie c = new HttpCookie("id");
            c.Value = rooms.Count.ToString();
            
            HttpContext.Response.Cookies.Add(c);

            return View(rooms);
        }
        
        public ActionResult RoomDetails(int id)
        {
            //&_SERVER
            string roomsCount = HttpContext.Response.Cookies["id"].Value;


           Room room = null;
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                room = db.Rooms.FirstOrDefault(f => f.RoomId == id);
            }


            //ViewBag.Test = "";
            //ViewData["Room"] = room;
            //TempData["roomsCount"]="";

            if (id == 100)
            {
                //Обычные страницы в нете
                return Redirect("http://google.com");
            }

            if (id == 101)
            {
                //Обычные страницы в которые лежат в проекте
                return RedirectPermanent("/Account/Login");
            }

            if (room!=null)
                return View(room);
            else 
                //перенаправление на метод действия
                return RedirectToAction("RoomList");

           
        }

        public ContentResult RoomsReport()
        {
            //exel

            string str = "<h1>This is text plan</h1>";
            return Content(str, "text/html", Encoding.Default);
        }
        
        public JsonResult getAllRooms()
        {
            Room room = new Room();
            room.RoomTypeId = 3;

            return Json(new { room = room }, JsonRequestBehavior.AllowGet);
        }

        public FileResult AnnualReport()
        {
            string filenemae = @"C:\Users\Mi Notebook\Documents\Visual Studio 2015\Projects\WebApplication2\WebApplication2\Content\filename.pdf";
            string contentType = "application/pdf";
            string newName = "NewNameFile.pdf";

            return File(filenemae, contentType, newName);
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(500, "URL connot be finde");
        }

    }
}