using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static Hydac.Menu;

namespace Hydac
{
    internal class Program
    {
        static public List<Employee> employees = new List<Employee>();
        static public List<Guest> guests = new List<Guest>();
        static public List<Room> rooms = new List<Room>();
        static public List<Visit> visits = new List<Visit>();
        //MISC things.
        static string Continue = "Tryk Enter for at forsætte";

        //Slepper timers
        static int Sleeper = 1500;
        static int sleeperSmall = 1000;

        static void Main(string[] args)
        {
            Employee peter = new Employee("Peter", "Mobbeoffer");
            Guest hans = new Guest("atvftw@gmail.com", "Hans-i Henterseer", "Schlager Musiccxxxx");
            Room akvarie = new Room("Akvariet");
            Visit firstVisit = new Visit(new DateOnly(2020, 10, 30), new TimeOnly(15, 30), new TimeOnly(16, 30), hans, peter, akvarie, true, new DateOnly(2020, 10, 30));
            Visit secondVisit = new Visit(new DateOnly(10, 1, 1), new TimeOnly(0, 0), new TimeOnly(0, 5), hans, peter, akvarie, false, new DateOnly(1, 1, 1));

            visits.Add(firstVisit);
            visits.Add(secondVisit);



            while (true)
            {
                Menu MainMenu = new Menu("Hej og velkommen til HYDAC's nye kom/gå system");

                MainMenu.AddItem("1. Opret gæst");
                MainMenu.AddItem("2. Opret Besøg");
                MainMenu.AddItem("3. Opret oversigt af besøgende");
                MainMenu.AddItem("4. luk konsolen");
                MainMenu.Show();

                switch (MainMenu.Selector())
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.WriteLine("Du er nu i gang med at oprette en ny gæst..  husk at udfylde alle kravende   ");
                        Console.WriteLine("----------------------------------------------------------------------------- \n");
                        Console.WriteLine(Continue);
                        Console.ReadKey();
                        Console.Clear();

                        //--------//
                        string name;
                        do
                        {
                            name = GetUserInputString("Hvilket navn har gæsten?: ");
                        } while (!Confirmation(name));
                        //--------//

                        string firm;
                        do
                        {
                            firm = GetUserInputString("Hvilken virksomhed kommer gæsten fra?: ");
                        } while (!Confirmation(firm));
                        //--------//

                        string mail;
                        do
                        {
                            mail = GetUserInputString("Hvad er gæstens arbejds email?: ");
                        } while (!Confirmation(mail));
                        //--------//

                        guests.Add(new Guest(mail, name, firm));

                        Console.WriteLine("Saved Data: ");
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

                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.WriteLine("Du er nu igang med at oprette et nyt besøg.. husk at udfylde alle kravende");
                        Console.WriteLine("----------------------------------------------------------------------------- \n");
                        Console.WriteLine(Continue);
                        Console.ReadKey();
                        Console.Clear();

                        //--------//
                        string guest;
                        do
                        {
                            guest = GetUserInputString("Navnet på gæsten: ");
                        } while (!Confirmation(guest));
                        
                        //--------//

                        Console.WriteLine("Navnet på den ansvarlige medarbejder: ");
                        string employeeName = Console.ReadLine();

                        Console.WriteLine("Er du sikker på at: '" + employeeName + "' er den ansvarlige medarbejder for mødet? (Ja: Y / Nej: N)");
                        string inputEmployeeName = Console.ReadLine();

                        if (inputEmployeeName == "Y")
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

                        //Console.WriteLine("Gemte data:");
                        //Console.WriteLine("Gæst navn: " + guestName);
                        //Console.WriteLine("Medarbejder: " + employeeName);
                        //Console.WriteLine("Sikkerhedsfolder: " + roomName);
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
        static private bool IsNull(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                Console.WriteLine("Error: No input was detected");
                Console.WriteLine(Continue);
                Console.ReadKey();
                Console.Clear();

                return true;
            }
            return false;
        }

        static private bool IsNumber(string input)
        {
            if (double.TryParse(input, out _))
            {
                Console.Clear();
                Console.WriteLine("Error: Invalid input, can't accept numbers (Ints)");
                Console.WriteLine(Continue);
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            return false;
        }

        static string GetUserInputString(string prompt)
        {
            string name = string.Empty;

            bool notValidInput = true;
            while (notValidInput)
            {
                Console.WriteLine(prompt);
                name = Console.ReadLine();

                if (!IsNull(name) && !IsNumber(name))
                    notValidInput = false;
            }

            return name;
        }

        static private bool Confirmation(string input)
        {
            Console.WriteLine("Er du sikker på at du vil gemme " + input + " (Ja: Y / Nej: N)");
            input = Console.ReadLine().ToLower();

            if (input == "y" || input == "ja" || input == "yes" || input == "j")
            {
                Console.WriteLine("Saving data... \n");
                Thread.Sleep(sleeperSmall);
                Console.WriteLine("Data saved..");
                Thread.Sleep(sleeperSmall);
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Error: Data not saved..");
                Console.WriteLine(Continue);
                Console.ReadLine();
                Console.Clear();
                return false;
            }
        }

        static bool SecurityInput(string input)
        {
            bool result = false;

            if (input == "y" || input == "ja" || input == "yes" || input == "j")
            {
                result = true;
                return result;
            }
            return result;
        }
    }
}