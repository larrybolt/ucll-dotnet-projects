using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_ConsoleApplication1
{
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <remarks></remarks>
        static void Main(string[] args)
        {
            /*
            try
            {
                using (StreamReader sr = new StreamReader("./smiley.txt"))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        foreach (char c in line)
                        {
                            ConsoleColor color;
                            switch (c)
                            {
                                case '1':
                                    color = ConsoleColor.Yellow;
                                    break;
                                case '2':
                                    color = ConsoleColor.Red;
                                    break;
                                case '3':
                                    color = ConsoleColor.White;
                                    break;
                                default:
                                    color = ConsoleColor.Black;
                                    break;

                            }
                            Console.ForegroundColor = Console.BackgroundColor = color;
                            Console.Write(' ');
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e.Message);
            }
            */
            Cat pm = new Cat("Poezemarie");
            Animal garfield = new Cat("Garfield");
            pm.PrintName();
            garfield.PrintName();

            Action<String> log = Logger.LogToConsole;
            log("testing");

            Console.ReadLine();
        }
    }
}
