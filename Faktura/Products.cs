using System;
using System.Collections.Generic;
using System.Text;

namespace Faktura
{
    public class Products
    {
        public Products()
        {
            avProducts = new Dictionary<int, Product>()
            {
                [1] = new Product("Iphone 12", 5199.99, 0.23),
                [2] = new Product("Truskawki", 12.99, 0.05),
                [3] = new Product("Jagody", 20.99, 0.05),
                [4] = new Product("Komoda IKEA", 999.99, 0.08),
                [5] = new Product("Dysk SSD 480GB", 219.99, 0.23),
                [6] = new Product("Xiaomi Mi Band 4", 129.99, 0.23),
                [7] = new Product("Woda mineralna", 1.99, 0.08),
                [8] = new Product("Monitor SAMSUNG G9", 1200, 0.23)
            };
            DisplayOffer();
        }

        public void DisplayOffer()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("| Product name        | Netto unit price |   VAT | Brutto unit price |");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (var item in avProducts)
            {
                Console.WriteLine(String.Format("| {0,-19} | {1,-16} | {2,5} | {3, 17} |", item.Value.productName, item.Value.nettoUnitPrice, item.Value.taxVat, item.Value.bruttoUnitPrice));
            }
        }
        public Product GetProduct(int index)
        {
            try
            {
                if (avProducts.ContainsKey(index))
                {
                    return avProducts[index];
                }
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("No product on list");
                return null;
            }
            return null;

        }

        public Dictionary<int, Product> avProducts;
    }
}
