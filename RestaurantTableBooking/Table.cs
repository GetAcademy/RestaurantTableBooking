namespace RestaurantTableBooking
{
    internal class Table
    {
        private readonly string _name;
        private readonly int _capacity;

        public Table(string name, int capacity)
        {
            _capacity = capacity;
            _name = name;
        }

        public string GetDescription()
        {
            return $"Bord {_name} har plass til {_capacity} personer";
        }

        public bool HasCapacity(int persons)
        {
            return _capacity >= persons;
        }
    }
}
