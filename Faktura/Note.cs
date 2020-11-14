using System;
using System.Collections.Generic;
using System.Text;

namespace Faktura
{
     public class Note
    {
        public  Note(Client client, Seller seller)
        {
            noteClient = client;
            noteSeller = seller;
        }


        public void Display()
        {
            noteID = generateNoteID();
            Console.WriteLine("FV");
            totalAmount();
            Console.WriteLine("| Product name    | Quantity   | Netto unit price  | Netto sum  |  VAT  | Brutto sum price |");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            foreach (var item in noteClient.shopCar.shoppingCart)
            {
                Console.WriteLine(String.Format("| {0,-15} | {1, -10} | {2,-17} | {3, -10} | {4, -5} | {5, -15}",
                    item.productName, item.qunatity, item.nettoUnitPrice, Math.Round(item.qunatity * item.nettoUnitPrice, 2),
                    item.taxVat, Math.Round(item.bruttoUnitPrice * item.qunatity, 2)));
            }
            Console.WriteLine("----------------------------------------------------------------------------| TOTAL AMOUNT |");
            Console.WriteLine(String.Format("| {0, 88} |", Math.Round(total,2)));
            Console.WriteLine("| CLIENT |");
            disClient();
            Console.WriteLine("| SELLER |");
            disSeller();
            Console.WriteLine("| ID | " +  String.Format("{0, 10}", noteID ));
            Console.WriteLine("| Document issue | " + docTime.ToString("dd/MM/yyyy"));
            Console.WriteLine("| Sale date | " + soldTime.Date.ToString("dd/MM/yyyy"));
            Console.WriteLine("| Paymanet day | " + butTime.Date.ToString("dd/MM/yyyy"));

            Console.WriteLine();
        }

        public void disClient()
        {
            Console.WriteLine("| Comapny     | Adress                         | NIP        |");
            Console.WriteLine(String.Format("| {0,-10}  | {1, -10}   | {2, -10} |", noteClient.company, noteClient.adress, noteClient.numberNip));
            Console.WriteLine();
        }
        public void disSeller()
        {
            Console.WriteLine("| Comapny     | Adress                         | NIP        | Bank account");
            Console.WriteLine(String.Format("| {0,-11} | {1, -13}   | {2, -11}| {3, -15} |", noteSeller.company, noteSeller.adress, noteSeller.numberNip, noteSeller.accountNumber));
            Console.WriteLine();
        }


        public void totalAmount()
        {
            foreach(var item in noteClient.shopCar.shoppingCart)
            {
                total+= item.bruttoUnitPrice*item.qunatity;
            }
        }
        public string generateNoteID()
        {
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string index = noteClient.noteIndex.ToString();
            noteClient.noteIndex++;
            return "FV/" + year + "/" + month + "/" + index;
        }

        public string noteID;
        public DateTime docTime = DateTime.Now;
        public DateTime soldTime = DateTime.Now;
        public DateTime butTime = DateTime.Now.AddDays(14);
        public double total = 0;
        public Client noteClient;
        public Seller noteSeller;
    }
}
