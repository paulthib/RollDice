using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollDice.Biz
{
    public class DiceRoller : IDiceRoller
    {
        public DiceModel Roll(int numberOfDice)
        {
             
            DiceModel diceModel = new DiceModel(numberOfDice);
            Random random = new Random();
            for (int i = 0; i < numberOfDice; i++)
            {
                diceModel.Dice.Add(random.Next(1, 6));
            }
            return diceModel;
        }
    }


}