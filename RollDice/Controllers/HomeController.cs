using DiceThrow.Models;
using Newtonsoft.Json;
using RollDice.Biz;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
            // set this to enable demo of a webapi call
            ViewBag.WebApiUrl = "http://" + Request.Url.Authority + "/api/DiceRoller/RollDice?NumberOfDice=2";
            return View();
        }


        [HttpGet]
        public JsonResult RollDice(int NumberOfDice)
        {
            // testing - call webapi to roll the dice - result is currently not used 
            DiceModel dm = RollDiceViaWebAPi(NumberOfDice);

            // roll the dice via direct call
            DiceViewModel diceViewModel = new DiceViewModel(_diceRoller.Roll(NumberOfDice));
            return Json(diceViewModel , JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Roll the dice via a call to webapi
        /// </summary>
        /// <param name="NumberOfDice"></param>
        /// <returns></returns>
        private DiceModel RollDiceViaWebAPi(int NumberOfDice)
        {
            var x = Request.Url.Authority;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + x);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/DiceRoller/RollDice?NumberOfDice=" + NumberOfDice).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    DiceModel dm = JsonConvert.DeserializeObject<DiceModel>(responseString);
                    return dm;
                }
            }
            return null;
        }
    }
}