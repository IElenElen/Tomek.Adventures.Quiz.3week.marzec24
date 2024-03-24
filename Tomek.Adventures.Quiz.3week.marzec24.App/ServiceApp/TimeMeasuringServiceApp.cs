using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Tomek.Adventures.Quiz._3week.marzec24.App.ServiceApp
{ 
    public class TimeMeasuringServiceApp
    {
        public const int TIME_PER_QUESTION_IN_FULL_SECONDS = 150; //stała dla odmierzania czasu 2 minuty i 30 sekund
        private System.Timers.Timer timer; //timer będzie odmierzać czas
        private int timeLeftInFullSeconds; //pozostały czas
        //zdarzenie TimeElapsed, typu EventHandler, zainicjowanie zdarzenia
        public event EventHandler? TimeElapsed; //upływający czas
        public TimeMeasuringServiceApp()
        {
            timeLeftInFullSeconds = TIME_PER_QUESTION_IN_FULL_SECONDS; //początkowa wartość równa się ustalonej zmiennej
            timer = new System.Timers.Timer(1000);
            //Do zdarzenia Elapsed obiektu timer dodaj obsługę, która polega na wywołaniu metody TimerElapsed(sender, e)
            timer.Elapsed += (sender, e) => TimerElapsed(sender, e); //dwa parametry
        }
        public void StartTimer() //startowanie
        {
            timer.Start();
        }
        public void StopTimer() //zatrzymanie odmierzania czasu
        {
            timer.Stop();
        }
        public void ResetTimer() //resetowanie czasu do wartości początkowej
        {
            timeLeftInFullSeconds = TIME_PER_QUESTION_IN_FULL_SECONDS;
        }
        private void TimerElapsed(object? sender, ElapsedEventArgs e) //upływający czas
        {
            timeLeftInFullSeconds--; // zmniejszenie o 1

            Console.CursorLeft = 0; // Ustawienie kursora na początek linii
            Console.Write("\r" + new string(' ', Console.WindowWidth - 1)); // Wyczyszczenie linii
            Console.CursorLeft = 0; // Ponowne ustawienie kursora na początek linii

            Console.Write($"Czas pozostały: {timeLeftInFullSeconds} sekund"); // Aktualny czas pozostały

            if (timeLeftInFullSeconds <= 0) //jeżeli czas się skończył
            {
                StopTimer();
                OnTimeElapsed();
            }
        }
        protected virtual void OnTimeElapsed() //deklaracja metody, koniec czasu na odpowiedź
        {
            TimeElapsed?.Invoke(this, EventArgs.Empty); //wywołanie
            Console.WriteLine("Czas na odpowiedż minął.");
        }
    }
}