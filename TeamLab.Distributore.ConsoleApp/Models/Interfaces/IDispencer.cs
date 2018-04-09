using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLab.Distributore.ConsoleApp.Models.Interfaces
{
    /*  Use Case:
        1 Il prodotto è disponibile, il credito è sufficiente, eroga prodotto.
        2 Il prodotto è disponibile, il credito è 0, mostra il prezzo del prodotto.
        3 Il prodotto è disponibile, il credito è inferiore al costo, mostra la differenza tra il prodotto e il credito.
    */

    interface IDispencer
    {
        IDispencer CreaDispencer();

        void AggiungiCredito(int moneta);
        void RichiediResto();
        void SelezionaSlot(string codice);
    }
    

}
