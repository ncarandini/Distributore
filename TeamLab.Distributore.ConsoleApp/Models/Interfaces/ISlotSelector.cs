using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLab.Distributore.ConsoleApp.Models.Interfaces
{
    interface ISlotSelector
    {
        bool getCode(String code);
        void sendData();
    }
}
