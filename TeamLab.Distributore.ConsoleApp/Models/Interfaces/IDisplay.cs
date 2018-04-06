using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLab.Distributore.ConsoleApp.Models.Interfaces
{
    interface IDisplay
    {
        /// <summary>
        /// Mostra il messaggio sul display
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
}
