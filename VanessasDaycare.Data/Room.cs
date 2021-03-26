namespace VanessasDaycare.Data
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public string Subject { get; set; }




        public Room() { }
       
        public Room(int roomNumber, string subject)
        {
            RoomNumber = roomNumber;
            Subject = subject;
        }




    }
}