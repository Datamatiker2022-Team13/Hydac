using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Hydac
{
    internal class Program
    {
        // initialization of the lists used for different classes
        static public List<Room> rooms = new List<Room>();
        static public List <Employee> employees = new List <Employee>();
        static public List <Visit> visits = new List<Visit>();
        static public List <Guest> guests = new List<Guest>();

        // menu(s)
        static Menu employeeMenu, guestMenu, roomMenu, visitMenu;

        // helper string(s)
        static string proceedMsg = "Tryk Enter for at forsætte";
        static string borderMsg = "-----------------------------------------------------------------------------";

        // sleep timer(s)
        static int sleeper = 1000;

        static void Main (string[] args) {
            #region Initialization
            // registers all the deduced employees
            employees.Add(new Employee("Rene Hansen"));
            employees.Add(new Employee("Daniel Ross"));
            employees.Add(new Employee("Kasper Kant"));
            employees.Add(new Employee("Jesper Salin"));
            employees.Add(new Employee("Per Salin"));

            // registers all the provided rooms
            rooms.Add(new Room("Lillestue"));
            rooms.Add(new Room("Stilling kantine"));
            rooms.Add(new Room("Stilling stueetage"));
            rooms.Add(new Room("The Aquarium"));
            rooms.Add(new Room("The Bridge East"));
            rooms.Add(new Room("The Bridge West"));
            rooms.Add(new Room("The Canteen North"));
            rooms.Add(new Room("The Station Platform 9 3/4"));
            rooms.Add(new Room("The Station Coffee Shop"));
            rooms.Add(new Room("The Station - The Library"));
            rooms.Add(new Room("The Training Center"));
            rooms.Add(new Room("Lokalelille"));
            rooms.Add(new Room("Lokaleservice"));
            rooms.Add(new Room("Lokalestor"));
            #endregion

            DataHandler _guestHandler = new DataHandler("..\\..\\..\\GuestDataList.txt");
            DataHandler _visitHandler = new DataHandler("..\\..\\..\\VisitDataList.txt");

            guests = _guestHandler.LoadGuests();
            visits = _visitHandler.LoadVisits();

            UpdateMenus();

            // set window size manually to ensure all visits fit inside the console window
            Console.SetWindowSize(135, 30);

            bool run = true;
            while (run) {
                Menu MainMenu = new Menu("Hej og velkommen til HYDAC's nye kom/gå system", 4); // sets the mainMenu title

                MainMenu.AddItem("Opret gæst");
                MainMenu.AddItem("Opret besøg");
                MainMenu.AddItem("Se oversigt over besøg");
                MainMenu.AddItem("Luk program");

                switch (MainMenu.GetSelection("Vælg handling:")) // selector that returns a valid menu selection
                {
                    case 0:
                        // begin guest registration process
                        Console.Clear();
                        RegisterGuest();
                        _guestHandler.SaveGuests(guests); // save newly registrered guest
                        break;

                    case 1:
                        // begin visit registration process
                        Console.Clear();
                        RegisterVisit();
                        _visitHandler.SaveVisits(visits); // save newly registrered visit
                        break;

                    case 2:
                        // show all registrered visits
                        Console.Clear();
                        visitMenu.Show();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        // close the console
                        Console.Clear();
                        Console.WriteLine("Konsolen lukker om 3... \n");
                        Thread.Sleep(sleeper);
                        Console.WriteLine("Konsolen lukker om 2... \n");
                        Thread.Sleep(sleeper);
                        Console.WriteLine("Konsolen lukker om 1... \n");
                        Thread.Sleep(sleeper);
                         // set run to false to exit the while loop
                        run = false;
                        break;

                    default: // default error handling message - we should NEVER arrive here
                        Console.WriteLine("How did you get here?");
                        break;
                }
            }
        }

        // these methods are used when registrering guests and visits
        #region Register methods
        static void RegisterGuest () {
            Console.Clear();
            Console.WriteLine(borderMsg);
            Console.WriteLine("Du er nu i gang med at oprette en ny gæst.");
            Console.WriteLine(borderMsg + "\n");
            Console.WriteLine(proceedMsg);
            Console.ReadLine();
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

            // Add's a new Guest
            guests.Add(new Guest(mail, name, firm));
            UpdateMenus();

            Console.WriteLine("Saved Data: ");
            Console.WriteLine(borderMsg);
            Console.WriteLine("Navn:             " + name);
            Console.WriteLine("Virksomhed:       " + firm);
            Console.WriteLine("Virksomehedsmail: " + mail);
            Console.WriteLine(borderMsg + "\n");
            Console.WriteLine(proceedMsg);
            Console.ReadLine();
        }

        static void RegisterVisit () {


            Console.Clear();
            Console.WriteLine(borderMsg);
            Console.WriteLine("Du er nu igang med at oprette et nyt besøg.. husk at udfylde alle kravende");
            Console.WriteLine(borderMsg + "\n");
            Console.WriteLine(proceedMsg);
            Console.ReadLine();
            Console.Clear();

            DateOnly visitDate = GetUserInputDate("Dato for besøget?: (DD/MM/YYYY)");
            TimeOnly startTime = GetUserInputTime("Starttidspunktet for besøget: (HH:MM)");
            TimeOnly endTime = GetUserInputTime("Sluttidspunktet for besøget: (HH:MM)");

            int guestSelection;
            do { guestSelection = guestMenu.GetSelection("Vælg gæst:"); }
            while (!GetConfirmation(guests[guestSelection].Name));

            int employeeSelection;
            do { employeeSelection = employeeMenu.GetSelection("Vælg medarbejder:"); }
            while (!GetConfirmation(employees[employeeSelection].Name));

            int roomSelection;
            do { roomSelection = roomMenu.GetSelection("Vælg rum:"); }
            while (!GetConfirmation(rooms[roomSelection].Name));

            bool safetyFlyerRecieved = GetUserInputBool("Blev der udleveret sikkerhedsfolder(ere) under besøget?: (\"Ja\" eller \"Nej\")");

            // register newly created visit, based on information inputted by the user
            visits.Add(new Visit(
                visitDate,
                startTime,
                endTime,
                guests[guestSelection],
                employees[employeeSelection], 
                rooms[roomSelection],
                safetyFlyerRecieved));

            UpdateMenus();

            Console.WriteLine("Saving data... \n");
            Thread.Sleep(sleeper);
            Console.WriteLine("Data saved..");
            Thread.Sleep(sleeper);
            Console.Clear();

            Console.WriteLine(borderMsg);
            Console.WriteLine("Dato:                       " + visitDate.ToString());
            Console.WriteLine("Start tid:                  " + startTime.ToString());
            Console.WriteLine("Slut tid:                   " + endTime.ToString());
            Console.WriteLine("Gæst navn:                  " + guests[guestSelection].Name);
            Console.WriteLine("Medarbejder:                " + employees[employeeSelection].Name);
            Console.WriteLine("Rum valg:                   " + rooms[roomSelection].Name);
            Console.WriteLine("Sikkerhedsfolder udleveret: " + safetyFlyerRecieved);
            Console.WriteLine(borderMsg);
        }
        #endregion

        // these methods get input from the user, and perform all necessary error handling
        #region getUserInput methods
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

        static bool GetUserInputBool (string prompt) {
            while (true) {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "y" || userInput == "ja" || userInput == "yes" || userInput == "j")
                    return true;
                if (userInput == "n" || userInput == "nej" || userInput == "no")
                    return false;
                
                if (!IsNull(userInput) && !IsNumber(userInput)) {
                    Console.Clear();
                    Console.WriteLine("Fejl! Inputtet skal være enten \"Ja\" eller \"Nej\".\n" +
                        "Der skelnes ikke mellem store og små bogstaver.");
                    Console.WriteLine(proceedMsg);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        
        static DateOnly GetUserInputDate(string prompt)
        {
            DateOnly date;

            while (true)
            {                
                Console.WriteLine(prompt);

                string userInput = Console.ReadLine();

                if (!IsNull(userInput))
                {
                    if (DateOnly.TryParse(userInput, out date))
                    {
                        return date;
                    }
                    Console.WriteLine("Error: Invalid date.. ");
                    Console.WriteLine("Try something like 10/10/2022 or 10-10-2022 insted \n");
                    Console.WriteLine(proceedMsg);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        static TimeOnly GetUserInputTime(string prompt)
        {
            TimeOnly Time;

            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (!IsNull(userInput))
                {
                    if (TimeOnly.TryParse(userInput, out Time))
                    {
                        return Time;
                    }
                    Console.WriteLine("Error: Invalid time...");
                    Console.WriteLine("Try something like 10:20");
                    Console.WriteLine(proceedMsg);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        #endregion

        // these methods are used in error handling
        #region Guard methods
        static bool IsNull (string input) {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) {
                Console.Clear();
                Console.WriteLine("Error: No input was detected");
                Console.WriteLine(proceedMsg);
                Console.ReadLine();
                Console.Clear();

                return true;
            }
            return false;
        }

        static bool IsNumber (string input) {
            if (double.TryParse(input, out _)) {
                Console.Clear();
                Console.WriteLine("Error: Invalid input, can't accept numbers (Ints)");
                Console.WriteLine(proceedMsg);
                Console.ReadLine();
                Console.Clear();
                return true;
            }
            return false;
        }

        static bool IsOverLimit (string input, int lengthLimit) {
            if (input.Length > lengthLimit) {
                Console.Clear();
                Console.WriteLine("Error: Invalid input, the input can't be longer than " + lengthLimit + ".");
                Console.WriteLine(proceedMsg);
                Console.ReadLine();
                Console.Clear();
                return true;
            }
            return false;
        }
        #endregion

        // prompts the user for confirmation
        static bool GetConfirmation (string input) {
            Console.WriteLine("Bekræft at du vil gemme " + input + ": (\"Ja\", \"Yes\")");
            input = Console.ReadLine().ToLower();

            if (input == "y" || input == "ja" || input == "yes" || input == "j")
                return true;
            else {
                Console.WriteLine("Fejl - Data ikke gemt!\n");
                Console.WriteLine(proceedMsg);
                Console.ReadLine();
                Console.Clear();
                return false;
            }
        }

        // updates the menus that are shown to the user
        static void UpdateMenus () {
            employeeMenu = new Menu(string.Format("Vælg:\t{0,-12} {1,-10}", "Navn:", "Stilling:"), employees.Count);
            for (int i = 0; i < employees.Count; i++) {
                employeeMenu.AddItem(employees[i].ToString());
            }

            guestMenu = new Menu(string.Format("Vælg:\t{0,-25} {1,-25} {2,-30}", "Navn:", "Firma:", "Firma mail:"), guests.Count);
            for (int i = 0; i < guests.Count; i++) {
                guestMenu.AddItem(guests[i].ToString());
            }

            roomMenu = new Menu("Vælg:\tRum navn:", rooms.Count);
            for (int i = 0; i < rooms.Count; i++) {
                roomMenu.AddItem(rooms[i].ToString());
            }

            visitMenu = new Menu(string.Format("Vælg:\t{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", "Dato:", "Tidsrum:", "Gæstens Navn:", "Ansattes Navn:", "Lokale:", "Sikkerhedsfolder"), visits.Count);
            for (int i = 0; i < visits.Count; i++) {
                visitMenu.AddItem(visits[i].ToString());
            }
        }

    }
}