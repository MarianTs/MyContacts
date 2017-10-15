using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyContacts.Context;
using MyContacts.Models;

namespace MyContacts.Controllers
{
    public class HomeController : Controller
    {
        ContactsContext db = new ContactsContext();
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }


        [HttpPost]
        public ActionResult Index(Contacts con)
        {
            List<Contacts> contactsToDisplay;
            if (con.Name != null)
            {
                contactsToDisplay = (from c in db.Contacts.ToList()
                             where (c.Name.StartsWith(con.Name) || c.PhoneNumber.StartsWith(con.Name))
                             select c).ToList();
            }
            else
            {
                contactsToDisplay = db.Contacts.ToList();
            }
            return PartialView("ContactsInfo", contactsToDisplay);
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

        // GET: Contacts/CreateNewContact
        public ActionResult CreateNewContact()
        {
            return View();
        }

        // POST: Contacts/CreateNewContact
        [HttpPost]
        public ActionResult CreateNewContact(Models.Contacts contacts)
        {
            if (contacts==null || contacts.Name==null || contacts.PhoneNumber==null)
            {
                return View();
            }
            if (contacts.Name.Length==0 || contacts.PhoneNumber.Length==0)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacts);
        }
    }
}