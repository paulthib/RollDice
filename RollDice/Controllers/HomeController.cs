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
        private IDiceRoller _diceRoller;
        public HomeController(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult RollDice()
        {
            DiceViewModel diceViewModel = new DiceViewModel(_diceRoller.Roll());
            return Json(diceViewModel , JsonRequestBehavior.AllowGet);
        }

    }
}