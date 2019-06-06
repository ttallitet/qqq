using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rgr_Izibaev
{
    public class Stats
    {
        public int Total = 0;
        public int Missed = 0;
        public int Correct = 0;
        public int Accuracy = 0;
        public double TimerCounter = 20;
        public double multiple = 1;






        public void Update(bool correctKey)
        {

            if (!correctKey)
            {
                Missed++;
                Total -= 5;
                TimerCounter -= 2;
            }
            else
            {
                Correct++;
                Total += 5;

            }


            Accuracy = Missed + Correct;

        }
        public static int Update1(bool correctKey)
        {
            int accuracy1 = 0;
            if (correctKey)
            {
                accuracy1 += 1;
            }
            return accuracy1;
        }

    }
}
