using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using static Hydac.Program.Menu;

namespace Hydac
{
    internal class Program
    {
        static public List<Employee> employees = new List<Employee>();
        static public List<Guest> guests = new List<Guest>();
        static public List<Room> rooms = new List<Room>();
        static public List<Visit> visits = new List<Visit>();
        
        static void Main(string[] args)
        {
            string Continue = "Tryk Enter for at forsætte"; //Default ENTER message            
            int Sleeper = 1500; // Default timer
            int sleeperSmall = 1000;

            while (true)
            {
                Menu MainMenu = new Menu("Hej og velkommen til HYDAC's nye kom/gå system"); // Main Title for the Menu

                //Current Menu options/items with possibility on adding more depenting on the MAX set in MenuItem[]
                MainMenu.AddItem("1. Opret gæst");
                MainMenu.AddItem("2. Opret Besøg");
                MainMenu.AddItem("3. Opret oversigt af besøgende");
                MainMenu.AddItem("4. luk konsolen");
                
                MainMenu.Show();

                switch (MainMenu.Selector()) //Selector that depends on the users input to show the correct thing
                {
                        #region Opret Gæst
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Du er nu i gang med at oprette en ny gæst..  husk at udfylde alle kravende");
                        Console.WriteLine(Continue);
                        Console.ReadKey();
                        Console.Clear();

                        //--------//

                        string name;

                        while (true)
                        {
                            Console.WriteLine("Hvad er navnet på gæsten: ");
                            name = Console.ReadLine();
                            
                            Console.WriteLine("Er du sikker på at du vil gemme: " + name + " (Ja: Y / Nej: N)");
                            string inputName = Console.ReadLine().ToLower();
                           
                            if (inputName == "y" || inputName == "ja" || inputName == "yes")
                            {
                                Console.WriteLine("Gemmer data...");
                                Thread.Sleep(sleeperSmall);
                                Console.WriteLine("Navnet er gemt..");
                                Thread.Sleep(sleeperSmall);
                                Console.Clear();
                                break;
                                
                            }
                            else
                            {
                                Console.WriteLine("Error: Data not saved.. ");
                                Console.WriteLine(Continue);
                                Console.ReadLine();
                                Console.Clear();
                                
                            }
                        }

                        //--------//

                        string firm;
                        while (true)
                        {
                            Console.WriteLine("Hvor kommer gæsten fra?: ");
                            firm = Console.ReadLine();

                            Console.WriteLine("Er du sikker på at du vil genmme virksomheden: " + firm + " (Ja: Y / Nej: N)");
                            string inputFirm = Console.ReadLine().ToLower();

                            if (inputFirm == "y" || inputFirm == "ja" || inputFirm == "yes")
                            {
                                Console.WriteLine("Gemmer data...");
                                Thread.Sleep(sleeperSmall);
                                Console.WriteLine("Firma navnet er gemt..");
                                Thread.Sleep(sleeperSmall);
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error: Data not saved.. ");
                                Console.WriteLine(Continue);
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        #endregion
                        //--------//
                        #region Sikkerheldsfolder
                        //string folder;
                        //bool sfolder = false;
                        //while (true)
                        //{
                        //    Console.WriteLine("Har gæsten fået deres sikkerhedsfolder? (Ja: Y / Nej: N)");
                        //    folder = Console.ReadLine().ToLower();

                        //    if (folder == "y" || folder == "ja")
                        //    {
                        //        sfolder = true;
                        //        Console.WriteLine("Gemmer data...");
                        //        Thread.Sleep(sleeperSmall);
                        //        Console.WriteLine("Værdien er nu gemt..");
                        //        Thread.Sleep(sleeperSmall);
                        //        Console.Clear();
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Error: Data not saved.. ");
                        //        Console.WriteLine(Continue);
                        //        Console.ReadLine();
                        //        Console.Clear();
                        //        sfolder = false;
                        //    }

                        //}
                        #endregion
                        //--------//

                        Console.WriteLine("Gemte data");
                        Console.WriteLine("-----------");
                        Console.WriteLine("Navn: " + name);
                        Console.WriteLine("Virksomhed: " + firm);
                        Console.WriteLine("-----------");


                        break;

                    case 2:

                        //TODO:
                        //  DateOnly date
                        //  TimeOnly startTime
                        //  TimeOnly endTime

                        Console.WriteLine("Du er nu igang med at oprette et nyt besøg.. husk at udfylde alle kravende");
                        Console.WriteLine(Continue);
                        Console.ReadKey();
                        Console.Clear();

                        //--------//

                        Console.WriteLine("Navnet på gæsten: ");
                        string guestName = Console.ReadLine();  

                        Console.WriteLine("Er du sikker på at navnet på gæsten er: '" + guestName + "' (Ja: Y / Nej: N)");
                        string inputGuestName = Console.ReadLine();

                        if (inputGuestName == "Y")
                        {
                            Console.WriteLine("Gemmer data...");
                            Thread.Sleep(sleeperSmall);
                            Console.WriteLine("Gæsten er gemt..");
                            Thread.Sleep(sleeperSmall);
                            Console.Clear();
                        }
                        else
                        {
                            //TODO
                        }

                        //--------//

                        Console.WriteLine("Navnet på den ansvarlige medarbejder: ");
                        string employeeName = Console.ReadLine();

                        Console.WriteLine("Er du sikker på at: '" + employeeName + "' er den ansvarlige medarbejder for mødet? (Ja: Y / Nej: N)");
                        string inputEmployeeName = Console.ReadLine();

                        if (inputGuestName == "Y")
                        {
                            Console.WriteLine("Gemmer data...");
                            Thread.Sleep(sleeperSmall);
                            Console.WriteLine("Ansvarlige er gemt..");
                            Thread.Sleep(sleeperSmall);
                            Console.Clear();
                        }
                        else
                        {
                            //TODO
                        }

                        //--------//

                        Console.WriteLine("Hvilket rum bliver brugt til mødet? : ");
                        string roomName = Console.ReadLine();

                        Console.WriteLine("Er du sikker på at: '" + roomName + "' bliver brugt til mødet? (Ja: Y / Nej: N)");
                        string inputRoomName = Console.ReadLine();

                        if (inputRoomName == "Y")
                        {
                            Console.WriteLine("Gemmer data...");
                            Thread.Sleep(sleeperSmall);
                            Console.WriteLine("rummet er gemt..");
                            Thread.Sleep(sleeperSmall);
                            Console.Clear();
                        }
                        else
                        {
                            //TODO
                        }
                        Console.WriteLine("Gemte data:");
                        Console.WriteLine("Gæst navn: " + guestName);
                        Console.WriteLine("Medarbejder: " + employeeName);
                        Console.WriteLine("Sikkerhedsfolder: " + roomName);
                        break;
                    case 3:
                        Console.WriteLine("Her ser du en liste over besøgende.\n");
                        Console.WriteLine("Tryk Enter for at forsætte");
                        Console.ReadLine();
                        Console.Clear();



                        break;

                    case 4:
                        Console.WriteLine("Tryk ENTER for at bekræfte at du vil lukke konsolen \n");

                        Console.ReadKey();
                        Thread.Sleep(Sleeper);

                        Console.WriteLine("Konsolen lukker om 3... \n");
                        Thread.Sleep(Sleeper);

                        Console.WriteLine("Konsolen lukker om 2... \n");
                        Thread.Sleep(Sleeper);

                        Console.WriteLine("Konsolen lukker om 1... \n");
                        Thread.Sleep(Sleeper);

                        Environment.Exit(0);

                        break;

                    default: // Default error handeling message.. comes when SELECTOR's input is letter or not 1-4
                        Console.WriteLine("How did you get here?");
                        break;
                }               
            }
        }
        internal class Menu
        {
            public string title;

            private MenuItem[] menuItems = new MenuItem[5]; //Where the MAX is set for how many Menu options there are.. DEFAULT: 10

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
                MenuItem mi = new MenuItem(menuTitle);
                menuItems[itemCount] = mi;
                itemCount++;
            }
            public int Selector() // The Selector method
            {
                int selection;

                while (true)
                {
                    Console.WriteLine("\nVælg handling: "); // Message for the Selector
                    string input = Console.ReadLine();

                    bool input1 = int.TryParse(input, out selection);

                    if (input1 == true)
                    {
                        if (selection >= 0 && selection <= itemCount)
                        {
                            return selection;
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
}