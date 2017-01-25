using DiceThrow.Models;
using Newtonsoft.Json;
using RollDice.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollDice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public JsonResult RollDice()
        {
            DiceRoller diceRoller = new DiceRoller();

            DiceViewModel diceViewModel = new DiceViewModel(diceRoller.Roll());

            //return Json("HELLO", JsonRequestBehavior.AllowGet);
            var x = JsonConvert.SerializeObject(diceViewModel);
            return Json(diceViewModel , JsonRequestBehavior.AllowGet);
        }

    }
}