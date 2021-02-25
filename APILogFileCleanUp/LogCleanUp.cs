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

            string rootPath = @"C:\Users\eddie.kilgore\CleanUpTest\Test2";
   
            bool directoryExists = Directory.Exists(rootPath);
            if (directoryExists)
            {
                var files = Directory.GetFiles(rootPath);
                Console.WriteLine("The directory exists");
                foreach (var file in files)
                {
                    var info = new FileInfo(file);
                    var creationTime = info.LastWriteTime;
                    Console.WriteLine(creationTime);
                    if (creationTime < DateTime.Now.AddDays(-20))
                    {
                        Console.WriteLine(Path.GetFileName(file));
                        Console.WriteLine("YUHT");

                      // File.Delete(file);
                    }
                    else
                    {
                        Console.WriteLine("Nah");

                    }
                }
            }
            else
            {
                Console.WriteLine("The directory does not exists");
            }

            Console.ReadLine();
        }
    }
}
