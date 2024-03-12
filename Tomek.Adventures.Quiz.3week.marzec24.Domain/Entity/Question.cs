using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomek.Adventures.Quiz._3week.marzec24.Domain.Entity
{
    public class Question
    {
        public int QuestionNumber { get; set; }
        public string? QuestionContent { get; set; }

        public Question(int questionNumber, string questionContent)
        {
            QuestionNumber = questionNumber;
            QuestionContent = questionContent;
        }
    }
}
