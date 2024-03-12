using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomek.Adventures.Quiz._3week.marzec24.App.ServiceApp;
using Tomek.Adventures.Quiz._3week.marzec24.Domain.Entity;

namespace Tomek.Adventures.Quiz._3week.marzec24.App.ManagerApp
{
    public class QuestionsManagerApp
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        public QuestionsManagerApp()
        {
            QuestionServiceApp questionServiceApp = new QuestionServiceApp();
            Questions.AddRange(questionServiceApp.AllQuestions);
        }
    }
}
