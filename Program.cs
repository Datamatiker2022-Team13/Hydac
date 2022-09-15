namespace Hydac
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //*Welcome message*//
            Console.WriteLine("Hej og velkommen");
            Console.WriteLine("Vælg en af de nederstående muligheder \n");

            //*Options selector 1-4*//
            while (true)
            {
                //Menu options
                Console.WriteLine("1. Opret gæst \n" + "2. Opret besøg\n" + "3. Oversigt af besøgene\n" + "4. Luk konsolen \n");

                //*Options selecter message*//
                Console.WriteLine("Hvad vil du vælge: ");

                //*Input color = Cyan*//
                Console.ForegroundColor = ConsoleColor.Cyan;

                //*String converting to INT type*//
                string input = Console.ReadLine();

                //*Resets input color*//
                Console.ResetColor();

                //*Looks if input is valid, if valid (1-4) then goes to that "Page" of invalid goes to Error section*//
                int res;
                int.TryParse(input, out res);

                int Sleeper = 1500;

                switch (res)
                {
                    case 1:
                        Console.WriteLine("Du er nu i gang med at oprette en ny gæst");
                        break;

                    case 2:
                        Console.WriteLine("Du er nu i gang med at oprette et nyt besøg");
                        break;

                    case 3:
                        Console.WriteLine("Her ser du en oversigt over besøgende \n");
                        break;

                    case 4:
                        Console.WriteLine("Konsolen lukker om..");
                        Thread.Sleep(Sleeper);
                        Console.WriteLine("3..");

                        Thread.Sleep(Sleeper);
                        Console.WriteLine("2..");

                        Thread.Sleep(Sleeper);
                        Console.WriteLine("1..");

                        Console.WriteLine("Bye bye");
                        Thread.Sleep(Sleeper);
                        Environment.Exit(0);

                        break;

                    default:
                        Console.WriteLine("Der skete en fejl, du indtastede en invalid værdi.");
                        break;
                }

                //*User input to continue CLEAR the console*//
                string Enter = "ENTER";

                Console.WriteLine("\nTryk " + Enter + " for at reset konsolen..");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}