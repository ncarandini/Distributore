using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLab.Distributore.ConsoleApp.Models;
using TeamLab.Distributore.ConsoleApp.Models.Interfaces;

namespace TeamLab.Distributore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDispencer dispencer = Dispencer.CreaDispencer();
            dispencer.SelezionaSlot("QWERTY");
            dispencer.RichiediResto();
            dispencer.SelezionaSlot("A1");
            dispencer.AggiungiCredito(20);
            dispencer.SelezionaSlot("A1");
            dispencer.AggiungiCredito(200);
            dispencer.AggiungiCredito(20);
            dispencer.AggiungiCredito(10);
            dispencer.SelezionaSlot("A1");
            dispencer.RichiediResto();
        }
    }
}