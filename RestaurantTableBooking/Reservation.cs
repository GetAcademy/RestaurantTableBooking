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

        public void Show(int x, int y)
        {
            MyConsole.Write(x, y, "-----------------------");
            MyConsole.Write(x, y+1, _name);
            MyConsole.Write(x, y+3, $"{_personCount} personer");
            MyConsole.Write(x, y+5, $"Tlf {_phone}");
            MyConsole.Write(x, y+7, "-----------------------");
        }

        //           Bord A (6 personer)     |     Bord B (4 personer)   
        // 16:00                             |
        // 16:15                             |
        // 16:30                             |
        // 16:45                             |
        // 17:00  -----------------------    |   -----------------------
        // 17:15   Olsen                     |    Nilsen
        // 17:30                             |
        // 17:45   5 personer                |    4 personer
        // 18:00                             |
        // 18:15   Tlf 998 87 766            |    Tlf 994 48 866
        // 18:30                             |
        // 18:45  -----------------------    |   -----------------------
        // 19:00                             |
        // 19:15                             | 
        // 19:30                             |
        // 19:45                             |
    }
}
