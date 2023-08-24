using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp
{
    internal class Transaction
    {
        public Customer Owner { get; set; }

        int sBoxes = 0;
        int mBoxes = 0;
        int lBoxes = 0;

        public int SBoxes { get { return sBoxes; } set { sBoxes += value; } }
        public int MBoxes { get { return mBoxes; } set { mBoxes += value; } }
        public int LBoxes { get { return lBoxes; } set { lBoxes += value; } }

        public DateTime TransacTime { get;set; }

        public string TransacType { get; set; }
    }
}
