namespace Hydac
{
    internal class Room
    {
        string name;
        Room[] rooms1 = new Room[0];

        

        public Room (string name) {
            this.name = name;
        }

        public string GetName() {
            return name;
        }
        public override string ToString()
        {
            string message = string.Empty;
            message += "\t" + name;
            
            return message;
        }
    }
}
