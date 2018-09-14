using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Gamelogic
    {
        //Run method
        //player movment
        //Update the player location
        // we need to somehow map rooms to indices
        private static Gamelogic game = null;
        private string[,] levelmap;
        private View display;
        private Controller control;
        private string input;

        private Gamelogic()
        {
            levelmap = new string[3, 3] {
                            {"Backyard","",""},
                            {"Kitchen","Dining",""},
                            {"Bedrrom","Living",""}
                        };
            display = View.Display;
            control = Controller.Control;
            input = null; 
        }

        public static Gamelogic Game
        {
            get
            {
                if(game == null)
                {
                    game = new Gamelogic();
                }
                return game;
            }
        }

        public void Start()
        {
            display.UpdateDisplay("There has been a gruesome murder in a house" +
                " and you\nas my junior detective are here to help investigation.\n" +
                "Follow your instincts to find all the clues necessary \nto solve " +
                "the murder. " +
                
                "\n\nYou can use following commands to play" +
                "\nn->move north\n" +
                "s->move south\n" +
                "e->move east\n" +
                "w->move west\n" +
                "look->look around\n" +
                "pick->pick up thing\n" +
                "map->pull up level map\n" +
                "q->exit'n"+
                "Collect all the five clues and you can help solve the case!!!!" +
                "\n\n" +
                "Following is the layout of house\n\n");
            display.DisplayMap();
            this.Play();

        }

        public void Play()
        {
            
            while (true) {
                input = control.ReadUserInput();
                switch (input)
                {
                    case "n":
                        display.UpdateDisplay("Moving nort");
                        break;
                    case "s":
                        display.UpdateDisplay("Moving nort");
                        break;
                    case "e":
                        display.UpdateDisplay("Moving nort");
                        break;
                    case "w":
                        display.UpdateDisplay("Moving nort");
                        break;
                    case "look":
                        display.UpdateDisplay("Moving nort");
                        break;
                    case "map":
                        display.DisplayMap();
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                }
            }
        }


    }
}
