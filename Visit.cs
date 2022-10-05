namespace Hydac
{
    internal class Visit

    {
        // Felter

        public DateOnly date{get; set;}

        public TimeOnly startTime { get; set; }

        public TimeOnly endTime { get; set; }

        public Guest guest { get; set; }

        public Employee employee { get; set; }

        public Room room { get; set; }

        public bool safetyFlyerRecieved { get; set; }

    
        public Visit (DateOnly date, TimeOnly startTime, TimeOnly endTime, Guest guest, Employee employee, Room room, bool safetyFlyerRecieved)
        {
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;

            this.guest = guest;
            this.employee = employee;
            this.room = room;

            this.safetyFlyerRecieved = safetyFlyerRecieved;
        }

        public string MakeTitle()
        {
            return date.ToString() + ";" + startTime.ToString() + ";" + endTime.ToString() + ";" + guest.MakeTitle() + ";"+ employee.Name + ";" + room.Name +";" + safetyFlyerRecieved;
        }

        public override string ToString()
        {
            return string.Format("\t{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}",
                date.ToString("dd / MM - yyyy"),
                startTime.ToString("HH':'mm") + " - " + endTime.ToString("HH':'mm"),
                guest.Name,
                employee.Name,
                room.Name,
                safetyFlyerRecieved.ToString());
        }
    }

}
