using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLab.Distributore.ConsoleApp.Models.Interfaces;

namespace TeamLab.Distributore.ConsoleApp.Models
{
    class Casher : ICasher
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

        public bool CheckSaldo(int costo)
        {
            bool risultato = false;

            if(creditoResiduo >= costo)
            {
                risultato = true;
            }

            return risultato;
        }

        public void DaiResto(int costo)
        {
            int resto = creditoResiduo - costo;
            creditoResiduo = 0;
        }

        public void InserisciMoneta(int moneta)
        {
            creditoResiduo += moneta;
        }
    }
}