using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp
{
    internal class Customer
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MNumber { get; set; }

        int sBoxes = 0;
        int mBoxes = 0;
        int lBoxes = 0;

        public int SBoxes { get { return sBoxes; } set { sBoxes += value; } }
        public int MBoxes { get { return mBoxes; } set { mBoxes += value; } }
        public int LBoxes { get { return lBoxes; } set { lBoxes += value; } }



    }
}
