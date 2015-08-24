using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            string paths;
            //characters used for parsing
            string[] separator = new string[] { "d-" , "D-"};
            //starting notes
            Console.WriteLine("please enter up to 3 directory paths with the prefix d- followed by the path");
            //get paths
            paths = Console.ReadLine();
            // Parse out all of the file paths were put in and store them in path
            string[] path = paths.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //loop through the paths and check each file size on a seperate thread using Parallel
            Parallel.ForEach(path, currentPath =>
            {
                //check if the directory is available or valid
                if (Directory.Exists(currentPath))
                {
                 //write out which threads are being used for each directory
                Console.WriteLine("Processing {0} on thread {1}", currentPath, Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(" ");
                Console.WriteLine("--------------------");
                //call the function that calculates the directory size
                Console.WriteLine("Directory Path {0}. The total file size in Bytes is {1}",  currentPath, GetDirSize.DirSize.GetDirectorySize(currentPath));
                Console.WriteLine(" ");
                Console.WriteLine("--------------------");
                }
                //what to do if the directory does not exist
                else if (!Directory.Exists(currentPath))
                {
                    Console.WriteLine("the directory {0} does not exists", currentPath);
                }
                //something else went wrong
                else
                {
                    Console.WriteLine("something else went wrong");
                    
                }

            });
            
            Console.Read();

        }

    }
}
