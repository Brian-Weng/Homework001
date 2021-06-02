using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleHW1_3
{
    class ExistorNot
    {
        //建立Method判斷來源或目標是否存在
        public static void Exists(string sPath, string tPath)
        {

            if (!File.Exists(sPath))//判斷來源檔案是否存在
            {
                Console.WriteLine($"\n來源{sPath}檔並不存在");
                Console.ReadLine();
                Environment.Exit(Environment.ExitCode);
            }

            if (File.Exists(tPath))////判斷目標檔案是否存在
            {
                Console.WriteLine($"\n目標資料夾已有相同檔案");
                Console.ReadLine();
                Environment.Exit(Environment.ExitCode);
            }

        }

        public static void Exists(string sPath)
        {
            
            if (!File.Exists(sPath))//判斷來源檔案是否存在
            {
                Console.WriteLine($"\n來源{sPath}檔並不存在");
                Console.ReadLine();
                Environment.Exit(Environment.ExitCode);
            }

        }


    }
}
