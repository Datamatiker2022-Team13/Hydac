using System.Security.Cryptography.X509Certificates;

namespace Hydac
{
    public class Guest
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Firm { get; set; }

        public Guest (string mail, string name, string firm)
        {
            Mail = mail;
            Name = name;
            Firm = firm;
        }

        public string MakeTitle()
        {
            return Mail + ";" + Name + ";" + Firm;
        }

        // overrides the base.ToString() method to a new one, with correct formatting
        public override string ToString()
        {
            return string.Format("\t{0,-25} {1,-25} {2,-30}", Name, Firm, Mail);
        }
    }
}
