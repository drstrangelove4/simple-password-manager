// Check to see if there is a save file on the system. If not create one. Do it as the init process to prevent errors.
Data_Handler.Create_file();

bool open = true;
while (open)
{
    string input = "";

    // Initial user choice - Search for passwords or create a new one.
    bool taking_input = true;
    while (taking_input)
    {
        input = Data_Handler.Null_checker("1)Search saved passwords\n2)List saved keys\n3)Create new password\n4)Quit\n(1 / 2 / 3 / 4):");
        if (input == "1" || input == "2" || input == "3" || input == "4")
        {
            taking_input = false;
        }
    }

    if (input == "1")
    {
        // Find a saved password
        Search.Get_search();
        Search.Search_results();
        Console.WriteLine();
    }

    else if (input == "2")
    {
        // Print all the saved keys
        Search.Print_keys();
        Console.WriteLine();
    }
    else if (input == "3")
    {
        // Use the password generator object to create a new password 
        var password_generator = new Password_Generator();
        password_generator.Generate_base();
        password_generator.Add_extras();
        password_generator.Create_password();

        // Final password iteration.
        string password = password_generator.Password;

        // Print the password
        Console.WriteLine(password);

        // Give the option to save the password
        Data_Handler.Save_password(password);
        Console.WriteLine();
    }
    else
    {
        // Exit the program
        open = false;
    }
}