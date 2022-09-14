namespace Hydac
{
    internal class Program
    {
        static void Main (string[] args) {
            Guest jonasGæst = new Guest("Jonas", "Alphabet Inc.", true, 2010, 10, 30);
            Guest jonathanGæst = new Guest("Jonathan", "Hydac", false, 0, 0, 0);
            
            Console.WriteLine(jonasGæst.GetName() + " er fra " + jonasGæst.GetFirm());
            Console.WriteLine(jonathanGæst.GetName() + " er fra " + jonathanGæst.GetFirm());

            string k2 = Console.ReadLine();
        }
    }
}