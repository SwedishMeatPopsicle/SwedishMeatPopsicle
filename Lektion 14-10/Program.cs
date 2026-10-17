namespace Lektion_14_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variabler
            bool loggedIn = false;
            bool run = true;
            bool regFunk = true;
            bool idNotTaken = true;
            bool regPass = true;
            bool loanMenu = true;
            bool searchRun = true;
            bool loanFound = false;
            Book test = new Book("123", "123", "123", true);
            MenuItems menu = new MenuItems();
            List<User> users = new List<User>();
            List<Book> books = new List<Book>();    // Samtliga registrerade böcker
            List<Loan> loans = new List<Loan>(); // Samtliga utlånade böcker
            books.Add(test);
            User Admin = new User("Admin", "1234", true);
            users.Add(Admin);
            /* - Menysystem
             * - Lista böcker                       --> Check!
             * - Lista användare                    --> Check!
             * - Sökfunktion böcker                 --> Check!
             * - Sökfunktion användare (admin)      
             * - Klasser                            --> Check!
             * - Spara användare                    --> Check!
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
                                    while (loggedIn == true)
                                    {
                                        menu.LoggedInMenu();
                                        switch (Console.ReadLine())
                                        {
                                            case "1":
                                            {
                                                Console.WriteLine("Sök efter titel, författare eller ISBN nummer");
                                                Console.WriteLine("eller tryck Q för att gå tillbaka");
                                                string input = Console.ReadLine().ToLower().Trim();
                                                if (input == "Q" || input == "q")
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    foreach (Book book in books)
                                                    {
                                                        if (book.Author.Contains(input) || book.Title.Contains(input) || book.ISBN.Contains(input))
                                                        {
                                                            Console.WriteLine(book);
                                                        }
                                                    }
                                                Console.WriteLine();
                                                 //sökfunktion
                                                break;
                                               }
                                            }
                                            case "2":
                                            {
                                                menu.LoanMenu(); // Laddar lånemenyn
                                                switch (Console.ReadLine())
                                                {
                                                    case "1":
                                                    {
                                                        while (searchRun == true)
                                                        {
                                                            Console.WriteLine("Ange ISBN nr. för boken du vill låna eller Q för att gå tillbaka till föregående meny");
                                                            string input = Console.ReadLine();
                                                            bool bookFound = false;
                                                            if (input == "Q" || input == "q")
                                                            {
                                                                searchRun = false;
                                                                break;
                                                            }
                                                            foreach (Book book in books)
                                                            {
                                                                if (book.ISBN == input)
                                                                {
                                                                    DateTime date = DateTime.Now;
                                                                    string dateString = date.ToString();
                                                                    book.Available = false;
                                                                    Loan newLoan = new Loan(book, loggedInUser, dateString);
                                                                    loans.Add(newLoan);
                                                                    bookFound = true;
                                                                    searchRun = false;
                                                                    break;
                                                                }
                                                            }
                                                            if (bookFound == false)
                                                            {
                                                                Console.WriteLine("Ogiltigt ISBN nr, var god försök igen");
                                                            }
                                                            if (bookFound == true)
                                                            {
                                                                Console.WriteLine("Lånet är nu registrerat!");
                                                                searchRun = false;
                                                                break;
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    case "2": // Lämna tillbaka böcker
                                                    {
                                                        bool noLoan = true;
                                                        int nr = 1;
                                                        while (loanMenu = true)
                                                        {
                                                            foreach (Loan loan in loans)
                                                            {
                                                                if (loan.Name == loggedInUser)  // Letar efter lånade böcker och visar dessa
                                                                {
                                                                    if (nr == 1)
                                                                    {
                                                                        Console.WriteLine("Du har lånat följande böcker:");
                                                                    }
                                                                    noLoan = false;
                                                                    Console.WriteLine($"{nr}. {loan}");
                                                                    nr++;
                                                                }
                                                            }
                                                            if (noLoan == true) // Om inga lånade böcker hittas
                                                            {
                                                                Console.WriteLine("Du har inga aktiva lån");
                                                                loanMenu = false;
                                                                Console.ReadLine();
                                                                break;
                                                            }
                                                            else // Fråga efter vilken bok som ska lämnas tillbaka
                                                            {
                                                                Console.WriteLine("Ange ISBN för den bok du vill återlämna eller Q för att återgå till föregående meny");
                                                                string input = Console.ReadLine();
                                                                if (input == "Q" || input == "q")
                                                                {
                                                                    loanMenu = false;
                                                                    break;
                                                                }
                                                                else if (input == "" || input == null)
                                                                {
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    foreach (Loan loan in loans)
                                                                    {
                                                                        if (loan.Title.ISBN == input)
                                                                        {
                                                                            loanFound = true;
                                                                            Console.WriteLine($"Tack för att du återlämnade {loan.Title.Title}!");
                                                                            loans.Remove(loan);
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                                if (loanFound == false)
                                                                {
                                                                    Console.WriteLine("Felaktigt ISBN nr. var god försök igen");
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    case "3": //logga ut
                                                    { 
                                                        loanMenu = false;
                                                        break;
                                                    }
                                                    default:
                                                    {
                                                        loanMenu = false;
                                                        break;
                                                    }
                                                 
                                                }
                                            break;
                                            }
                                            case "3":
                                                {
                                                    if (loggedInUser.IsAdmin == true)
                                                    {
                                                        menu.AdminMenu();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Du saknar administrationsrättigheter");
                                                        break;
                                                    }
                                                }
                                            case "4":
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
                            while (regFunk == true)
                            {
                                Console.WriteLine("Välj ett användarnamn eller \"Q/q\" för att gå tillbaka");
                                string newID = Console.ReadLine();
                                if (newID == null || newID == "")
                                {
                                    break;
                                }
                                else if (newID == "Q" || newID == "q")
                                {
                                    regFunk = false;
                                    break;
                                }
                                else
                                {
                                    foreach (User user in users)
                                    {
                                        if (user.ID == newID)
                                        {
                                            Console.WriteLine("Beklagar, användarnamnet är upptaget");
                                            idNotTaken = false;
                                            break;
                                        }
                                    }
                                    if (idNotTaken == true)
                                    {
                                        while (regPass == true)
                                        { 
                                            Console.WriteLine("Ange önskat lösenord");
                                            string newPass = Console.ReadLine();
                                            if (newPass == null || newPass == "")
                                            {
                                                Console.WriteLine("Lösenordet är för kort. Försök igen");
                                            }
                                            else
                                            {
                                                User newUser = new User(newID, newPass, false);
                                                users.Add(newUser);
                                                regFunk = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
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