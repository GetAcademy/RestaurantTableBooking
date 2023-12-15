namespace RestaurantTableBooking
{
    internal class MyConsole
    {
        public static void Write(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
