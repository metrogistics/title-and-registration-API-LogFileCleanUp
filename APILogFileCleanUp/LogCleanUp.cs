using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace APILogFileCleanUp
{
    class LogCleanUp
    {
        static void Main(string[] args)
        {

            string rootPath = @"C:\Users\eddie.kilgore\CleanUpTest\Test2";//What it will be=> @"C:\inetpub\wwwroot\_Log";
           
            bool directoryExists = Directory.Exists(rootPath);
            if (directoryExists)
            {
               // var files = Directory.GetFiles(rootPath);
                var files = Directory.GetFiles(rootPath,"*.txt");
                Console.WriteLine("The directory exists");
                foreach (var file in files)
                {
                    var info = new FileInfo(file);
                    var LastWriteTime = info.LastWriteTime;
                    Console.WriteLine(LastWriteTime);
                    StreamWriter log;

                    if (LastWriteTime < DateTime.Now.AddDays(-5))
                    {
                       
                        //Console.WriteLine(Path.GetFileName(file));//Don't need
                        //Console.WriteLine("YUHT");
                        if (!File.Exists("logfile.txt"))
                        {
                            log = new StreamWriter("logfile.txt");
                        }
                        else
                        {
                            log = File.AppendText("logfile.txt");
                        }
                        log.Write(Path.GetFileName(file));
                        log.WriteLine(" "+DateTime.Now);
                        log.WriteLine();
                        log.Close();
                        File.Delete(file);
                    }
                    //else
                    //{
                    //    Console.WriteLine("Nah");
                       
                    //}
                  
                }
            }
            else
            {
                Console.WriteLine("The directory does not exists");
            }
           
            Console.ReadLine();//Will have to remove so it closes at finish.
        }
    }
}
