using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult RoomList()
        {
            List<Room> rooms = new List<Room>();
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                rooms = db.Rooms.ToList();
            }

            return View(rooms);
        }

        public ActionResult EditRoom(int id)
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                return View(db.Rooms.Find(id));
            }            
        }




        public ActionResult AddRoomType(RoomType roomType, string Action)
        {
            if (Action == "add")
            {
                using (HotelAtrEntity db = new HotelAtrEntity())
                {
                    db.RoomTypes.Add(roomType);
                    //db.SaveChanges();
                }
            }
            else if (Action == "edit")
            {
                using (HotelAtrEntity db = new HotelAtrEntity())
                {
                    RoomType rt = db.RoomTypes.Find(roomType.RoomTypeId);
                    db.Entry(rt).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            
            //RoomType rt = new RoomType();
            //rt.Name = "Double room";
            //rt.RoomTypeDescription = "Some XDescription (Double room)";


            //List<SelectListItem> lists = new List<SelectListItem>();
            //lists.Add(new SelectListItem()
            //{
            //    Text = "Almaty", Value = "ALA"
            //});
            //lists.Add(new SelectListItem()
            //{
            //    Text = "Astana", Value = "TSN",
            //    Selected = true
            //});

            //ViewBag.ContryList = lists;

            return View(roomType);
        }

        [HttpPost]
        public ActionResult AddRoomTypeMethod(RoomType roomType)
        {
            
            return View();
        }

        public ActionResult AddRoomSt(RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                return View("AddRoomTypeList");
            }
            
            return View(roomType);
        }


        public ActionResult PositionList()
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {

                return View(db.Positions.ToList());

            }
            
        }

        public ActionResult EditPosition(int id )
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                Position p = db.Positions.Find(id);
                return View(p);
            }
            
        }
        [HttpPost]
        public ActionResult EditPosition(Position position)
        {

            if (ModelState.IsValid)
            {
                using (HotelAtrEntity db = new HotelAtrEntity())
                {
                    Position p = db.Positions.Find(position.PositionId);
                    p.PositionName = position.PositionName;
                    //db.Entry(p).State=EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("PositionList");

            }
            return View(position);
        }

        public ActionResult DetailsPosition(int id)
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                Position p = db.Positions.Find(id);
                return View(p);
            }
            
        }
        public ActionResult DeletePosition(int id)
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                Position p = db.Positions.Find(id);
                db.Positions.Remove(p);
                db.SaveChanges();
                return RedirectToAction("PositionList");
            }
        
        }

        public ActionResult AddPosition()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPosition(Position position)
        {
            
                if (ModelState.IsValid)
                {
                    using (HotelAtrEntity db = new HotelAtrEntity())
                    {
                        db.Positions.Add(position);
                        db.SaveChanges();
                    }
                    return RedirectToAction("PositionList");

                }
                return View(position);
            
        }
        public ActionResult StaffList()
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {

                return View(db.Staffs.ToList());

            }

        }
        public ActionResult EditStaff(int id)
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                Staff staff = db.Staffs.Find(id);

                List<SelectListItem> PositionList =
                    db.Positions
                        .Select(s => 
                        new SelectListItem
                        {
                            Text = s.PositionName,
                            Value = s.PositionId.ToString(),
                            Selected = staff.PositionId==s.PositionId?true:false
                        }).ToList();

                ViewBag.PositionList = PositionList;
                return View(staff);
            }

        }

        [HttpPost]
        public ActionResult EditStaff(Staff staff)
        {

            if (ModelState.IsValid)
            {
                using (HotelAtrEntity db = new HotelAtrEntity())
                {
                    Staff s = db.Staffs.Find(staff.StaffId);
                    s.StaffId = staff.StaffId;
                    //db.Entry(p).State=EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("StaffsList");

            }
            return View(staff);
        }
        public ActionResult DetailsStaff(int id)
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                Staff s = db.Staffs.Find(id);
                return View(s);
            }

        }
        public ActionResult DeleteStaff(int id)
        {
            using (HotelAtrEntity db = new HotelAtrEntity())
            {
                Staff s = db.Staffs.Find(id);
                db.Staffs.Remove(s);
                db.SaveChanges();
                return RedirectToAction("StaffList");
            }

        }
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff staff)
        {

            if (ModelState.IsValid)
            {
                using (HotelAtrEntity db = new HotelAtrEntity())
                {
                    db.Staffs.Add(staff);
                    db.SaveChanges();
                }
                return RedirectToAction("StaffList");

            }
            return View(staff);

        }
    }

    public class MyContrController : Controller
    {
        public ActionResult Index()
        {
            DateTime n = GetCurentTime();
            return View(n);
        }

        private DateTime GetCurentTime()
        {
            return DateTime.Now;
        }


        
    }

}