namespace RestaurantTableBooking
{
    internal class Reservation
    {
        private string _name;
        private string _phone;
        private int _personCount;
        public DateTime StartTime { get; }
        public Table Table { get; }

        public Reservation(string name, string phone, int personCount, DateTime dateTime, Table table)
        {
            Table = table;
            StartTime = dateTime;
            _personCount = personCount;
            _phone = phone;
            _name = name;
        }

        public string GetDescription()
        {
            return $"Reservert bord til {_personCount} personer {StartTime:g}";
        }
    }
}
