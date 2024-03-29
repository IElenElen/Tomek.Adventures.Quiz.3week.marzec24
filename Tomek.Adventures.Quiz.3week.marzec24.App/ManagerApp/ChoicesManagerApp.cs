﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomek.Adventures.Quiz._3week.marzec24.App.ServiceApp;
using Tomek.Adventures.Quiz._3week.marzec24.Domain.Entity;

namespace Tomek.Adventures.Quiz._3week.marzec24.App.ManagerApp
{
    public class ChoicesManagerApp
    {
        private ChoiceServiceApp choiceServiceApp;
        public ChoicesManagerApp()
        {
            choiceServiceApp = new ChoiceServiceApp();
        }
        public Choice[] Choice0Array => new Choice[] { choiceServiceApp.Choice0A, choiceServiceApp.Choice0B, choiceServiceApp.Choice0C };
        public Choice[] Choice1Array => new Choice[] { choiceServiceApp.Choice1A, choiceServiceApp.Choice1B, choiceServiceApp.Choice1C };
        public Choice[] Choice2Array => new Choice[] { choiceServiceApp.Choice2A, choiceServiceApp.Choice2B, choiceServiceApp.Choice2C };
        public Choice[] Choice3Array => new Choice[] { choiceServiceApp.Choice3A, choiceServiceApp.Choice3B, choiceServiceApp.Choice3C };
        public Choice[] Choice4Array => new Choice[] { choiceServiceApp.Choice4A, choiceServiceApp.Choice4B, choiceServiceApp.Choice4C };
        public Choice[] Choice5Array => new Choice[] { choiceServiceApp.Choice5A, choiceServiceApp.Choice5B, choiceServiceApp.Choice5C };
        public Choice[] Choice6Array => new Choice[] { choiceServiceApp.Choice6A, choiceServiceApp.Choice6B, choiceServiceApp.Choice6C };
        public Choice[] Choice7Array => new Choice[] { choiceServiceApp.Choice7A, choiceServiceApp.Choice7B, choiceServiceApp.Choice7C };
        public Choice[] Choice8Array => new Choice[] { choiceServiceApp.Choice8A, choiceServiceApp.Choice8B, choiceServiceApp.Choice8C };

        public Choice[] GetChoicesForQuestion(int questionNubmer)
        {
            switch (questionNubmer)
            {
                case 0:
                    return Choice0Array;
                case 1:
                    return Choice1Array;
                case 2:
                    return Choice2Array;
                case 3:
                    return Choice3Array;
                case 4:
                    return Choice4Array;
                case 5:
                    return Choice5Array;
                case 6:
                    return Choice6Array;
                case 7:
                    return Choice7Array;
                case 8:
                    return Choice8Array;

                default:

                    return new Choice[0]; // Domyślnie zwraca pustą tablicę
            }
        }
    }
}
