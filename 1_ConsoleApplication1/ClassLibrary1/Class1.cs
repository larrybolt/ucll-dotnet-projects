using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Animal
    {
        public Animal(string name)
        {
            _name = name;
        }
        public virtual void PrintName()
        {
            Console.WriteLine("Animal name: " + this.Name);
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
        private string _name;
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }

        override public void PrintName()
        {
            Console.WriteLine("Cats name:" + Name);
        }
    }

    public static class Logger
    {
        public static void LogToConsole(string message)
        {
            // write the message to the console
            Console.WriteLine(message);
        }
        public static void LogToFile(string message)
        {
            // write the message to a file 'log.txt' located on the desktop
            string filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                "log.txt"
            );
            File.AppendAllText(filename, message + Environment.NewLine);
        }
    }
}
