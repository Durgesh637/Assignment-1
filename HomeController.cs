using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using EventMgmt.Models;

namespace EventMgmt.Controllers
{
    public class HomeController : Controller
    {

        UsersContext db = new UsersContext();
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "home");

            }



            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Events ka crud
        [HttpGet]

        public ActionResult CreateEvents()
        {


            return View();
        }
        [HttpPost]

        public ActionResult CreateEvents(Event Ev)
        {
            Event re = new Event();
            re.eventid = Ev.eventid;
            re.title = Ev.title;
            re.Description = Ev.Description;
            re.targetAmount = Ev.targetAmount;
            re.Date = Ev.Date;

            db.events.Add(re);
            db.SaveChanges();


            return View();
        }

        public ActionResult Eventsshow()
        {

            return View();
        }
        
        [HttpGet]
        public ActionResult EditEvent(int eventid)
        {
            var users = db.events.Where(x => x.eventid == eventid).ToList();


            return View(users);
        }
        [HttpPost]
        public ActionResult EditEvent(Event Ev, int eventid)
        {
            int n = db.events.Where(x => x.eventid == eventid).Count();
            Event re = db.events.Find(eventid);
            re.eventid = Ev.eventid;
            re.title = Ev.title;
            re.Description = Ev.Description;
            re.targetAmount = Ev.targetAmount;
            re.Date = Ev.Date;
            if (n == 1)
            {
                db.Entry(re).State = EntityState.Modified;
                db.SaveChanges();

            }


            return RedirectToAction("Eventsshow","home");
        }

        public ActionResult DeleteEvent(int eventid)
        {
            int n = db.events.Where(x => x.eventid == eventid).Count();
            Event Re = db.events.Find(eventid);


            if (n == 1)
            {
                db.Entry(Re).State = EntityState.Deleted;
                db.SaveChanges();


            }

            return RedirectToAction("Eventsshow","home");
        }
        //sponsership ka crud

        [HttpGet]
        public ActionResult CreateSponser()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "home");

            }


          
        }
        [HttpPost]
        public ActionResult CreateSponser(Sponsorship sv)
        {
            Sponsorship se = new Sponsorship();

            se.id = sv.id;
            se.email = sv.email;
            se.amount = sv.amount;
            se.eventid = sv.eventid;
            se.sponsorname = sv.sponsorname;
            se.date = DateTime.Now;

            db.sponsorships.Add(se);
            db.SaveChanges();

            return View();
        }

        public ActionResult Sponsershow()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "home");

            }
        }
        [HttpGet]
        public ActionResult EditSponser(int id)
        {


            var users = db.sponsorships.Where(x => x.id == id).ToList();


            return View(users);


            
        }
        [HttpPost]

        public ActionResult EditSponser(Sponsorship sv, int id)
        {
            int n = db.sponsorships.Where(x => x.id == id).Count();
            Sponsorship se = db.sponsorships.Find(id);
            se.id = sv.id;
            se.email = sv.email;
            se.sponsorname = sv.sponsorname;
            se.date= DateTime.Now;
            se.eventid = sv.eventid;
            se.amount = sv.amount;

            if (n == 1)
            {
                db.Entry(se).State = EntityState.Modified;
                db.SaveChanges();

            }



            return RedirectToAction("Sponsershow","home");
        }
        public ActionResult DeleteSponser(int id)
        {
            int n = db.sponsorships.Where(x => x.id == id).Count();
            Sponsorship se = db.sponsorships.Find(id);

            if (n == 1)
            {
                db.Entry(se).State = EntityState.Deleted;
                db.SaveChanges();


            }


            return RedirectToAction("Sponsershow","home");
        }
        //payout ka crud

        [HttpGet]
        public ActionResult Createspayout()
        {

            return View();

        }
        [HttpPost]

        public ActionResult Createspayout(Payout Pe)
        {
            Payout Re = new Payout();
            Re.id = Pe.id;
            Re.amount = Pe.amount;
            Re.eventid = Pe.eventid;
            Re.purpose = Pe.purpose;
            Re.date = DateTime.Now;

            db.payouts.Add(Re);
            db.SaveChanges();


            return View();
        }

        public ActionResult ShowsPayout()
        {


            return View();
        }
        [HttpGet]
        public ActionResult EditsPayout(int id)
        {
            var users = db.payouts.Where(x => x.id == id).ToList();


            return View(users);
        }
        [HttpPost]
        public ActionResult EditsPayout(Payout Pe, int id)
        {
            int n = db.payouts.Where(x => x.id == id).Count();
            Payout Re = db.payouts.Find(id);

            Re.id = Pe.id;
            Re.amount = Pe.amount;
            Re.date = DateTime.Now;
            Re.eventid = Pe.eventid;
            Re.purpose = Pe.purpose;

            if (n == 1)
            {
                db.Entry(Re).State = EntityState.Modified;
                db.SaveChanges();

            }
            
            
            


            return RedirectToAction("ShowsPayout","home");
        }

        public ActionResult Deletepayout(int id)
        {
            int n = db.payouts.Where(x => x.id == id).Count();
            Payout Re = db.payouts.Find(id);

            if (n == 1)
            {
                db.Entry(Re).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return RedirectToAction("ShowsPayout","home");
        }
        [HttpGet]
        public ActionResult CreateTransaction()
        {



            return View();
        }
        [HttpPost]
        public ActionResult CreateTransaction(Transaction Pe)
        {
            Transaction Te = new Transaction();

            Te.id = Pe.id;
            Te.amount = Pe.amount;
            Te.date = DateTime.Now;
            Te.type = Pe.type;
            Te.eventid = Pe.eventid;

            db.transsactions.Add(Te);
            db.SaveChanges();


            return View();        
        }

        public ActionResult ShowTransaction()
        {

            return View();
        }
        [HttpGet]
        public ActionResult EditTransaction(int id)
        {

            return View();
        }
        [HttpPost]
        public ActionResult EditTransaction(Transaction Te, int id)
        {
            int n = db.transsactions.Where(x => x.id == id).Count();
            Transaction Pe = db.transsactions.Find(id);

            Pe.id = Te.id;
            Pe.type = Te.type;
            Pe.eventid = Te.eventid;
            Pe.amount = Te.amount;
            Pe.date = DateTime.Now;

            if (n == 1)
            {
                db.Entry(Pe).State = EntityState.Modified;
                db.SaveChanges();


            }


            return RedirectToAction("ShowTransaction","home");
        }
        public ActionResult DeleteTransaction(int id)
        {
            int n = db.transsactions.Where(x => x.id == id).Count();
            Transaction Te = db.transsactions.Find(id);

            if (n == 1)
            {
                db.Entry(Te).State = EntityState.Deleted;
                db.SaveChanges();

            }

            return RedirectToAction("ShowTransaction","home");
        }

        public ActionResult Homes()
        {


            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
           


            return View();
        } 
        [HttpPost]
        public ActionResult Login(string Name, string Password)
        {

            int user1 = db.admins.Where(x => x.Password == Password && x.Name == Name).Count();
            if (user1 == 1)
            {


                Session["user"] = Name; // seession create

                string userid = Session["user"].ToString();

                return RedirectToAction("index", "home");
            }

            else{
                   return View();

            }

         
        }

    }
}
