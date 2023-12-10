namespace RestaurantTableBooking
{
    internal class Restaurant
    {
        public Restaurant(string name, int startHour, int endHour)
        {
        }

        public Table AddTable(string name, int capacity)
        {
            return null;
        }

        public ReservationResponse CreateReservation(string name, string phone, int personCount, DateTime dateTime)
        {
            return null;
        }

        public string GetAllReservationsForOneDay(DateTime date)
        {
            return "";
        }
    }
}
