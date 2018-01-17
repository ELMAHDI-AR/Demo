using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCalendar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getevents()
        {
            using (EventsDBEntities db = new EventsDBEntities ()) {

                var result = db.Events.OrderBy(a => a.StartAt).ToList();

                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Event evt)
        {
            bool status = false;
            using (EventsDBEntities db = new EventsDBEntities ())
            {
                if(evt.EndAt != null && evt.StartAt.Value.TimeOfDay == new TimeSpan(0,0,0) &&
                    evt.EndAt.Value.TimeOfDay == new TimeSpan(0,0,0))
                {
                    evt.IsFullDay = true;
                }
                else
                {
                    evt.IsFullDay = false;
                }

                if(evt.EventId > 0)
                {
                    var v = db.Events.Where(a => a.EventId.Equals(evt.EventId)).FirstOrDefault();
                    if(v != null)
                    {
                        v.Title = evt.Title;
                        v.Description = evt.Description;
                        v.StartAt = evt.StartAt;
                        v.EndAt = evt.EndAt;
                        v.IsFullDay = evt.IsFullDay;
                    }
                }
                else
                {
                    db.Events.Add(evt);
                }
                db.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };

        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            bool status = false;
            using (EventsDBEntities db = new EventsDBEntities ())
            {
                var v = db.Events.Where(a => a.EventId.Equals(eventID)).FirstOrDefault();
                if(v != null)
                {
                    db.Events.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}