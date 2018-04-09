using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLab.Distributore.ConsoleApp.Models;
using TeamLab.Distributore.ConsoleApp.Models.Interfaces;

namespace TeamLab.Distributore.ConsoleApp.Models
{
    public class Casher : ICasher
    {
        private int creditoResiduo;
        
        public Casher()
        {
            creditoResiduo = 0;
            Logger.Log(this, "sono stato istanziato");
        }

        public void RestituisciCredito()
        {
            int creditoRestituito = creditoResiduo;
            creditoResiduo = 0;
            Logger.Log(this, $"sono stati restituiti {creditoRestituito} cent.");
        }

        public int CreditoDisponibile()
        {
            Logger.Log(this, $"Il credito disponibile è pari a: {creditoResiduo}");
            return creditoResiduo;
        }

        public void Incassa(int costo)
        {
            creditoResiduo -= costo;
            Logger.Log(this, $"sono stati sottratti {costo} cent. Rimangono {creditoResiduo} cent.");
        }

        public void InserisciMoneta(int moneta)
        {
            creditoResiduo += moneta;
            Logger.Log(this, $"sono stati inseriti {moneta} cent. Credito attuale {creditoResiduo}");
        }

    }
}