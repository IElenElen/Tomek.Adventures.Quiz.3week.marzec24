using Tomek.Adventures.Quiz._3week.marzec24.App.ManagerApp;
using Tomek.Adventures.Quiz._3week.marzec24.App.ServiceApp;

namespace Tomek.Adventures.Quiz._3week.marzec24
{
    public class Program
        /* Moje notatki: 
         
         Moduł nr 3 tj. refaktoryzacja:
         1. Projekty: oprócz głównego - biblioteki app i domain
         2. Interfejs
         3. Osobne funkcje mendżerów, serwisów, posegregowane entity
         4. Wprowadzona klasa do odmierzania czasu
         5. Możliwość zakończenia quizu przed czasem
        Problem: w jednej linii mam upływający czas i odpowiedź od użytkownika - do rozwiązania
        */
    {
        static void Main(string[] args)
        {
            Console.WriteLine("3 week");
            Console.WriteLine("Cześć. Fascynują Cię przygody Tomka z cyklu powieści autorstwa A. Szklarskiego? Jeśli tak :-), zapraszam do zabawy.");
            Console.WriteLine("Oto quiz. Tylko jedna odpowiedź jest poprawna: a, b lub c, nagrodzona 1 punktem.");

            Console.WriteLine("Zapoznaj się z treścią kolejnych pytań i nie zwlekaj z odpowiedzią.");
            Console.WriteLine("Masz dwie i pół minuty, aby wybrać poprawną odpowiedź.");
            Console.WriteLine();

            // Inicjalizuję obiekty dla pytań, wyborów i weryfikacji odpowiedzi oraz dla czasu

            QuestionsManagerApp questionsManagerApp = new QuestionsManagerApp();
            ChoicesManagerApp choicesManagerApp = new ChoicesManagerApp();
            AnswerVerifierServiceApp answerVerifierServiceApp = new AnswerVerifierServiceApp();

            // Zmienna przechowująca łączną liczbę punktów uzyskanych przez użytkownika
            int totalPoints = 0;

            var timeService = new App.ServiceApp.TimeMeasuringServiceApp(); //odwołanie do serwisu dla czasu

            // Tworzę pętlę przechodzącą przez każde pytanie w zestawie
            for (int i = 0; i < questionsManagerApp.Questions.Count; i++)
            {
                var question = questionsManagerApp.Questions[i];
                var choices = choicesManagerApp.GetChoicesForQuestion(i);

                // Wyświetlanie pytania
                Console.WriteLine($"Pytanie {question.QuestionNumber + 1}: {question.QuestionContent}");

                // Wyświetlanie dostępnych wyborów w pętli
                foreach (var choice in choices)
                {
                    Console.WriteLine($"{choice.ChoiceLetter}: {choice.ChoiceContent}");
                }
                Console.WriteLine();

                timeService.StartTimer();

                Console.WriteLine();
                // Pobieranie wyboru od użytkownika
                UsersManagerApp usersService = new UsersManagerApp();
                char userChoice = usersService.GetUserChoice();

                Console.WriteLine();

                timeService.StopTimer();

                if (i < questionsManagerApp.Questions.Count - 1)
                {
                    timeService.ResetTimer(); //nowy czas dla każdego pytania
                }
                Console.WriteLine();

                // Następuje weryfikacja odpowiedzi i przyznawanie punktów
                bool result = answerVerifierServiceApp.GetPointsForAnswer(question.QuestionNumber, userChoice);
                Console.WriteLine();

                // Wyświetlanie informacji o poprawności odpowiedzi
                if (result)
                {
                    totalPoints++;
                    Console.WriteLine("Poprawna odpowiedź. Zdobywasz 1 punkt.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Odpowiedź błędna. Brak punktu.");
                    Console.WriteLine();
                }

                if (i < questionsManagerApp.Questions.Count - 1)
                {
                    Console.WriteLine($"Aktualna liczba punktów: {totalPoints}"); //bieżące zliczanie punktów
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij Enter, aby przejść do kolejnego pytania.");
                    Console.WriteLine();
                    Console.WriteLine("Jeżeli zaś chcesz zakończyć zabawę z quiz naciśnij k."); //zakończenie quizu na żądanie
                    string? userInputX = Console.ReadLine();

                    if(userInputX == "k" || userInputX == "K")
                    {
                        Console.WriteLine("Quiz został zatrzymany. Do zobaczenia.");
                        break;
                    }

                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"Twój wynik końcowy: {totalPoints} pkt.");  // Wyświetlanie końcowego wyniku 
        }
    }
}
