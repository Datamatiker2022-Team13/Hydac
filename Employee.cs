namespace Hydac
{
    internal class Employee
    {
        string name; 
        string occupation;

        public Employee (string name, string occupation) {
            this.name = name;
            this.occupation = occupation;
        }

        public string GetName ()
        {
              // skal returnere navnet
            return name;
        }

        public string GetOccupation()
        {
            // skal returnere stillingsbetegnelse 
            return occupation;
        }
    }
}
