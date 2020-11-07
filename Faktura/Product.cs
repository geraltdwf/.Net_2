using System;
using System.Collections.Generic;
using System.Text;

namespace Faktura
{
    public class Product
    {
        public Product(string productName, double unitPrice, double vat)
        {
            this.productName = productName;
            this.nettoUnitPrice = unitPrice;
            this.taxVat = vat;
            CalculateBruttoPrice();
        }
        public void CalculateBruttoPrice()
        {
            bruttoUnitPrice = Math.Round(nettoUnitPrice * (taxVat+1),2);
        }

        public string productName;
        public double nettoUnitPrice;
        public double taxVat;
        public double bruttoUnitPrice;
        public int qunatity = 1;
    }
}
