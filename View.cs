using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class View
    {
        View()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public bool DisplayString(string str)
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
