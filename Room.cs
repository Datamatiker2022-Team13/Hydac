namespace Hydac
{
    internal class Room
    {
        public string Name {get; set;}

        public Room (string name) {
            Name = name;
        }


        public override string ToString()
        {
            string message = string.Empty;
            message += "\t" + Name;
            
            return message;
        }
    }
}
