using System;
using System.Collections.Generic;
using System.Text;

namespace
    proiect
{
    class Mancare
    {
        private MancareTip mProdus;

        public MancareTip Produs
        {
            get
            {
                return mProdus;
            }
            set
            {
                mProdus = value;
            }
        }
        private float mPret;
        public float Pret
        {
            get
            {
                return mPret;
            }
            set
            {
                mPret = value;
            }
        }
        public Mancare(MancareTip aProdus) // constructor
        {
            mProdus = aProdus;
        }
            
    }
    public enum MancareTip
    {
        Royal,
        Felix,
        Whiskas,
        Sanabelle,
        Applaws,
        Smilla,
        Sticksuri,
        Tablete,
        Snackuri

    }
}
