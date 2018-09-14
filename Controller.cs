using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Controller
    {
        string input;

        public Controller()
        {
            input = "";
        }

        /// <summary>
        /// Reads user input 
        /// </summary>
        /// <returns>
        /// returns user input
        /// </returns>
        public string ReadUserInput()
        {
            input = Console.ReadLine();
            if (ValidateInput() == false)
            {
                input = "Invalid input!!";
                
            }
            return input;
        }
        /// <summary>
        /// Checks if input has special chars
        /// </summary>
        /// <returns>
        /// Returns true if valid, else false
        /// </returns>
        private bool ValidateInput()
        {
            char[] str = input.ToCharArray();
            foreach (char c in str)
            {
                if (char.IsLetterOrDigit(c) == false && char.IsWhiteSpace(c) == false) { 
                    return false;
                }

            }
            return true;
        }
    }
}
