using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.uitls
{
    class DateUtils
    {
        public static double GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ts.TotalSeconds;
        }
    }
}
