using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;



namespace ConsoleHW1_3
{
    class Menu
    {
        public static void Switch(string userInput, string sPath, string tPath)
        {
            //用Switch依使用者輸入執行選單功能
            userInput = userInput.ToUpper();
            switch (userInput)
            {

                case "MOVEFILE":
                    Function1.MoveFile(sPath, tPath);
                    break;
                case "COPYFILE":
                    Function1.CopyFile(sPath, tPath);
                    break;
                case "READFILE":
                    Function1.ReadFile(sPath);
                    break;
                case "DELETEFILE":
                    Function1.DeleteFile(sPath);
                    break;
                case "CREATEFOLDER":
                    Function1.CreateFolder(sPath);
                    break;
                case "DELETEFOLDER":
                    Function1.DeleteFolder(sPath, tPath);
                    break;
                default:
                    Console.Write("\n輸入錯誤");
                    Console.ReadLine();
                    break;
            }

        }
    }
    class Function1
    {
        public static void MoveFile(string source, string target)
        {
            
            ExistorNot.Exists(source, target); //判斷檔案是否存在或重覆

            /*
            ///執行功能前要求User確認
            ///輸入Y->執行功能 
            ///輸入N->回到選單 
            ///輸入其他->要求重輸入Y/N
             */
            Console.Write("\n是否確認要移動檔案(Y/N):");
            string confirm = Console.ReadLine();
            confirm = confirm.ToLower();
            if (confirm == "y" || confirm == "yes")
            {
                DateTime startTime = DateTime.Now;//計時程式使用時間
                File.Move(source, target);
                DateTime endTime = DateTime.Now;
                TimeSpan ts = endTime - startTime;
                Console.WriteLine("\n檔案移動完成");
                Console.WriteLine($"\n共耗時 {ts.TotalSeconds} 秒");
            }
            else if (confirm == "n" || confirm == "no")
            {
                Console.Write("\n結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            else
            {
                Console.WriteLine("\n輸入錯誤,結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            Console.ReadLine();
            Environment.Exit(Environment.ExitCode);
        }

        public static void CopyFile(string source, string target)
        {
            ExistorNot.Exists(source, target);//判斷檔案是否存在或重覆

            /*
            ///執行功能前要求User確認
            ///輸入Y->執行功能 
            ///輸入N->回到選單 
            ///輸入其他->要求重輸入Y/N
             */
            Console.Write("\n是否確認要複製檔案(Y/N):");
            string confirm = Console.ReadLine();
            confirm = confirm.ToLower();
            if (confirm == "y" || confirm == "yes")
            {
                DateTime startTime = DateTime.Now;
                File.Copy(source, target);
                DateTime endTime = DateTime.Now;
                TimeSpan ts = endTime - startTime;
                Console.WriteLine("\n檔案複製完成");
                Console.WriteLine($"\n共耗時 {ts.TotalSeconds} 秒");
            }
            else if (confirm == "n" || confirm == "no")
            {
                Console.WriteLine("\n結束程式");
                Environment.Exit(Environment.ExitCode);

            }
            else
            {
                Console.WriteLine("\n輸入錯誤,結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            Console.ReadLine();
            Environment.Exit(Environment.ExitCode);
        }

        public static void ReadFile(string source)
        {
            ExistorNot.Exists(source);//判斷檔案是否存在或重覆

            /*
            ///執行功能前要求User確認
            ///輸入Y->執行功能 
            ///輸入N->回到選單 
            ///輸入其他->要求重輸入Y/N
             */
            Console.Write("\n是否確認要閱讀檔案(Y/N):");
            string confirm = Console.ReadLine();
            confirm = confirm.ToLower();
            if (confirm == "y" || confirm == "yes")
            {
                DateTime startTime = DateTime.Now;
                string cotent = File.ReadAllText(source);
                Console.WriteLine();
                Console.WriteLine(cotent);
                DateTime endTime = DateTime.Now;
                TimeSpan ts = endTime - startTime;
                Console.WriteLine("\n讀檔完成");
                Console.WriteLine($"\n共耗時 {ts.TotalSeconds} 秒");
            }
            else if (confirm == "n" || confirm == "no")
            {
                Console.WriteLine("\n結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            else
            {
                Console.WriteLine("\n輸入錯誤,結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            Console.ReadLine();
            Environment.Exit(Environment.ExitCode);
        }

        public static void DeleteFile(string source)
        {
            ExistorNot.Exists(source);//判斷檔案是否存在

            /*
            ///執行功能前要求User確認
            ///輸入Y->執行功能 
            ///輸入N->回到選單 
            ///輸入其他->要求重輸入Y/N
             */
            Console.Write("\n是否確認要刪除檔案(Y/N):");
            string confirm = Console.ReadLine();
            confirm = confirm.ToLower();
            if (confirm == "y" || confirm == "yes")
            {
                DateTime startTime = DateTime.Now;
                DirectoryInfo di = new DirectoryInfo(source);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                DateTime endTime = DateTime.Now;
                TimeSpan ts = endTime - startTime;
                Console.WriteLine("\n檔案刪除完成");
                Console.WriteLine($"\n共耗時 {ts.TotalSeconds} 秒");
            }
            else if (confirm == "n" || confirm == "no")
            {
                Console.WriteLine("\n結束程式");
                Environment.Exit(Environment.ExitCode); Console.Write("\n請重新輸入想要執行的功能: ");
                
            }
            else
            {
                Console.WriteLine("\n輸入錯誤,結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            Console.ReadLine();
            Environment.Exit(Environment.ExitCode);
        }

        public static void CreateFolder(string source)
        {
            if (Directory.Exists(source))//判斷資料夾是否存在
            {
                Console.WriteLine($"\n已經有同名資料夾存在");
                Console.ReadLine();
                Environment.Exit(Environment.ExitCode);
            }

            /*
            ///執行功能前要求User確認
            ///輸入Y->執行功能 
            ///輸入N->回到選單 
            ///輸入其他->要求重輸入Y/N
             */

            Console.Write("\n是否確認要建立資料夾(Y/N):");
            string confirm = Console.ReadLine();
            confirm = confirm.ToLower();
            if (confirm == "y" || confirm == "yes")
            {
                DateTime startTime = DateTime.Now;
                Directory.CreateDirectory(source);
                DateTime endTime = DateTime.Now;
                TimeSpan ts = endTime - startTime;
                Console.WriteLine("\n資料夾建立完成");
                Console.WriteLine($"\n共耗時 {ts.TotalSeconds} 秒");
            }
            else if (confirm == "n" || confirm == "no")
            {
                Console.WriteLine("\n結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            else
            {
                Console.WriteLine("\n輸入錯誤,結束程式");
                Environment.Exit(Environment.ExitCode); 
                
            }
            Console.ReadLine();
            Environment.Exit(Environment.ExitCode);
        }

        public static void DeleteFolder(string source, string target)
        {
            if (!Directory.Exists(source))//判斷資料夾是否存在
            {
                Console.WriteLine($"\n要刪除的資料夾不存在");
                Console.ReadLine();
                Environment.Exit(Environment.ExitCode);
            }

            /*
            ///執行功能前要求User確認
            ///輸入Y->執行功能 
            ///輸入N->回到選單 
            ///輸入其他->要求重輸入Y/N
             */
            Console.Write("\n是否確認要刪除資料夾(Y/N):");
            string confirm = Console.ReadLine();
            confirm = confirm.ToLower();
            if (confirm == "y" || confirm == "yes")
            {
                DateTime startTime = DateTime.Now;
                DirectoryInfo difolder = new DirectoryInfo(source);
                foreach(FileInfo file in difolder.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in difolder.GetDirectories())
                {
                    dir.Delete(true);
                }
                Directory.Delete(source);
                DateTime endTime = DateTime.Now;
                TimeSpan ts = endTime - startTime;
                Console.WriteLine("\n資料夾刪除完成");
                Console.WriteLine($"\n共耗時 {ts.TotalSeconds} 秒");
            }
            else if (confirm == "n" || confirm == "no")
            {
                Console.WriteLine("\n結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            else
            {
                Console.WriteLine("\n輸入錯誤,結束程式");
                Environment.Exit(Environment.ExitCode);
            }
            Console.ReadLine();
            Environment.Exit(Environment.ExitCode);
        }

    }
}
