using System;
using System.Collections.Generic;
using System.Text;

namespace Faktura
{
    public class Client
    {
        public Client()
        {
            company = "BUDIMEX";
            adress = "Jęczniki Wielkie 23/4 00-111";
            numberNip = "0000000000";
        }

        public Client(string company, string adress, string numberNip)
        {
            this.company = company;
            this.adress = adress;
            this.numberNip = numberNip;
        }

        #region Data members

        public Cart shopCar = new Cart();
        public string company;
        public string adress;
        public string numberNip;
        public int noteIndex = 0;


        #endregion
    }
}
