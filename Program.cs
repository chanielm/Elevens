class Program
{
    public static void Main(String[] args)
    {
        ElevensGame e = new();

        do
        {
            e.SelectCards();
            if (e.ValidateEleven(e.Selection))
            {
                Console.WriteLine("These Cards Add to 11. Removing...");
                e.ReplaceSelected();
            }
            else if (e.ValidateFaceCards(e.Selection))
            {
                Console.WriteLine("These are unique face cards. Removing...");
                e.ReplaceSelected();
            }
            else Console.WriteLine("Invalid Selection.");
        } while (true);
    }
}