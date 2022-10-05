using System.Linq;
namespace Hydac
{
    internal class Program
    {
        //static public List<Employee> employees = new List<Employee>();
        //static public List<Guest> guests = new List<Guest>();
        //static public List<Visit> visits = new List<Visit>();
        static public Room[] rooms = new Room[0];
        static public Employee[] employees = new Employee[0];
        static public Visit[] visits = new Visit[0];
        static public Guest[] guests = new Guest[0];



        // Menus
        static Menu employeeMenu, guestMenu, roomMenu, visitMenu;

        // MISC things.
        static string proceedMsg = "Tryk Enter for at forsætte";

        // Slepper timers
        static int sleeper = 1500;
        static int sleeperSmall = 1000;

        static void Main (string[] args) {
            
    
            employees = employees.Append(new Employee("Peter", "Mobbeoffer")).ToArray();
            employees = employees.Append(new Employee("peterpeter", "guitarist")).ToArray();


            rooms = rooms.Append(new Room("Lillestue")).ToArray();
            rooms = rooms.Append(new Room("Stilling kantine")).ToArray();
            rooms = rooms.Append(new Room("Stilling stueetage")).ToArray();
            rooms = rooms.Append(new Room("The Aquarium")).ToArray();
            rooms = rooms.Append(new Room("The Bridge East")).ToArray();
            rooms = rooms.Append(new Room("The Bridge West")).ToArray();
            rooms = rooms.Append(new Room("The Canteen North")).ToArray();
            rooms = rooms.Append(new Room("The Station Platform \" + \"9,75")).ToArray();
            rooms = rooms.Append(new Room("The Station Coffee Shop")).ToArray();
            rooms = rooms.Append(new Room("The Station - The Library")).ToArray();
            rooms = rooms.Append(new Room("The Training Center")).ToArray();
            rooms = rooms.Append(new Room("Lokalelille")).ToArray();
            rooms = rooms.Append(new Room("Lokaleservice")).ToArray();
            rooms = rooms.Append(new Room("Lokalestor")).ToArray();

            //rooms.Add(new Room("Lillestue"));
            //rooms.Add(new Room("Stilling kantine"));
            //rooms.Add(new Room("Stilling stueetage"));
            //rooms.Add(new Room("The Aquarium"));
            //rooms.Add(new Room("The Bridge East"));
            //rooms.Add(new Room("The Bridge West"));
            //rooms.Add(new Room("The Canteen North"));
            //rooms.Add(new Room("The Station Platform " + "9,75"));
            //rooms.Add(new Room("The Station Coffee Shop"));
            //rooms.Add(new Room("The Station - The Library"));
            //rooms.Add(new Room("The Training Center"));
            //rooms.Add(new Room("Lokalelille"));
            //rooms.Add(new Room("Lokaleservice"));
            //rooms.Add(new Room("Lokalestor"));

            DataHandler _guestHandler = new DataHandler("..\\..\\..\\GuestDataList.txt");
            DataHandler _visitHandler = new DataHandler("..\\..\\..\\VisitDataList.txt");

            guests = _guestHandler.LoadGuests();
            visits = _visitHandler.LoadVisits();

            UpdateMenus();

            // set window size manually to ensure all visits fit inside the console window
            Console.SetWindowSize(135, 30);

            bool run = true;
            while (run) {
                Menu MainMenu = new Menu("Hej og velkommen til HYDAC's nye kom/gå system", 4); // Main Title for the Menu

                MainMenu.AddItem("Opret gæst");
                MainMenu.AddItem("Opret besøg");
                MainMenu.AddItem("Se oversigt over besøg");
                MainMenu.AddItem("Luk program");

                switch (MainMenu.Selector("Vælg handling:")) //Selector that depends on the users input to show the correct thing
                {
                    case 0:
                        Console.Clear();
                        RegisterGuest();
                        break;

                    case 1:
                        Console.Clear();
                        RegisterVisit();
                        break;

                    case 2:
                        Console.Clear();
                        visitMenu.Show();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Konsolen lukker om 3... \n");
                        Thread.Sleep(sleeper);
                        Console.WriteLine("Konsolen lukker om 2... \n");
                        Thread.Sleep(sleeper);
                        Console.WriteLine("Konsolen lukker om 1... \n");
                        Thread.Sleep(sleeper);

                        _guestHandler.SaveGuests(guests);
                        _visitHandler.SaveVisits(visits);

                        run = false;
                        break;

                    default: // Default error handeling message.. comes when SELECTOR's input is letter or not 1-4
                        Console.WriteLine("How did you get here?");
                        break;
                }
            }
        }

        static private void RegisterGuest () {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Du er nu i gang med at oprette en ny gæst..  husk at udfylde alle kravende   ");
            Console.WriteLine("----------------------------------------------------------------------------- \n");
            Console.WriteLine(proceedMsg);
            Console.ReadKey();
            Console.Clear();

            //--------//
            string name;
            do {
                name = GetUserInputString("Hvilket navn har gæsten?: ", 24);
            } while (!GetConfirmation(name));
            //--------//

            string firm;
            do {
                firm = GetUserInputString("Hvilken virksomhed kommer gæsten fra?: ", 24);
            } while (!GetConfirmation(firm));
            //--------//

            string mail;
            do {
                mail = GetUserInputString("Hvad er gæstens arbejds email?: ", 29);
            } while (!GetConfirmation(mail));
            //--------//

            guests = guests.Append(new Guest(mail, name, firm)).ToArray();
            //guests.Add(new Guest(mail, name, firm));
            UpdateMenus();

            Console.WriteLine("Saved Data: ");
            Console.WriteLine("-----------");
            Console.WriteLine("Navn:             " + name);
            Console.WriteLine("Virksomhed:       " + firm);
            Console.WriteLine("Virksomehedsmail: " + mail);
            Console.WriteLine("-----------");
        }

        static void RegisterVisit () {
            //TODO:
            //  DateOnly date
            //  TimeOnly startTime
            //  TimeOnly endTime

            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Du er nu igang med at oprette et nyt besøg.. husk at udfylde alle kravende");
            Console.WriteLine("----------------------------------------------------------------------------- \n");
            Console.WriteLine(proceedMsg);
            Console.ReadKey();
            Console.Clear();

            int guestSelection;
            do { guestSelection = guestMenu.Selector("Vælg gæst:"); }
            while (!GetConfirmation(guests[guestSelection].Name));

            int employeeSelection;
            do { employeeSelection = employeeMenu.Selector("Vælg medarbejder:"); }
            while (!GetConfirmation(employees[employeeSelection].GetName()));

            int roomSelection;
            do { roomSelection = roomMenu.Selector("Vælg rum:"); }
            while (!GetConfirmation(rooms[roomSelection].GetName()));

            // TODO: BOOL INPUT

            // register newly created visit, based on information inputted by the user
            visits = visits.Append(new Visit(
                new DateOnly(1, 1, 1),
                new TimeOnly(1, 1),
                new TimeOnly(1, 1),
                guests[guestSelection],
                employees[employeeSelection], 
                rooms[roomSelection],
                true)).ToArray();
            //visits.Add(new Visit(
                //new DateOnly(1, 1, 1),
                //new TimeOnly(1, 1),
                //new TimeOnly(1, 1),
                //guests[guestSelection],
                //employees[employeeSelection],
                //rooms[roomSelection],
                //true));

            UpdateMenus();

            Console.WriteLine("-----------");
            Console.WriteLine("Gæst navn: " + guests[guestSelection].Name);
            Console.WriteLine("Medarbejder: " + employees[employeeSelection].GetName());
            Console.WriteLine("Rum valg: " + rooms[roomSelection].GetName());
            Console.WriteLine("-----------");
        }

        #region Guard Methods
        static private bool IsNull (string input) {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) {
                Console.Clear();
                Console.WriteLine("Error: No input was detected");
                Console.WriteLine(proceedMsg);
                Console.ReadKey();
                Console.Clear();

                return true;
            }
            return false;
        }

        static private bool IsNumber (string input) {
            if (double.TryParse(input, out _)) {
                Console.Clear();
                Console.WriteLine("Error: Invalid input, can't accept numbers (Ints)");
                Console.WriteLine(proceedMsg);
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            return false;
        }

        static private bool IsOverLimit (string input, int lengthLimit) {
            if (input.Length > lengthLimit) {
                Console.Clear();
                Console.WriteLine("Error: Invalid input, the input can't be longer than " + lengthLimit + ".");
                Console.WriteLine(proceedMsg);
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            return false;
        }
        #endregion

        static string GetUserInputString (string prompt, int lengthLimit) {
            string name = string.Empty;

            bool notValidInput = true;
            while (notValidInput) {
                Console.WriteLine(prompt);
                name = Console.ReadLine();

                if (!IsNull(name) && !IsNumber(name) && !IsOverLimit(name, lengthLimit))
                    notValidInput = false;
            }

            return name;
        }

        static private bool GetConfirmation (string input) {
            Console.WriteLine("Er du sikker på at du vil gemme " + input + " (Ja: Y / Nej: N)");
            input = Console.ReadLine().ToLower();

            if (input == "y" || input == "ja" || input == "yes" || input == "j") {
                Console.WriteLine("Saving data... \n");
                Thread.Sleep(sleeperSmall);
                Console.WriteLine("Data saved..");
                Thread.Sleep(sleeperSmall);
                Console.Clear();
                return true;
            }
            else {
                Console.WriteLine("Error: Data not saved..");
                Console.WriteLine(proceedMsg);
                Console.ReadLine();
                Console.Clear();
                return false;
            }


        }

        static void UpdateMenus () {
            employeeMenu = new Menu(string.Format("Vælg:\t{0,-12} {1,-10}", "Navn:", "Stilling:"), employees.Length);
            for (int i = 0; i < employees.Length; i++) {
                employeeMenu.AddItem(employees[i].ToString());
            }

            guestMenu = new Menu(string.Format("Vælg:\t{0,-25} {1,-25} {2,-30}", "Navn:", "Firma:", "Firma mail:"), guests.Length);
            for (int i = 0; i < guests.Length; i++) {
                guestMenu.AddItem(guests[i].ToString());
            }

            roomMenu = new Menu("Vælg:\tRum navn:", rooms.Length);
            for (int i = 0; i < rooms.Length; i++) {
                roomMenu.AddItem(rooms[i].ToString());
            }

            visitMenu = new Menu(string.Format("Vælg:\t{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", "Dato:", "Tidsrum:", "Gæstens Navn:", "Ansattes Navn:", "Lokale:", "Sikkerhedsfolder"), visits.Length);
            for (int i = 0; i < visits.Length; i++) {
                visitMenu.AddItem(visits[i].ToString());
            }
        }
    }
}