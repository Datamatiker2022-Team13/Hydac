namespace Hydac
{
    internal class Room
    {
        string name;

        public Room (string name) {
            this.name = name;
        }

        public string Name {get; set;}

        public override string ToString()
        {
            string message = string.Empty;
            message += "\t" + name;
            
            return message;
        }
    }
}
