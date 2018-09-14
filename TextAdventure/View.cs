using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class View
    {
        private static View display;

        View()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static View Display
        {
            get
            {
                if(display == null)
                {
                    display = new View();
                }
                return display;
            }
        }
        public bool DisplayMap()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|Backyard|                   ^\n");
            Console.WriteLine("|Kitchen |  |Dining|         |\n");
            Console.WriteLine("|Bedroom |  |Living|         N\n");
            Console.WriteLine("-----------------------------");
            return true;
        }
        public bool UpdateDisplay(string str)
        {
            if (str == null)
            {
                return false;
            }
            else
            {
                Console.WriteLine(str);

            }
            return true;
        }
    }
}
