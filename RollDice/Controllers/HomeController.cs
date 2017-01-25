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


        public JsonResult RollDice()
        {
            DiceRoller diceRoller = new DiceRoller();
            DiceViewModel diceViewModel = new DiceViewModel(diceRoller.Roll());
            return Json(diceViewModel , JsonRequestBehavior.AllowGet);
        }

    }
}