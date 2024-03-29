﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomek.Adventures.Quiz._3week.marzec24.Domain.Entity
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public char ChoiceLetter { get; set; }
        public string? ChoiceContent { get; set; }

        public Choice(int choiceId, char choiceLetter, string? choiceContent)
        {
            ChoiceId = choiceId;
            ChoiceLetter = choiceLetter;
            ChoiceContent = choiceContent;
        }
    }
}
