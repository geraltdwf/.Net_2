using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Faktura
{
    public class Seller
    {
        public Seller()
        {
            company = "Janpol";
            adress = "Raddomska 44/4a Radom 00-000";
            numberNip = "1549581735";
            accountNumber = "74862710378445323151938122";
        }
        public Seller(string company, string adress, string numberNip, string accountNumber)
        {
            this.company = company;
            this.adress = adress;
            this.numberNip = numberNip;
            this.accountNumber = accountNumber;
        }

        public string company;
        public string adress;
        public string numberNip;
        public string accountNumber;
    }
}
