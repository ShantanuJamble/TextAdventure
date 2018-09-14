using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Controller
    {
        private static Controller control;
        string input;

        private Controller()
        {
            input = "";
        }

        public static Controller Control
        {
            get
            {
                if(control == null)
                {
                    control = new Controller();
                }
                return control;
            }
        }
        
        public string ReadUserInput()
        {
            input = Console.ReadLine();
            if (ValidateInput() == false)
            {
                input = "Invalid";

            }
            return input;
        }


        
        private bool ValidateInput()
        {
            char[] str = input.ToCharArray();
            foreach (char c in str)
            {
                if (char.IsLetterOrDigit(c) == false && char.IsWhiteSpace(c) == false)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
