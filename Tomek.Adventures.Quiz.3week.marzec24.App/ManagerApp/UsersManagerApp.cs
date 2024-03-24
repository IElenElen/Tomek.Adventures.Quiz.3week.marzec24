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
                Console.WriteLine();

                // Dodatkowa walidacja wyboru użytkownika
                if (userChoice != 'a' && userChoice != 'b' && userChoice != 'c')
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie. Twój wybór. Wpisz a, b lub c: ");
                    Console.WriteLine();
                }
            } while (userChoice != 'a' && userChoice != 'b' && userChoice != 'c');

            Console.WriteLine(); // Nowa linia po wprowadzeniu wyboru
            return userChoice;
        }
    }
}
