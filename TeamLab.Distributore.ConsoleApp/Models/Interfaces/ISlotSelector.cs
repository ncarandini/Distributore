using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeamLab.Distributore.ConsoleApp.Models.SlotSelector;

namespace TeamLab.Distributore.ConsoleApp.Models.Interfaces
{
    interface ISlotSelector
    {
        //Use case: 1 selezione prodotto 

        event Action<string, int> SlotSelected;

        void InsertCode(string code);
        void ProdottoErogato(string slotid);


    }
}
