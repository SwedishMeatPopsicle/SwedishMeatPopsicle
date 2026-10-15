namespace Lektion_14_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variabler
            bool loggedIn = false;
            bool run = true;
            MenuItems menu = new MenuItems();
            List<User> users = new List<User>();
            List<Book> books = new List<Book>();
            User Admin = new User("Admin", "123", true);
            users.Add(Admin);
            /* - Menysystem
             * - Lista böcker
             * - Lista användare
             * - Sökfunktion böcker
             * - Sökfunktion användare (admin)
             * - Klasser                            --> Check!
             * - Spara användare
             * - Spara böcker
             */
            while (run == true)
            { 
                menu.StartMenu();                                   //Startmenyn
                switch (Console.ReadLine())
                {

                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Ange Användarnamn");
                            string loginID = Console.ReadLine();
                            User userFound = null;
                            foreach (User user in users)
                            {
                                if (user.ID == loginID)
                                {
                                    userFound = user;
                                    break;
                                }
                            }
                            if (userFound != null)
                            {
                                Console.WriteLine("Ange lösenord");
                                string loginPass = Console.ReadLine();
                                if (loginPass != null && userFound.Password == loginPass)
                                {
                                    Console.WriteLine("Inloggning lyckades!");
                                    Console.ReadKey();
                                    Console.WriteLine();
                                    User loggedInUser = userFound;
                                    loggedIn = true;
                                    while (loggedIn = true)
                                    {
                                        menu.LoggedInMenu();
                                        switch (Console.ReadLine())
                                        {
                                            case "1":
                                                {
                                                    Console.WriteLine("Sök efter titel, författare eller ISBN nummer");
                                                    Console.WriteLine("eller tryck Q för att gå tillbaka");
                                                    string input = Console.ReadLine();
                                                    if (input == "Q")
                                                        break;

                                                    else if (input == "q")
                                                    {
                                                        break;
                                                    }

                                                    else
                                                    {
                                                        //sökfunktion
                                                        break;
                                                    }
                                                }
                                            case "2":
                                                {
                                                    //lånefunktionen
                                                    break;
                                                }
                                            case "3":
                                                {
                                                    loggedInUser = null;
                                                    loggedIn = false;
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Ogiltigt val, försök igen");
                                                    break;
                                                }
                                        }
                                    }
                                    //Inloggad funkiton
                                }
                                else
                                {
                                    Console.WriteLine("Felaktigt lösenord");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt användarnamn");
                            }
                        }
                        break;


                    case "2":
                    {
                        //Reg Funktion
                        break;
                    }
                case "3":
                    {
                        run = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ogiltigt kommando, försök igen");
                        break;
                    }
                }
            }
        }
    }
}