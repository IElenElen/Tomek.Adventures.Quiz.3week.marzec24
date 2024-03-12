using Tomek.Adventures.Quiz._3week.marzec24.App.ManagerApp;
using Tomek.Adventures.Quiz._3week.marzec24.App.ServiceApp;

namespace Tomek.Adventures.Quiz._3week.marzec24
{
    public class Program
        /* Moje notatki: 
         
         Póki co poprawa dla 3 tygodnia, refaktoryzacja czyli 
         1. Podział na projekty: dodanie bibliotek app i domain
         2. Stworzenie interfejsu w folderze Abstrakt, dodana klasa bazowa
         3. Poukładałam klasy z kodami (wcześniej pomieszałam) - osobne funkcje mendżerów, serwisów, posegregowane entity, klasa dla "future" administratora
         4. Chcę wprowadzić serwis odpowiedzialny za pilnowanie czasu dla odpowiedzi, ale póki co kijowo mi to idzie 
            zatem trzeba na razie odpuscić :-) Tylko czy ma sens liczenie czasu i pokazywanie umykajacego paska "####"??? 
            Czy zostawić tylko odmierzanie czasu??? Zastanowić się
        */
    {
        static void Main(string[] args)
        {
            Console.WriteLine("3 week");
            Console.WriteLine("Cześć. Fascynują Cię przygody Tomka z cyklu powieści autorstwa A. Szklarskiego? Jeśli tak :-), zapraszam do zabawy.");
            Console.WriteLine("Oto quiz. Tylko jedna odpowiedź jest poprawna: a, b lub c, nagrodzona 1 punktem.");

            /* Console.WriteLine("Zapoznaj się z treścią kolejnych pytań i nie zwlekaj z odpowiedzią.
            /Masz 2 minuty, by wybrać poprawną odpowiedź"); */

            // Inicjalizuję obiekty dla pytań, wyborów i weryfikacji odpowiedzi oraz dla czasu

            QuestionsManagerApp questionsManagerApp = new QuestionsManagerApp();

            /* 2 linie z pomysłu - do analizy i poprawy:
             TimeSpan userDefinedTime = TimeSpan.FromSeconds(120);
            /TimeMeasuringServiceApp timeMeasuringServiceApp = new TimeMeasuringServiceApp(userDefinedTime); */

            ChoicesManagerApp choicesManagerApp = new ChoicesManagerApp();
            AnswerVerifierServiceApp answerVerifierServiceApp = new AnswerVerifierServiceApp();

            // Zmienna przechowująca łączną liczbę punktów uzyskanych przez użytkownika
            int totalPoints = 0;

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

                /* planowany: timeMeasuringServiceApp.StartMeasurement(); mierzę czas */

                // Pobieranie wyboru od użytkownika
                UsersManagerApp usersService = new UsersManagerApp();
                char userChoice = usersService.GetUserChoice();

                /* w planie: timeMeasuringServiceApp.StopMeasurement();
                // Czekaj na odpowiedź użytkownika

                // W przypadku przekroczenia czasu na odpowiedź

                int elapsedSeconds = (int)timeMeasuringServiceApp.ElapsedTime.TotalSeconds;
                if (elapsedSeconds >= (int)userDefinedTime.TotalSeconds)
                {
                    Console.WriteLine("Czas na odpowiedź minął.");

                    timeMeasuringServiceApp.Reset();
                    continue;
                }

                // Zatrzymaj pasek postępu - w planach Do Analizy */

                Console.WriteLine();

                // Następuje weryfikacja odpowiedzi i przyznawanie punktów
                bool result = answerVerifierServiceApp.GetPointsForAnswer(question.QuestionNumber, userChoice);

                // Wyświetlanie informacji o poprawności odpowiedzi
                if (result)
                {
                    totalPoints++;
                    Console.WriteLine("Poprawna odpowiedź. Zdobywasz 1 punkt.");
                }
                else
                {
                    Console.WriteLine("Odpowiedź błędna. Brak punktu.");
                }

                if (i < questionsManagerApp.Questions.Count - 1)
                {
                    Console.WriteLine($"Aktualna liczba punktów: {totalPoints}");
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij Enter, aby przejść do kolejnego pytania.");
                    // Czekanie na gotowość użytkownika przed przejściem do następnego pytania (jeśli nie jest to ostatnie pytanie)
                    Console.ReadLine();
                    Console.WriteLine();
                }
                /* w planie Task.Delay(1000).Wait();

                userDefinedTime = userDefinedTime.Subtract(TimeSpan.FromSeconds(elapsedSeconds));
                timeMeasuringServiceApp.Reset(); do analizy */
            }
            Console.WriteLine($"Twój wynik końcowy: {totalPoints} pkt.");  // Wyświetlanie końcowego wyniku 
        }
    }
}
