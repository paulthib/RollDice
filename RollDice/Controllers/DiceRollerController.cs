using RollDice.Biz;
using System.Collections.Generic;
using System.Web.Http;

namespace RollDice.Controllers
{
    public class DiceRollerController : ApiController
    {
        private IDiceRoller _diceRoller;
        public DiceRollerController(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }

        //test methods - delete 
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public DiceModel RollDice(int NumberOfDice = 2)
        {
            return _diceRoller.Roll(NumberOfDice);
        }
    }
}
