using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    abstract class Room
    {
        protected List<string> itemList;
        public string ListItems()
        {

            string items="";
            for(int counter =0;counter<itemList.Count ; counter++)
            {
                items += "\n" + (counter + 1) + "." + itemList[counter];
            }
            return items;
        }
        public string GetItem(int index)
        {
            if (this.Contain(index))
            {
                return itemList[index];
            }
            else
            {
                return "Invalid input";
            }
        }
        public bool RemoveFromList(int index)
        {
            if (this.Contain(index))
            {
                itemList.RemoveAt(index);
            }
            return true;
        }
        public bool Contain(int index)
        {
            return index < itemList.Capacity;
        }
        public abstract string RoomName();
    }


    class Living : Room
    {
        public Living()
        {
            itemList = new List<string>();
            itemList.Add("Couch");
            itemList.Add("DeadBody");
            itemList.Add("Broken Doorlock");
            itemList.Add("Blood spats on the wall");
            itemList.Add("Dirty footmarks on mat");
            itemList.Add("Lamps");
            itemList.Add("Coffe Table");
            itemList.Add("Shoe Rack");

        }
        public override string RoomName()
        {
            return "You are in Living Area";
        }
    }

    class Bedroom : Room
    {
        public Bedroom()
        {
            itemList = new List<string>();
            itemList.Add("Bed");
            itemList.Add("Closet");
            itemList.Add("Study Table");
            itemList.Add("Dressing Table");
            itemList.Add("Open briefcase with blood on it");
        }
        public override string RoomName()
        {
            return "You are in Bedroom";
        }
    }

    class Kitchen : Room
    {
        public Kitchen()
        {
            itemList = new List<string>();
            itemList.Add("Fridge");
            itemList.Add("Oven");
            itemList.Add("Missing knife from knives set");
            itemList.Add("Dining Table");
            itemList.Add("Dust Bins");
            itemList.Add("Two glasses of drink");
            itemList.Add("Hot pan");
        }

        public override string RoomName()
        {
            return "You are in Kitchen";
        }
    }

    class Bathroom: Room
    {
        public Bathroom()
        {
            itemList = new List<string>();
            itemList.Add("Bathtub");
            itemList.Add("Toilet Pot");
            itemList.Add("Mirror");
            itemList.Add("Towels/Napkins");
            itemList.Add("Deo Bottle, Face Wash, Soap");
        }

        public override string RoomName()
        {
            return "You are in Bathroom";
        }
    }

    class Backyard : Room
    {
        public Backyard()
        {
            itemList = new List<string>();
            itemList.Add("Lawn");
            itemList.Add("Forest behind house");
            itemList.Add("BBQ grell");
            itemList.Add("Chairs and small table");
        }

        public override string RoomName()
        {
            return "You are in Backyard";
        }
    }
}

