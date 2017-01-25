using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollDice.Biz
{
    public class DiceModel
    {
        private int[] Dice;
        public DiceModel(int diceCount)
        {
            Dice = new int[diceCount];
        }

        public int Count
        {
            get
            {
                return Dice.Length;
            }
        }
        public int this[int index]
        {
            get
            {
                if (index < 0 | index > Dice.Length)
                    throw new InvalidOperationException("Invalid dice requested");

                return Dice[index];
            }
            internal set
            {
                if (index < 0 | index > Dice.Length)
                    throw new InvalidOperationException("Invalid dice requested");

                Dice[index] = value;
            }
        }

    }
}