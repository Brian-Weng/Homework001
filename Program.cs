using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHW1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = args[0];
            string sPath = args[1];
            string tPath = args[2];

            Menu.Switch(userInput, sPath, tPath);

        }
    }
}
