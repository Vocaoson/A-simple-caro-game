using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalAlgorithms
{
    public class PlayInfor
    {
        private Point point;
        private int current;

        public Point Point
        {
            get
            {
                return point;
            }

            set
            {
                point = value;
            }
        }

        public int Current
        {
            get
            {
                return current;
            }

            set
            {
                current = value;
            }
        }
    }
}
