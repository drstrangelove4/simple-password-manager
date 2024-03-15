public static class Search
    // Provides search functionality to the program
{
    private static string[] password_data = [];
    private static string Search_term = "";
    private static bool found_data = false;


    public static void Get_search()
        // Takes the search term from the use and saves it to the class variable
    {
        Search_term = Data_Handler.Null_checker("Enter a password alias to search for:").ToLower();
    }

    public static void Search_results()
        // Takes the search term and looks through the password data to see if there is a match
    {
        // Update the password data list
        password_data = Data_Handler.Load_passwords();

        foreach (string item in password_data)
        {
            if (item.Equals(Search_term, StringComparison.CurrentCultureIgnoreCase)) 
            {
                if (!found_data)
                {
                    Console.WriteLine("\nResults Found:\n----------------\n");
                }
                // Print matches            
                Console.WriteLine(item);
                int index = Array.IndexOf(password_data, item);
                Console.WriteLine(password_data[index + 1]);
                // Tell the program we have found results. 
                found_data = true;
            }
        }

        if (!found_data )
        {
            Console.WriteLine("No results found:");
        }
    }

    public static void Print_keys()
        // Prints the names of the saved passwords
    {
        // Update the password data list
        password_data = Data_Handler.Load_passwords();

        for (int i = 0; i < password_data.Length; i++)
        {
            // Every entry with an even index is a name of the password save.
            if (i == 0 || i % 2 == 0)
            {
                Console.WriteLine(password_data[i]);
            }        
        }
    }
}