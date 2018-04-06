using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLab.Distributore.ConsoleApp.Models.Interfaces
{
    interface ICasher
    {
        /// <summary>
        /// Incrementa il credito residuo
        /// </summary>
        /// <param name="moneta">Valore da sommare al credito residuo</param>
        void InserisciMoneta(int moneta);

        /// <summary>
        /// Restituisce tutto il credito
        /// </summary>
        void RestituisciCredito();

        /// <summary>
        /// Calcola il resto e lo rilascia all'utente
        /// </summary>
        /// <param name="costo">Costo effettivo del prodotto</param>
        void DaiResto(int costo);

        /// <summary>
        /// Controlla se il credito è sufficiente
        /// </summary>
        /// <param name="costo">Costo effettivo del prodotto</param>
        /// <returns>Ritorna true se il credito è sufficiente, altrimenti ritorna false</returns>
        bool CheckSaldo(int costo);
    }
}