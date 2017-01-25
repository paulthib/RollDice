using System.Collections.Generic;

namespace RollDice.Biz
{
    public class DiceModel
    {
        public DiceModel(int diceCount)
        {
            Dice = new List<int>();
        }

        public List<int> Dice { get; set;}
        public int Count
        {
            get
            {
                return Dice.Count;
            }
        }

    }
}