using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Faktura
{
    public class Cart
    {
        public Cart()
        {

        }
        

        public void AddToCart(Product newProduct)
        {
            if (newProduct == null)
            {
                return;
            }

            if (shoppingCart.Contains(newProduct))
            {
                shoppingCart.Find(prod => prod.productName == newProduct.productName).qunatity++;
            }
            else
            {
                shoppingCart.Add(newProduct);
            }
        }

        public void RemoveFromCartCount(Product productExisitng)
        {
            if (shoppingCart.Contains(productExisitng))
            {
                shoppingCart.Find(prod => prod.productName == productExisitng.productName).qunatity--;
            }
        }
        public void RemoveFromCart(Product product)
        {
            shoppingCart.Remove(product);
        }
        
        public void Display()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("| Product name    | Netto unit price | VAT   | Brutto unit price |");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (var item in shoppingCart)
            {
                Console.WriteLine(String.Format("| {0,-15} | {1,-16} | {2,5} | {3, 17} |", item.productName, item.nettoUnitPrice, item.taxVat, item.bruttoUnitPrice));
            }
        }

        public List<Product> shoppingCart = new List<Product>();
        


    }
}
