using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* w planach 
 namespace Tomek.Adventures.Quiz._3week.marzec24.App.ServiceApp

    public class TimeMeasuringServiceApp
    {
        private readonly TimeSpan userDefinedTime;
        private DateTime startTime;

        public TimeMeasuringServiceApp(TimeSpan userDefinedTime)
        {
            this.userDefinedTime = userDefinedTime;
        }
        public TimeSpan ElapsedTime
        {
            get
            {
                if (startTime == DateTime.MinValue)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return DateTime.Now - startTime;
                }
            }
        }
        public int ElapsedSeconds
        {
            get
            {
                return (int)ElapsedTime.TotalSeconds;
            }
        }
        public void StartMeasurement()
        {
            startTime = DateTime.Now;
        }
        public void StopMeasurement()
        {
        }
        public void Reset()
        {
            startTime = DateTime.MinValue;
        }
    }
}
*/