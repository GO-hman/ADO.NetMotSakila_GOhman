namespace ADO.NetMotSakila_GOhman
{
    internal class UI
    {
        SakilaQuerys sakilaQuery = new SakilaQuerys();

        public void Start()
        {
            while (true)
            {
                WriteMenu();
                MenuChoice(Console.ReadKey()!);
            }
        }

        private void WriteMenu()
        {
            Console.WriteLine("-----MENU-----\r\n" +
                "1: Enter actor\r\n" +
                "2: List all actors (Beware, alot of them..)");
        }

        private void MenuChoice(ConsoleKeyInfo input)
        {
            ConsoleKey key = input.Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();

                    string name = GetFullName(); //User enters full name
                    if(ValidateName(name))
                    {
                        string firstName = GetFirstName(name); //Substring of full name, up until first space
                        string lastName = GetLastName(name); //Substring of full name, after first space
                        Console.Clear();
                        sakilaQuery.FilmsByName(firstName, lastName);
                    }
                    PressAnyKeyToContinueLogic();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();

                    sakilaQuery.ListAllActors();
                    PressAnyKeyToContinueLogic();
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    PressAnyKeyToContinueLogic();
                    break;
            }
        }


        public string GetFullName()
        {
            Console.WriteLine("Enter name of actor (first and last name): ");
            string name = Console.ReadLine()!;

            return name.Trim(); //Trim excess white spaces.
        }

        public string GetFirstName(string fullName)
        {
            int spaceIndex = fullName.IndexOf(" ");
            string firstName = fullName.Substring(0, spaceIndex).Trim();
            return firstName.ToUpper();
        }

        public string GetLastName(string fullName)
        {
            int spaceIndex = fullName.IndexOf(" ");
            string lastName = fullName.Substring(spaceIndex + 1).Trim();

            return lastName.ToUpper().Trim();
        }

        private bool ValidateName(string name) //Check if user entered first AND last name, separated by a space
        {
            if (name.IndexOf(" ") == -1)
            {
                Console.WriteLine("INVALID NAME\r\n" +
                    "Enter first AND last name\r\n" +
                    "(Separated by a space)");
                return false;
            }
            return true;
        }

        private void PressAnyKeyToContinueLogic()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
