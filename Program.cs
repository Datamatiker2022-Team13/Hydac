using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static Hydac.Menu;

namespace Hydac
{
    internal class Program
    {
        static private DataHandler _guestHandler;
        static private DataHandler _visitHandler;

        static public List<Employee> employees = new List<Employee>();
        static public List<Guest> guests = new List<Guest>();
        static public List<Room> rooms = new List<Room>();
        static public List<Visit> visits = new List<Visit>();
        
        static void Main(string[] args)
        {
            DataHandler _guestHandler = new DataHandler("GuestDataList.txt");
            DataHandler _visitHandler = new DataHandler("VisitDataList.txt");

            Employee peter = new Employee("Peter", "Mobbeoffer");
            employees.Add(peter);
            Employee peterpeter = new Employee("peterpeter", "guitarist");
            employees.Add(peterpeter);
            Guest hans = new Guest("atvftw@gmail.com", "Hans-i Henterseer", "Schlager Musiccxxxx");
            guests.Add(hans);
            Guest hansi = new Guest("isuckdi@cks.com", "Hansi-i Henterseer", "Schlager Musiccxxxx");
            guests.Add(hansi);
            Room akvarie = new Room("Akvariet");
            Visit firstVisit = new Visit(new DateOnly(2020, 10, 30), new TimeOnly(15, 30), new TimeOnly(16, 30), hans, peter, akvarie, true, new DateOnly(2020, 10, 30));
            Visit secondVisit = new Visit(new DateOnly(10, 1, 1), new TimeOnly(0, 0), new TimeOnly(0, 5), hans, peter, akvarie, false, new DateOnly(1, 1, 1));

            visits.Add(firstVisit);
            visits.Add(secondVisit);

            rooms.Add(new Room("Lillestue"));
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

            Menu employeeMenu = new Menu(String.Format("Vælg:\t{0,-12} {1,-10}", "Navn:", "Stilling:"), employees.Count);
            for (int i = 0; i < employees.Count; i++)
            {
                employeeMenu.AddItem(employees[i].ToString());

            }

            Menu guestsMenu = new Menu(String.Format("Vald:\t{0,-25} {1,-25} {2,-30}", "Navn:", "Firma:", "Firma mail:"), guests.Count);
            for (int i = 0; i < guests.Count; i++) 
            {
                guestsMenu.AddItem(guests[i].ToString());
            }

            Menu roomMenu = new Menu("Vælg:\tRum navn:", rooms.Count);
            for (int i = 0; i < rooms.Count; i++)
            {
                roomMenu.AddItem(rooms[i].ToString());
            }

            Menu visitMenu = new Menu(string.Format("Vælg:\t{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20}", "Dato:", "Tidsrum:", "Gæstens Navn:", "Ansattes Navn:", "Lokale:", "Sikkerhedsfolder", "Dato Modtaget"), visits.Count);
            for (int i = 0; i < visits.Count; i++)
            {
                visitMenu.AddItem(visits[i].ToString());
            }

            string Continue = "Tryk Enter for at forsætte"; //Default ENTER message            
            string ErrorData = "Error: Data not saved..";
            string DataSaving = "\nGemmer data... \n";
            string DataSaved = "Data gemt.."; 

            int Sleeper = 1500; // Default timer
            int sleeperSmall = 1000;


            while (true)
            {
                Menu MainMenu = new Menu("Hej og velkommen til HYDAC's nye kom/gå system",5); // Main Title for the Menu

                //Current Menu options/items with possibility on adding more depenting on the MAX set in MenuItem[]
                MainMenu.AddItem("Opret gæst");
                MainMenu.AddItem("Opret Besøg");
                MainMenu.AddItem("Opret oversigt af besøgende");
                MainMenu.AddItem("luk konsolen");
                
                MainMenu.Show();

                switch (MainMenu.Selector() + 1) //Selector that depends on the users input to show the correct thing
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
                                Console.WriteLine("Er du sikker på at du vil gemme: " + name + " (Ja: Y / Nej: N)");
                                string inputName = Console.ReadLine().ToLower();
                                
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

                        Console.WriteLine("Nummeret på gæsten: ");
                        guestsMenu.Show();
                        int guestSelection = guestsMenu.Selector();
                        Console.WriteLine("Er du sikker på at navnet på gæsten er: " + guests[guestSelection].GetName() + " (Ja: Y / Nej: N)");

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

                        employeeMenu.Show();
                        
                        Console.WriteLine("Indtast venligst nummeret på den ansvarlige medarbejder: ");

                        int employeeSelection = employeeMenu.Selector();

                        Console.WriteLine("Er du sikker på at: '" + employees[employeeSelection].GetName() + "' er den ansvarlige medarbejder for mødet? (Ja: Y / Nej: N)");
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

                        roomMenu.Show();
                        

                        Console.WriteLine("\nHvilket rum bliver brugt til mødet? : ");
                        int roomSelection = roomMenu.Selector();

                        Console.WriteLine("Er du sikker på at: '" + rooms[roomSelection].GetName() + "' bliver brugt til mødet? (Ja: Y / Nej: N)");
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
                        Console.WriteLine("Gæst navn: " + guests[guestSelection].GetName());
                        Console.WriteLine("Medarbejder: " + employees[employeeSelection].GetName());
                        Console.WriteLine("Rum valg: " + rooms[roomSelection].GetName());
                        break;
                    case 3:
                        Console.WriteLine("Her ser du en liste over besøgende.\n");
                        Console.WriteLine("Tryk Enter for at forsætte");
                        Console.ReadLine();
                        visitMenu.Show();
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

    }
}