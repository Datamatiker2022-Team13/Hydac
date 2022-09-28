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
            return name;
        }

        public string GetOccupation()
        {
            return occupation;
        }
        public override string ToString()
        {
            return string.Format("\t{0,-12} {1,-10}", name, occupation);
        }
    }
}
