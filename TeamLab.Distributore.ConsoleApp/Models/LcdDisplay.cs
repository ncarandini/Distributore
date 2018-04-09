using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLab.Distributore.ConsoleApp.Models.Interfaces;

namespace TeamLab.Distributore.ConsoleApp.Models
{
    class LcdDisplay : IDisplay
    {
        private static IDisplay current;
        public static IDisplay Current
        {
            get
            {
                if (current == null)
                {
                    current = new LcdDisplay();
                }
                return current;
            }
            private set
            {
                current = value;
            }
        }

        public void ShowMessage(string msg)
        {
            Logger.Log(this, msg);
        }
    }
}
