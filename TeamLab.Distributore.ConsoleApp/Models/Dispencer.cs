using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLab.Distributore.ConsoleApp.Models.Interfaces;

namespace TeamLab.Distributore.ConsoleApp.Models
{
    class Dispencer : IDispencer
    {
        IDisplay display;
        ISlotSelector slotSelector;
        ICasher casher;

        public int Id { get; set; }


        private Dispencer(IDisplay display, ISlotSelector slotSelector, ICasher casher)
        {
            this.display = display;
            this.slotSelector = slotSelector;
            this.casher = casher;

            slotSelector.SlotSelected += SlotSelected;
        }

        /// <summary>
        /// Metodo che crea un dispencer
        /// </summary>
        /// <returns></returns>
        public static IDispencer CreaDispencer()
        {
            return new Dispencer(LcdDisplay.Current, new SlotSelector(), new Casher());
        }

        public void SlotSelected(string slotId, int price)
        {
            bool creditoSufficiente = price <= casher.CreditoDisponibile();
            if(creditoSufficiente)
            {
                casher.Incassa(price);
                ErogaProdotto(slotId);
                slotSelector.ProdottoErogato(slotId);
            }
            else
            {
                int differenzaDerPoraccio = price - casher.CreditoDisponibile();
                display.ShowMessage($"Esci i soldi Poraccio! (e ne devi caccià na cifra, pari a {differenzaDerPoraccio} ");
                Logger.Log(this, "Credito insufficiente");
            }

        }

        public void ErogaProdotto(string slotId)
        {
            display.ShowMessage("Erogazione in corso...");
            Logger.Log(this, $"Erogazione prodotto dallo slot {slotId}");
            display.ShowMessage(string.Empty);
        }

        public void AggiungiCredito(int moneta)
        {
            if (casher != null)
            {
                casher.InserisciMoneta(moneta);
            }
        }

        public void RichiediResto()
        {
            casher.RestituisciCredito();
        }

        public void SelezionaSlot(string codiceSlot)
        {
            slotSelector.InsertCode(codiceSlot);
        }
    }
}

