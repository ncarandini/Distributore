using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLab.Distributore.ConsoleApp.Models.Interfaces;

namespace TeamLab.Distributore.ConsoleApp.Models
{
    class SlotSelector : ISlotSelector
    {

        public delegate void SlotSelectedHandler(String slotId, int price);
        public event SlotSelectedHandler SlotSelected;

        IDisplay display;
        List<Product> Products;

        public SlotSelector()
        {
            Products = new List<Product>();
            display = LcdDisplay.Current;
            Load("ABC");
        }

       public bool VerificaCodice(string code)
        {
            
            bool verificato = false;
            foreach(Product i in Products)
            {
                if (i.Code == code && i.Quantità>0 )
                {
                    verificato = true;
                    break; }
            }
            return verificato;            
        }

        public void ProdottoErogato(string slotid)
        {
            foreach (Product i in Products)
                if (i.Code == slotid)
                {
                    --i.Quantità;
                }
        }    

        private void Load(string s)
        {
            Random random = new Random();
            foreach (char c in s)
            {
                for (int i = 1; i < 4; i++)
                {
                    Product product = new Product
                    {
                        Price = random.Next(50, 200),
                        Code = c + i.ToString(),
                        Quantità = random.Next(0, 10)
                    };
                    Products.Add(product);
                }
            }
        }

        public void InsertCode(string code)
        {
            Logger.Log(this, $"E' stato inserito il codice {code}");
            foreach (Product product in Products )
            {
                Logger.Log(this, $"{product.Code} {product.Quantità} {product.Price}");
            }
            
            if (VerificaCodice(code))
            {
                Logger.Log(this, $"Il codice {code} corrisponde ad uno slot non vuoto");

                int index = Products.FindIndex(p => p.Code == code);
                SlotSelected(code, Products[index].Price);
            }
            else
            {
                Logger.Log(this, $"Il codice {code} non corrisponde ad uno slot");
                display.ShowMessage("Prodotto selezionato non disponibile");
            }
                

            
        }
    }
}
