using System;
using System.Collections.Generic;
using System.Text;

namespace DGRE
{
    
    public class CalcTime
    {
        public DateTime PrintCurrentTime()
        {
            return DateTime.Now;
        }

        // method for avg time between pushes
        // method for inputs per d/
        //method for avg time of input 
        // method for avg input d/m/y




        public TimeSpan TSLPmethod(List<DateTime> lister)
        {

            int logGrab = 0;

            if (lister.Count > 0)

            {
                logGrab = lister.Count - 1;
            }
            TimeSpan timeSinceLast = DateTime.Now.Subtract(lister[logGrab]);


            return timeSinceLast;
        }



        public DateTime LastInput(List<DateTime> lister)
        {


            int loggrabLI = 0;

            if (lister.Count > 0)
            {
                loggrabLI = lister.Count - 1;
            }

            return lister[loggrabLI];


        }
    }

}
