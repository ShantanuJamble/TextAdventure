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
            Console.WriteLine("|Kitchen |  |Living|         |\n");
            Console.WriteLine("|Bedroom |  |Bathroom|       N\n");
            Console.WriteLine("-----------------------------");
            return true;
        }

        public void DisplayHelp()
        {
            string help = "\nYou can use following commands to play" +
                "\nn->move north\n" +
                "s->move south\n" +
                "e->move east\n" +
                "w->move west\n" +
                "look->look around\n" +
                "pick->pick up thing\n" +
                "map->pull up level map\n" +
                "room->to see where are you now\n" +
                "q->exit'n" +
                "Collect all the five clues and you can help solve the case!!!!";
            this.UpdateDisplay(help);
        }
        public bool UpdateDisplay(string str)
        {
            if (str == null)
            {
                return false;
            }
            else
            {
                Console.Write(str);

            }
            return true;
        }
    }
}
