using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faktura;
using System;

namespace FakturaUT
{
    [TestClass]
    public class FakturaUT
    {
        [TestMethod]
        public void ClientTest1()
        {
            string testComapny = "Biedronka";
            string testAdress = "Gdansk Slupska 41c 80-400";
            string testNip = "4813910231";

            Client testClient = new Client(testComapny, testAdress, testNip );

            Assert.IsNotNull(testClient);
            Assert.AreEqual(testClient.company, "Biedronka");
            Assert.AreEqual(testClient.adress, "Gdansk Slupska 41c 80-400");
            Assert.AreEqual(testClient.numberNip, "4813910231");

        }

        [TestMethod]
        public void SellerTest1()
        {
            string testComapny = "Polpharma";
            string testAdress = "Gdañsk Trzy Lipy 3 80-172 ";
            string testNip = "8274123211";
            string testAccountNumber = "24862710378441323141938122";

            Seller testSeller = new Seller(testComapny, testAdress, testNip, testAccountNumber);

            Assert.IsNotNull(testSeller);
            Assert.AreEqual(testComapny, testSeller.company);
            Assert.AreEqual(testAdress, testSeller.adress);
            Assert.AreEqual(testNip, testSeller.numberNip);
            Assert.AreEqual(testAccountNumber, testSeller.accountNumber);

        }

        [TestMethod]
        public void NoteTest1()
        {

            Client client = new Client();
            Seller seller = new Seller();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string index = client.noteIndex.ToString();
            string testFV = $"FV/{year}/{month}/{index}";

            Note testNote = new Note(client, seller);
            string testId = testNote.generateNoteID();

            Assert.AreEqual(testId, testFV);
            
        }
        [TestMethod]
        public void ProductTest1()
        {
            string testName = "Orzechy laskowe";
            double testPrice = 44.90;
            double testTax = 0.08;

            Product testProduct = new Product(testName, testPrice, testTax);

            Assert.IsNotNull(testProduct);
            Assert.AreEqual(testName, testProduct.productName);
            Assert.AreEqual(testPrice, testProduct.nettoUnitPrice);
            Assert.AreEqual(testTax, testProduct.taxVat);
        }

        [TestMethod]
        public void ProductTest2()
        {
            string testName = "Telewizor X";
            double testPrice = 7299.90;
            double testTax = 0.23;
            double testBruttoPrice = 8978.88;


            Product testProduct = new Product(testName, testPrice, testTax);

            Assert.AreEqual(testBruttoPrice, testProduct.bruttoUnitPrice);
        }

        [TestMethod]
        public void ProductsTest1()
        {

            Product p1 = new Product("Orzechy laskowe", 44.90, 0.08);
            Product p2 = new Product("Telewizor X", 7299.90, 0.23);

            Products products = new Products();

            Assert.AreEqual(8, products.avProducts.Count);

            products.avProducts.Add(9, p1);
            products.avProducts.Add(10, p2);

            Assert.AreEqual(10, products.avProducts.Count);

        }
        [TestMethod]
        public void ProductsTest2()
        {

            Product p1 = new Product("Orzechy laskowe", 44.90, 0.08);
            Product p2 = new Product("Telewizor X", 7299.90, 0.23);

            Products products = new Products();

            products.avProducts.Add(9, p1);
            products.avProducts.Add(10, p2);

            Assert.AreEqual(p1, products.avProducts[9]);
            Assert.AreEqual(p2, products.avProducts[10]);

        }
        [TestMethod]
        public void CartTest1()
        {
            Products products = new Products();
            Client client = new Client();

            client.shopCar.AddToCart(products.GetProduct(1));
            client.shopCar.AddToCart(products.GetProduct(3));
            client.shopCar.AddToCart(products.GetProduct(1));
            client.shopCar.AddToCart(products.GetProduct(1));

            Assert.AreEqual(client.shopCar.shoppingCart.Count, 2);

        }

        [TestMethod]
        public void CartTest2()
        {
            Products products = new Products();
            Client client = new Client();

            client.shopCar.AddToCart(products.GetProduct(1));
            client.shopCar.AddToCart(products.GetProduct(3));
            client.shopCar.AddToCart(products.GetProduct(1));

            Assert.AreEqual(client.shopCar.shoppingCart.Count, 2);

            client.shopCar.RemoveFromCart(products.GetProduct(1));

            Assert.AreEqual(client.shopCar.shoppingCart.Count, 1);

        }

        [TestMethod]
        public void CartTest3()
        {

            Products products = new Products();
            Client client = new Client();

            client.shopCar.AddToCart(products.GetProduct(1));
            client.shopCar.AddToCart(products.GetProduct(1));
            client.shopCar.AddToCart(products.GetProduct(1));

            Assert.AreEqual(client.shopCar.shoppingCart.Count, 1);
            Assert.AreEqual(products.avProducts[1].qunatity, 3);

            client.shopCar.RemoveFromCartCount(products.GetProduct(1));
            Assert.AreEqual(products.avProducts[1].qunatity, 2);

        }

    }
}
