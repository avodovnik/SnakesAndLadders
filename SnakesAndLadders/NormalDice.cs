using System;
using SnakesAndLadders.Contracts;

namespace SnakesAndLadders
{
    public class NormalDice : IDice
    {
        public IDiceRoll Roll()
        {
            var roll = new Random().Next(1, 7); // note: lower bound is inclusive, upper one is exclusive

            throw new System.NotImplementedException();
        }

        private class NormalDiceRoll : IDiceRoll {
            private readonly int _roll;

            public NormalDiceRoll(int roll) {
                // TODO: we could add some logic to throw an exception here, if needed
                this._roll = roll;
            }

            public int Roll =>  _roll;
        }
    }
}