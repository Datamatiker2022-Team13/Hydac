namespace Hydac
{
    internal class Employee
    {
        public string Name { get; set; }

        public Employee(string name) {
            Name = name;
        }

        // overrides the base.ToString() method to a new one, with correct formatting
        public override string ToString()
        {
            return string.Format("\t{0,-12}", Name);
        }
    }
}
