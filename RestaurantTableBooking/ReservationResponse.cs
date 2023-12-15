namespace RestaurantTableBooking
{
    internal class ReservationResponse
    {
        private readonly Reservation _reservation;
        private readonly int _persons;
        private readonly DateTime _time;

        public ReservationResponse(Reservation reservation) // ja
        {
            _reservation = reservation;
        }

        public ReservationResponse(int persons, DateTime time) // nei
        {
            _time = time;
            _persons = persons;
        }


        public string GetDescription()
        {
            return _reservation?.GetDescription() 
                   ?? $"Vi beklager! Det er ikke ledig bord til {_persons} personer {_time:g}";
        }

        public Reservation GetReservation()
        {
            return _reservation;
        }
    }
}
