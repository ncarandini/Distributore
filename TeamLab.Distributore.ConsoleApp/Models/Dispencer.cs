﻿using System;
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
        }

        /// <summary>
        /// Metodo che crea un dispencer
        /// </summary>
        /// <returns></returns>
        public IDispencer CreaDispencer()
        {
            return new Dispencer(new LcdDisplay(), new SlotSelector(), new Casher());
            
        }

        public void SlotSelected(string slotId, int price)
        {
            bool creditoSufficiente = casher.CreditoSufficiente(price);
            if(creditoSufficiente)
            {
                casher.Incassa(price);
                ErogaProdotto(slotId);
            }
            else
            {
                display.ShowMessage("Esci i soldi Poraccio!");
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

