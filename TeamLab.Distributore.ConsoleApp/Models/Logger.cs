using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLab.Distributore.ConsoleApp.Models
{
    public static class Logger
    {
        public static void Log(object sender, string msg)
        {
            string emitter = sender.GetType().Name;
            Console.WriteLine($"{DateTime.Now} [{emitter}] {msg}");
        }
    }
}
