namespace Hydac
{
    internal class Employee
    {
        public string Name { get; set; }

        public string Occupation { get; set; }

        public Employee(string name, string occupation) {
            Name = name;
            Occupation = occupation;
        }
        
        public override string ToString()
        {
            return string.Format("\t{0,-12} {1,-10}", Name, Occupation);
        }
    }
}
