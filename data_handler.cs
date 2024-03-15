static class Data_Handler
{
    // Create a path to save/load the file to/from
    private static readonly string current_directory = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly string filename = "password.txt";
    private static readonly string save_path = Path.Join(current_directory, filename);

    
    public static void Create_file()
        // Create the file if it doesn't exist
    {
        if (!File.Exists(save_path))
        {
            StreamWriter sw = new(save_path);
            sw.Close();
        }        
    }

    public static void Save_password(string password_name, string password)
        // Adds a password to the save filek
    {
        using StreamWriter sw = File.AppendText(save_path);
        sw.WriteLine($"{password_name}\n{password}");
        sw.Close();
    }

   public static string[] Load_passwords()
        // Load the data from file
    {
        string password_data = File.ReadAllText(save_path);
        var passwords = password_data.Split('\n');

        return passwords;
    }

    public static void Save_password(string password)
        // Allows the user to save the generated passwords and attach a name to them.
    {
        bool checking = true;
        while (checking)
        // Take user input and check if it is valid
        {
            string option = Null_checker("Would you like to save this password? (yes/y/no/n): ");
            if (option == "yes" || option == "y")
            {
                // If the user wants to save the password invoke the class responsible for handling data and write it to file.              
                string name = Null_checker("Give a name to the password");

                // Tell the data handler to save the password entry                
                Data_Handler.Save_password(name, password);
                checking = false;

            }
            // Give the option not to save the password
            else if (option == "no" || option == "n")
            {
                checking = false;
            }
            // Check if the input is valid.
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }


    public static string Null_checker(string prompt)
    // Checks the user input for no input
    {
        Console.WriteLine(prompt);
        while (true)
        {
            string user_input = Console.ReadLine();
            if (user_input != "" && user_input != null)
            {
                return user_input;
            }
            else
            {
                Console.WriteLine("Invalid Input\n");
                Console.WriteLine(prompt);
            }
        }
    }
}