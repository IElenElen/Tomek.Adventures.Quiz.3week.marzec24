using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomek.Adventures.Quiz._3week.marzec24.App.ManagerApp
{
    public class UsersManagerApp
    {
        // Metoda do pobierania wyboru od użytkownika
        public char GetUserChoice()
        {
           ConsoleKeyInfo keyInfo;
           char userChoice;

            do
            {
                keyInfo = Console.ReadKey();
                userChoice = char.ToLower(keyInfo.KeyChar);

                // Dodatkowa walidacja wyboru użytkownika
                if (userChoice != 'a' && userChoice != 'b' && userChoice != 'c')
                {
                    Console.WriteLine();
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    Console.WriteLine();
                    Console.Write("Twój wybór (wpisz a, b lub c): ");
                }
            } while (userChoice != 'a' && userChoice != 'b' && userChoice != 'c');

            Console.WriteLine(); // Nowa linia po wprowadzeniu wyboru
            return userChoice;
        }
    }
}
