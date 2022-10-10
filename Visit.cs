namespace Hydac
{
    internal class Visit

    {
        // Fields

        public DateOnly Date{get; set;}

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public Guest Guest { get; set; }

        public Employee Employee { get; set; }

        public Room Room { get; set; }

        public bool SafetyFlyerRecieved { get; set; }

        
        public Visit (DateOnly date, TimeOnly startTime, TimeOnly endTime, Guest guest, Employee employee, Room room, bool safetyFlyerRecieved)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;

            Guest = guest;
            Employee = employee;
            Room = room;

            SafetyFlyerRecieved = safetyFlyerRecieved;
        }

        public string MakeTitle()
        {
            return Date.ToString() + ";" + StartTime.ToString() + ";" + EndTime.ToString() + ";" + Guest.MakeTitle() + ";"+ Employee.Name + ";" + Room.Name +";" + SafetyFlyerRecieved;
        }

        public override string ToString()
        {
            return string.Format("\t{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}",
                Date.ToString("dd / MM - yyyy"),
                StartTime.ToString("HH':'mm") + " - " + EndTime.ToString("HH':'mm"),
                Guest.Name,
                Employee.Name,
                Room.Name,
                SafetyFlyerRecieved.ToString());
        }
    }

}
