namespace RestaurantTableBooking
{
    internal class Restaurant
    {
        private string _name;
        private int _openingHour;
        private int _closingHour;
        private readonly TimeSpan DefaultReservationDuration = TimeSpan.FromHours(2);
        private readonly List<Table> _tables;
        private readonly List<Reservation> _reservations;

        public Restaurant(string name, int openingHour, int closingHour)
        {
            _closingHour = closingHour;
            _openingHour = openingHour;
            _name = name;
            _tables = new List<Table>();
            _reservations = new List<Reservation>();
        }

        public Table AddTable(string name, int capacity)
        {
            var table = new Table(name, capacity);
            _tables.Add(table);
            return table;
        }

        public ReservationResponse CreateReservation(string name, string phone, int personCount, DateTime dateTime)
        {
            var table = GetAvailableTable(personCount, dateTime);
            if (table == null)
            {
                return new ReservationResponse(personCount, dateTime);
            }

            var reservation = new Reservation(name, phone, personCount, dateTime, table);
            _reservations.Add(reservation);
            return new ReservationResponse(reservation);
        }

        private Table GetAvailableTable(int personCount, DateTime dateTime)
        {
            var bigEnoughTables = _tables.Where(t => t.HasCapacity(personCount));
            foreach (var table in bigEnoughTables)
            {
                if (IsTableAvailable(table, dateTime))
                {
                    return table;
                }
            }
            return null;
        }

        private bool IsTableAvailable(Table table, DateTime startTimeToCheck)
        {
            foreach (var reservation in _reservations)
            {
                if (reservation.Table != table) continue;
                var endTimeToCheck = startTimeToCheck.Add(DefaultReservationDuration);

                var reservationStartTime = reservation.StartTime;
                var reservationEndTime = reservation.StartTime.Add(DefaultReservationDuration);

                if (reservationEndTime >= startTimeToCheck && reservationStartTime <= endTimeToCheck)
                {
                    return false;
                }
            }
            return true;
        }

        public void ShowAllReservationsForOneDay(DateTime date)
        {
            Console.Clear();

            var reservations = _reservations.Where(
                r => r.StartTime.Year == date.Year
                     && r.StartTime.Month == date.Month
                     && r.StartTime.Day == date.Day);
            ShowAllHours();
            ShowAllTableNames();
            foreach (var reservation in reservations)
            {
                var tableIndex = 1 + _tables.IndexOf(reservation.Table);
                var x = tableIndex * 20;
                var openingTime = new DateTime(date.Year, date.Month, date.Day, _openingHour, 0, 0);
                var y = (int)((reservation.StartTime - openingTime).TotalMinutes) / 15;
                reservation.Show(x, y + 1);
            }
        }

        private void ShowAllTableNames()
        {
            for (var index = 0; index < _tables.Count; index++)
            {
                var table = _tables[index];
                var x = (index + 1) * 20;
                MyConsole.Write(x, 0, table.GetDescription());
            }
        }

        private void ShowAllHours()
        {
            for (var hour = _openingHour; hour < _closingHour; hour++)
            {
                var y = (hour - _openingHour) * 4 + 1;
                MyConsole.Write(0, y, $"{hour:D2}:00");
                MyConsole.Write(0, y + 1, $"{hour:D2}:15");
                MyConsole.Write(0, y + 2, $"{hour:D2}:30");
                MyConsole.Write(0, y + 3, $"{hour:D2}:45");
            }
        }
    }
}
