using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.DAL;

namespace website.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index(string id)
        {
			var people = new PersonDAL ().Get ();
            return View (people);
        }
    }
}
