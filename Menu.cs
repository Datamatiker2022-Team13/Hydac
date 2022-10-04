using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hydac.Program;

namespace Hydac
{
    public class Menu
    {
        public string title;

        private MenuItem[] menuItems; //Where the MAX is set for how many Menu options there are.. DEFAULT: 10

        private int itemCount = 0; // Used to help count up the the current option amount 

        public Menu(string title, int size)
        {
            this.title = title;
            menuItems = new MenuItem[size];
        }

        public void Show()
        {
            Console.WriteLine(title + "\n");
            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i].title);
            }
        }
        public void AddItem(string menuTitle)
        {
            MenuItem mi = new MenuItem(menuTitle);
            menuItems[itemCount] = mi;
            itemCount++;
        }
        public int Selector(string promptMsg) // The Selector method
        {

            int selection;
            while (true)
            {
                Show();

                Console.WriteLine("\n" + promptMsg); // Message for the Selector
                string input = Console.ReadLine();

                bool input1 = int.TryParse(input, out selection);

                if (input1 == true)
                {
                    if (selection >= 1 && selection <= itemCount)
                    {
                        return selection - 1;
                    }

                    // easter egg
                    if (selection == 301097 || 
                        selection == 270400 || 
                        selection == 270696 ||
                        selection == 020298 ||
                        selection == 101291 ||
                        selection == 010100) {
                        SpinningCube.ShowCube();

                        Console.Clear();
                        Console.WriteLine("A... spinning... cube?\n" +
                            "Yeah, I mean, no, no, it's very impressive...\n" );
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }

                Console.WriteLine("ERROR: Wrong input.");
                Console.WriteLine("Press any key to reset and try again");
                Console.ReadKey();
                Console.Clear();
            }
        }
        internal class MenuItem
        {
            public string title;
            public MenuItem(string ItemTitle)
            {
                title = ItemTitle;

            }
        }
    }
}
