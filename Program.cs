using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using static Hydac.Menu;

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
            Employee peter = new Employee("Peter", "Mobbeoffer");
            Guest hans = new Guest("Hans-i Henterseer", "Schlager Musiccxxxx");
            Room akvarie = new Room("Akvariet");
            Visit firstVisit = new Visit(new DateOnly(2020, 10, 30), new TimeOnly(15, 30), new TimeOnly(16, 30), hans, peter, akvarie, true, new DateOnly(2020, 10, 30));
            Visit secondVisit = new Visit(new DateOnly(10, 1, 1), new TimeOnly(0, 0), new TimeOnly(0, 5), hans, peter, akvarie, false, new DateOnly(1, 1, 1));

            visits.Add(firstVisit);
            visits.Add(secondVisit);

            string Continue = "Tryk Enter for at forsætte"; //Default ENTER message            
            string ErrorData = "Error: Data not saved..";
            string DataSaving = "\n Gemmer data... \n";
            string DataSaved = "Data gemt.."; 

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

                            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                            {
                                Console.Clear();
                                Console.WriteLine("Error: You didn't input anyting.. try something like (Bob, Mathias, Jan osv..)");
                                Console.WriteLine(Continue);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (name.All(char.IsDigit))
                            {
                                Console.Clear();
                                Console.WriteLine("Error: You can't input INTEGAR as a option");
                                Console.WriteLine(Continue);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                if (inputName == "y" || inputName == "ja" || inputName == "yes" || inputName == "j")
                                {
                                    Console.WriteLine(DataSaving);
                                    Thread.Sleep(sleeperSmall);
                                    Console.WriteLine(DataSaved);
                                    Thread.Sleep(sleeperSmall);
                                    Console.Clear();
                                    break;
                                }                                
                                else
                                {
                                    Console.WriteLine(ErrorData);
                                    Console.WriteLine(Continue);
                                    Console.ReadLine();
                                    Console.Clear();                                
                                }
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

                            if (inputFirm == "y" || inputFirm == "ja" || inputFirm == "yes" || inputFirm == "j")
                            {
                                Console.WriteLine(DataSaving);
                                Thread.Sleep(sleeperSmall);
                                Console.WriteLine(DataSaved);
                                Thread.Sleep(sleeperSmall);
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine(ErrorData);
                                Console.WriteLine(Continue);
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        string mail;
                        while (true)
                        {
                            Console.WriteLine("Virksomheds emailen på gæsten: ");
                            mail = Console.ReadLine();

                            Console.WriteLine("Er du sikker på at " + mail+ "er den korrekte email? (Ja: Y / Nej: N)");
                            string inputMail = Console.ReadLine().ToLower();

                            if (inputMail == "ja" || inputMail == "yes" || inputMail == "y" || inputMail == "j")
                            {
                                Console.WriteLine(DataSaving);
                                Thread.Sleep(sleeperSmall);
                                Console.WriteLine(DataSaved);
                                Thread.Sleep(sleeperSmall);
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine(ErrorData);
                                Console.WriteLine(Continue);
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }

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
                        Console.WriteLine("Navn:             " + name);
                        Console.WriteLine("Virksomhed:       " + firm);
                        Console.WriteLine("Virksomehedsmail: " + mail);
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
                            Console.WriteLine("\n Gemmer data...");
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
                        rooms.Add(new Room("lillestue"));
                        rooms.Add(new Room("Stilling kantine"));
                        rooms.Add(new Room("Stilling stueetage"));
                        rooms.Add(new Room("The Aquarium"));
                        rooms.Add(new Room("The Bridge East"));
                        rooms.Add(new Room("The Bridge West"));
                        rooms.Add(new Room("The Canteen North"));
                        rooms.Add(new Room("The Station Platform " + "9,75"));
                        rooms.Add(new Room("The Station Coffee Shop"));
                        rooms.Add(new Room("The Station - The Library"));
                        rooms.Add(new Room("The Training Center"));
                        rooms.Add(new Room("Lokalelille"));
                        rooms.Add(new Room("Lokaleservice"));
                        rooms.Add(new Room("Lokalestor"));

                        Console.WriteLine("");
                            



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
                        ShowVisits();
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

        static private void ShowVisits()
        {
            if (visits.Count > 0)
            {
                foreach (Visit visit in visits) //Where the Program calls and prints the list for each "visit" in the <Visit> list through the "Show" method
                {
                    visit.Show();
                    Console.WriteLine();
                }
            }
            
            
        }

    }
}