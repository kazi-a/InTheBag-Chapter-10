using InTheBag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InTheBag.Controllers
{
    public class GenieController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        public ActionResult Create2(string GenieName, int Age, int WishesGranted)
        {
            if (WishesGranted > 5000 || Age > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }

        [HttpPost]
        public IActionResult NewWishIndex(int? ID)
        {
            Wishes mywishes = new Wishes
            {
                ID = ID ?? 2,
                Wish1 = Request.Form["Wish1"],
                Wish2 = Request.Form["Wish2"],
                Wish3 = Request.Form["Wish3"]
            };

            string jsonWishes = JsonSerializer.Serialize(mywishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View("WishIndex");
        }

        // GET: Genie/Perks
        public ActionResult Perks()
        {
            ViewBag.Posted = false; 
            return View();
        }

        // POST: Genie/Perks
        [HttpPost]
        public ActionResult Perks(string[] perk)
        {
            ViewBag.Posted = true;
            ViewBag.Perks = perk; 
                                  
            return View();
        }

        // POST: Genie/Create
        /* [HttpPost]
         public IActionResult Create(string GenieName, int Age, int WishesGranted)
         {
             if (WishesGranted > 5000 || Age > 1000)
                 return View("ExperiencedGenie");
             else
                 return View("Novice");
         }

        [HttpPost]
        public ActionResult Create(string GenieName)
        {
            int numGranted = Int32.Parse(Request.Form["WishesGranted"]);
            int Years = Int32.Parse(Request.Form["Age"]);

            if (numGranted > 5000 || Years > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }*/
    }
}

