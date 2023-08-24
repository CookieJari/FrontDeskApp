using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp
{
    internal class Storage
    {
        int sMax = 30;
        int mMax = 20;
        int lMax = 10;

        int sBoxes = 0;
        int mBoxes = 0;
        int lBoxes = 0;

        public int SBoxes { get { return sBoxes; } set { sBoxes += value; } }
        public int MBoxes { get { return mBoxes; } set { mBoxes += value; } }
        public int LBoxes { get { return lBoxes; } set { lBoxes += value; } }

        public int GetRemaining(int size)
        {
            if (size==1)
            {
                return sMax - sBoxes;
            }
            else if (size==2)
            {
                return mMax - mBoxes;
            }
            else if(size==3)
            {
                return lMax - lBoxes;
            }
            else
            {
                return -1;
            }
        }

    }
}
