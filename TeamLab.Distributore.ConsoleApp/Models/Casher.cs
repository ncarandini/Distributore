using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLab.Distributore.ConsoleApp.Models.Interfaces;

namespace TeamLab.Distributore.ConsoleApp.Models
{
    public class Casher : ICasher
    {
        private int creditoResiduo;

        public Casher()
        {
            creditoResiduo = 0;
        }

        public void RestituisciCredito()
        {
            int creditoRestituito = creditoResiduo;
            creditoResiduo = 0;
        }

        public bool CreditoSufficiente(int costo)
        {
            return creditoResiduo >= costo;
        }

        public void Incassa(int costo)
        {
            creditoResiduo -= costo;
        }

        public void InserisciMoneta(int moneta)
        {
            creditoResiduo += moneta;
        }

    }
}