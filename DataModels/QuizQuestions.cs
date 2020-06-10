using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestMe.DataModels
{
    class QuizQuestions
    {
        public string QuizQuestion { get; set; }
        public string QuizOptionA { get; set; }
        public string QuizOptionB { get; set; }
        public string QuizOptionC { get; set; }
        public string QuizOptionD { get; set; }
        public string QuizAnswer { get; set; }
    }
}