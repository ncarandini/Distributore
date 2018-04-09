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

        List<Product> Products;

        public SlotSelector()
        {
            Products = new List<Product>();

            Load("ABC");
        }

       public bool InsertCode(string code)
        {
            
            bool verificato = false;
            foreach(Product i in Products)
            {
                if (i.Code == code )
                {
                    verificato = true;
                    break; }
            }
            return verificato;            
        }

        public void ProdottoErogato(string slotid)
        {

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
                        Code = c + i.ToString()
                    };
                    Products.Add(product);
                }
            }
        }

        public void InsertCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
