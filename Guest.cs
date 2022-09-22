namespace Hydac
{
    internal class Guest
    {
        string name;
        string firm;

        public Guest (string name, string firm)
        {
            this.name = name;
            this.firm = firm;
        }

        public string GetName()
        {
            return name;
        }
        public string GetFirm()
        {
            return firm;
        }
    }
}
