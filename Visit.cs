namespace Hydac
{
    internal class Visit

    {
        
        // Felter
        
        DateOnly date;
        TimeOnly startTime;
        TimeOnly endTime;

        Guest guest;
        Employee employee;
        Room room;

        bool safetyFlyerRecieved;
        DateOnly safetyFlyerRecievedDate;
        
        public Visit (DateOnly date, TimeOnly startTime, TimeOnly endTime, Guest guest, Employee employee, Room room, bool safetyFlyerRecieved, DateOnly safetyFlyerRecievedDate)
        {
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;

            this.guest = guest;
            this.employee = employee;
            this.room = room;

            this.safetyFlyerRecieved = safetyFlyerRecieved;
            this.safetyFlyerRecievedDate = safetyFlyerRecievedDate;
        }

        public void Show()
        {
            Console.WriteLine("Date:                    " + date.ToString("dd / MM - yyyy"));
            Console.WriteLine("Time:                    " + startTime.ToString("HH':'mm") + " - " + endTime.ToString("HH':'mm"));

            Console.WriteLine("Guest name:              " + guest.GetName()); 
            Console.WriteLine("Employee name:           " + employee.GetName());
            Console.WriteLine("Room name:               " + room.GetName());

            Console.WriteLine("Safety flyer recieved?   " + safetyFlyerRecieved.ToString());
            Console.WriteLine("Date recieved            " + safetyFlyerRecievedDate.ToString("dd / MM - yyyy"));
        }

        //Metoder
        public DateOnly GetDate()
        {
            return date;
        }
          
        public TimeOnly GetStartTime()
        {
            return startTime;
        }
        public TimeOnly GetEndTime()
        {
            return endTime;
        }

        public bool GetSafetyFlyerRecieved () {
            return safetyFlyerRecieved;
        }

        public DateOnly GetSafetyFlyerRecievedDate () {
            return safetyFlyerRecievedDate;
        }
    }

}
