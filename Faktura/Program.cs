using System;

namespace Faktura
{
    class Program
    {
        static void Main(string[] args)
        {
            Products avaliableProducts = new Products();
            Client client = new Client();
            Seller seller = new Seller();
            client.shopCar.AddToCart(avaliableProducts.GetProduct(1));
            client.shopCar.AddToCart(avaliableProducts.GetProduct(2));
            client.shopCar.AddToCart(avaliableProducts.GetProduct(3));
            client.shopCar.AddToCart(avaliableProducts.GetProduct(4));
            client.shopCar.AddToCart(avaliableProducts.GetProduct(4));
            client.shopCar.AddToCart(avaliableProducts.GetProduct(1));
            client.shopCar.AddToCart(avaliableProducts.GetProduct(1));

            client.shopCar.AddToCart(avaliableProducts.GetProduct(232));
            client.shopCar.Display();

            Note note = new Note(client, seller);
            note.Display();
            


        }
    }
}
