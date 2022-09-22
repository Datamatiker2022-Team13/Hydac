namespace Hydac
{
    internal class Guest
    {
        string mail;
        string name;
        string firm;

        public Guest (string mail, string name, string firm)
        {
            this.mail = mail;
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
