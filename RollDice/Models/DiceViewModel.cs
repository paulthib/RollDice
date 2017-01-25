using RollDice.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceThrow.Models
{
    public class DiceViewModel
    {
        private const string FMT = @"..\images\die_face_{0}.png";
        public DiceViewModel(DiceModel diceModel)
        {
            Dice = new List<int>();
            DiceImages = new List<string>();
            for (int i = 0; i < diceModel.Count; i++)
            {
                Dice.Add(diceModel[i]);
                DiceImages.Add(string.Format(FMT,diceModel[i]));

            }
        }

        public List<int> Dice { get; set; }
        public List<string> DiceImages { get; set; }
    }
}