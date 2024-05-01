using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2OOP
{
    internal class Die
    {
        private Random _rng;
        
        public int dieCurrentValue;

        public Die(Random random)
        {
            try
            {
                this._rng = random;
                dieCurrentValue = 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine("There has been a problem making the dice objects!" + exception.Message);
            }


            
        }

        public int Roll()
        {
            dieCurrentValue = _rng.Next(1, 7); // Assigns current value to a random number between 1 and 6
            return dieCurrentValue;
        }
    }
}
