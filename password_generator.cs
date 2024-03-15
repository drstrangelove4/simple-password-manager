class Password_Generator
{
    // Password format - Required from each + 4 random from either list below
    private const int REQUIRED_CHARACTERS = 2;
    private const int EXTRA_CHARACTERS = 4;

    // Character lists
    private readonly List<char> characters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
    private readonly List<char> symbols = ['!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '{', '}', '[', ']', '\\', '/', '@', '#', ':', ';', '~'];
    private readonly List<char> numbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    // Random seed object    
    private Random random = new();

    // Holds the password characters.
    private List<string> raw_password = [];

    public string Password { get; set; } = "";

    public void Generate_base()
    {
        // Select required symbols
        // Covert them to string to allow the calling of '.ToUpper()' on the chars from the character list.
        for (int i = 0; i<REQUIRED_CHARACTERS; i++)
        {
            raw_password.Add(characters[random.Next(0, characters.Count - 1)].ToString().ToUpper());
            raw_password.Add(symbols[random.Next(0, symbols.Count - 1)].ToString());
            raw_password.Add(numbers[random.Next(0, numbers.Count - 1)].ToString());
        }

    }

    public void Add_extras()
    {
        for (int i = 0; i < EXTRA_CHARACTERS; i++)
        {
            // Pick a random number from 0 to 2 and pick a character from one of the 3 lists depending on the value.
            int choice = random.Next(0, 2);

            switch (choice)
            {
                case 0:
                    raw_password.Add(characters[random.Next(0, characters.Count - 1)].ToString());
                    break;
                case 1:
                    raw_password.Add(symbols[random.Next(0, symbols.Count - 1)].ToString());
                    break;
                case 2:
                    raw_password.Add(numbers[random.Next(0, numbers.Count - 1)].ToString());
                    break;
            }
        }
    }

    public void Create_password()
    {
        // Randomly pick characters from the raw password list
        int start_size = raw_password.Count;
        for (int i = 0; i < start_size; i++)
        {
            int index = random.Next(0, raw_password.Count - 1);
            Password += raw_password[index];
            raw_password.RemoveAt(index);

        }
    }


}