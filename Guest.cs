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


            public void Show()
            {
                Console.WriteLine("Guest Name:             " + name);
                Console.WriteLine("Firm:                   " + GetFirm());
                Console.WriteLine("Mail:                   " + GetMail());
            }
                

    }
}
