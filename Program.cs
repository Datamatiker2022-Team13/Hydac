﻿namespace Hydac
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Old Menu
            ////*Welcome message*//
            //Console.WriteLine("Hej og velkommen");
            //Console.WriteLine("Vælg en af de nederstående muligheder \n");

            ////*Options selector 1-4*//
            //while (true)
            //{
            //    //Menu options
            //    Console.WriteLine("1. Opret gæst \n" + "2. Opret besøg\n" + "3. Oversigt af besøgene\n" + "4. Luk konsolen \n");

            //    //*Options selecter message*//
            //    Console.WriteLine("Hvad vil du vælge: ");

            //    //*Input color = Cyan*//
            //    Console.ForegroundColor = ConsoleColor.Cyan;

            //    //*String converting to INT type*//
            //    string input = Console.ReadLine();

            //    //*Resets input color*//
            //    Console.ResetColor();

            //    //*Looks if input is valid, if valid (1-4) then goes to that "Page" of invalid goes to Error section*//
            //    int res;
            //    int.TryParse(input, out res);

            //    int Sleeper = 1500;

            //    switch (res)
            //    {
            //        case 1:
            //            Console.WriteLine("Du er nu i gang med at oprette en ny gæst");
            //            break;

            //        case 2:
            //            Console.WriteLine("Du er nu i gang med at oprette et nyt besøg");
            //            break;

            //        case 3:
            //            Console.WriteLine("Her ser du en oversigt over besøgende \n");
            //            break;

            //        case 4:
            //            Console.WriteLine("Konsolen lukker om..");
            //            Thread.Sleep(Sleeper);
            //            Console.WriteLine("3..");

            //            Thread.Sleep(Sleeper);
            //            Console.WriteLine("2..");

            //            Thread.Sleep(Sleeper);
            //            Console.WriteLine("1..");

            //            Console.WriteLine("Bye bye");
            //            Thread.Sleep(Sleeper);
            //            Environment.Exit(0);

            //            break;

            //        default:
            //            Console.WriteLine("Der skete en fejl, du indtastede en invalid værdi.");
            //            break;
            //    }

            //    //*User input to continue CLEAR the console*//
            //    string Enter = "ENTER";

            //    Console.WriteLine("\nTryk " + Enter + " for at reset konsolen..");
            //    Console.ReadLine();
            //    Console.Clear();
            //}
            #endregion

            bool menuOn = true; // Turn the Menu ON/OFF

            string Exit = "Tryk ENTER for at forsætte";

            while (menuOn)
            {
                Menu MainMenu = new Menu("Hej og velkommen til HYDAC's nye system"); // Main Title for the Menu

                //Current Menu options/items with possibility on adding more depenting on the MAX set in MenuItem[]
                MainMenu.AddItem("1. Opret gæst");
                MainMenu.AddItem("2. Opret Besøg");
                MainMenu.AddItem("3. Opret oversigt af besøgende");
                MainMenu.AddItem("4. luk konsolen");


                switch (MainMenu.Selector()) //Selector that depends on the users input to show the correct thing
                {
                    case 1:
                        Console.WriteLine("Hej, her kan du oprette en ny gæst \n");
                        Console.WriteLine(Exit);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.WriteLine("Hej, her kan du oprette et nyt besøg \n");
                        Console.WriteLine(Exit);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Hej, her kan du se en oversigt over tidligere og nuværende besøgende \n");
                        Console.WriteLine(Exit);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    default: // Default error handeling message.. comes when SELECTOR's input is letter or not 1-3
                        Console.WriteLine("ERROR: Wrong input.");
                        Console.WriteLine("Press any key to reset and try again");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

                MainMenu.Show(); // Showing the menu items
                
            }
        }
        internal class Menu
        {
            public string title;

            private MenuItem[] menuItems = new MenuItem[10]; //Where the MAX is set for how many Menu options there are.. DEFAULT: 10

            private int itemCount = 0; // Used to help count up the the current option amount 

            public Menu(string title)
            {
                this.title = title;
            }

            public void Show()
            {
                Console.WriteLine(title + "\n");
                for (int i = 0; i < itemCount; i++)
                {
                    Console.WriteLine(menuItems[i].title);
                }
            }
            public void AddItem(string menuTitle)
            {
                MenuItem mi = new MenuItem("");
                mi.title = menuTitle;
                menuItems[itemCount] = mi;
                itemCount++;
            }
            public int Selector() // The Selector method
            {
                Console.WriteLine("Vælg handling: "); // Message for the Selector
                string input = Console.ReadLine();
                int selector;
                int.TryParse(input, out selector); // Checks if the user inputed something thats not a INT and try to catch it to prevet console crash....               
                return selector;
            }
            internal class MenuItem
            {
                public string title;
                public MenuItem(string ItemTitle)
                {
                    this.title = ItemTitle;

                }
            }
        }
    }
}