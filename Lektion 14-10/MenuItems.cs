using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_14_10
{
    public class MenuItems
    {
        
        public void StartMenu()
        {
            Console.WriteLine("################################################################################");
            Console.WriteLine("Välkommen till biblioteket!");
            Console.WriteLine("################################################################################");
            Console.WriteLine("1. Logga in");
            Console.WriteLine("2. Registrera ny användare");
            Console.WriteLine("3. Avsluta");
        }

        public void LoggedInMenu()
        {
            Console.WriteLine("1. Sök bland våra böcker");
            Console.WriteLine("2. Hantera dina lån");
            Console.WriteLine("3. Logga ut.");
        }
    }
}
