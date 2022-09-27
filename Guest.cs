namespace Hydac
{
    internal class Guest

        //felter:
    {
        string mail;
        string name;
        string firm;

        public Guest(string mail, string name, string firm)
        {
            this.mail = mail;
            this.name = name;
            this.firm = firm; 
        }

        //Metoder:   

        public string GetName()
        {
            return name;
        }

        public string GetFirm()
        {
            return firm;
        }

        public string GetMail()
        {
            return mail;
        }


        public override string ToString()
        {
            string message = string.Empty;
            message += "\tGuest Name:             " + name + "\n";
            message += "\tFirm:                   " + firm + "\n";
            message += "\tMail:                   " + mail + "\n";

            return message;
        }
    }
}
