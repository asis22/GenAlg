using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Potomok: IComparable
    {
        public double X;
        
        public double Y;

        public int Compare(Potomok x, Potomok y)
        {
            var dlt = x.Y - y.Y;
            if (dlt > 0)
                return 1;
            if (dlt < 0)
                return -1;
            return 0;
        }

        public int CompareTo(object obj)
        {
            var y = obj as Potomok;
            var dlt = Y - y.Y;
            if (dlt > 0)
                return 1;
            if (dlt < 0)
                return -1;
            return 0;
        }
    }
}
