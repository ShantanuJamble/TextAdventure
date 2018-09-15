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
        private int[,] roommap;
        private View display;
        private Controller control;
        private string input;
        private Room[] room ;
        private int currentroom;
        private int[] currentlocation;
        private List<string> clues;
        private List<string> answers;

        private Gamelogic()
        {

            roommap = new int[3, 3]
                        {
                            {4,0,0},
                            {2,1,0},
                            {5,3,0}
                        };
            room = new Room[6];
            room[1] = new Living();
            room[2] = new Kitchen();
            room[3] = new Bathroom();
            room[4] = new Backyard();
            room[5] = new Bedroom();

            currentroom = 1;
            currentlocation = new int[2] { 1, 1 };
            clues = new List<string>();
            display = View.Display;
            control = Controller.Control;
            input = null;

            answers = new List<string>();
            answers.Add("Dirty Footsteps");
            answers.Add("Blood spats on the wall");
            answers.Add("DeadBody");
            answers.Add("Broken Doorlock");
            answers.Add("Two glasses of drink");
            answers.Add("Missing knife from knives set");
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
                "the murder." +
                "You will be spawned in Living area of house" +
                
                "\n\nYou can use following commands to play" +
                "\nn->move north\n" +
                "s->move south\n" +
                "e->move east\n" +
                "w->move west\n" +
                "look->look around\n" +
                "pick->pick up thing\n" +
                "map->pull up level map\n" +
                "room->to see where are you now\n"+
                "q->exit\n" +
                "help->get help\n"+
                "Collect all the five clues and you can help solve the case!!!!" +
                "\n\n" +
                "Following is the layout of house\n\n");
            display.DisplayMap();
            this.Play();

        }

        public void Play()
        {
            
            while (true) {
                display.UpdateDisplay(">");
                input = control.ReadUserInput();
                if (isWin())
                {
                    display.UpdateDisplay("All clues Collected. You Won!!\n\n");
                    Environment.Exit(0);
                }
                switch (input)
                {
                    case "n":
                    case "s":
                    case "e":
                    case "w":
                        this.MovePlayer(input);
                        break;
                    case "look":
                        
                        display.UpdateDisplay(room[currentroom].ListItems());
                        display.UpdateDisplay("\n");
                        break;

                    case "room":
                        display.UpdateDisplay(room[currentroom].RoomName());
                        display.UpdateDisplay("\n");
                        break;

                    case "help":
                        display.DisplayHelp();
                        display.UpdateDisplay("\n");
                        break;

                    case "pick":
                        this.PickItem();
                        break;

                    case "map":
                        display.DisplayMap();
                        break;

                    case "q":
                        if (isWin())
                        {
                            display.UpdateDisplay("All clues Collected. You Won!!\n\n");
                        }
                        else
                        {
                            display.UpdateDisplay("All clues are not Collected. You Lost!!\n\n");
                        }
                        Environment.Exit(0);
                        break;
                }
            }
        }


        private void MovePlayer(string move)
        {
            int row = currentlocation[0];
            int column = currentlocation[1];
            switch (move)
            {
                case "s":
                    if(row+1<3 && roommap[row+1,column] != 0)
                    {
                        currentlocation[0] = row + 1;
                        currentroom = roommap[currentlocation[0], currentlocation[1]];
                    }
                    else
                    {
                        display.UpdateDisplay("Can't go there\n");
                    }
                    break;
                case "n":
                    if (row - 1 >= 0 && roommap[row - 1, column] != 0)
                    {
                        currentlocation[0] = row - 1;
                        currentroom = roommap[currentlocation[0], currentlocation[1]];
                    }
                    else
                    {
                        display.UpdateDisplay("Can't go there\n");
                    }
                    break;
                case "e":
                    if (column + 1 < 3 && roommap[row , column+1] != 0)
                    {
                        currentlocation[1] = column + 1;
                        currentroom = roommap[currentlocation[0], currentlocation[1]];
                    }
                    else
                    {
                        display.UpdateDisplay("Can't go there\n");
                    }
                    break;
                case "w":
                    if (column-1 >= 0 && roommap[row, column-1] != 0)
                    {
                        currentlocation[1]=column-1;
                        currentroom = roommap[currentlocation[0], currentlocation[1]];
                    }
                    else
                    {
                        display.UpdateDisplay("Can't go there\n");
                    }
                    break;
            }
            display.UpdateDisplay(currentlocation[0]+" "+currentlocation[1]+" "+currentroom);
        }

        private void PickItem()
        {
            display.UpdateDisplay("Select number of object you want to pick\n>");
            int index = Int32.Parse(control.ReadUserInput());
            if (room[currentroom].Contain(index))
            { 
                string clue = room[currentroom].GetItem(index-1);
                if (clue.Equals("Invalid input"))
                {
                    display.UpdateDisplay("Invalid Input");
                }
                else
                {
                    clues.Add(clue);
                    room[currentroom].RemoveFromList(index - 1);
                    display.UpdateDisplay(clue + " Picked Up!\n\nYour List:");
                    display.UpdateDisplay(String.Join(",", clues));
                    display.UpdateDisplay("\n");
                }
            }

            return;
        }

        private bool isWin()
        {
            int count = 0;
            for (int i = 0; i < answers.Count; i++)
            {
                if (clues.Contains(answers[i]))
                {
                    count++;
                    //clues.Remove(answers[i]);
                }
            }
            return count==answers.Capacity;
        }
    }
}
