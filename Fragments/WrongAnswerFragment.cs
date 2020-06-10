using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TestMe.Fragments
{
    public class WrongAnswerFragment : Android.Support.V4.App.DialogFragment
    {
        string CorrectAnswer;

        Button button_DialogueFragmentWrong_NextQuestion;
        TextView textView_DialogueFramentWrong_CorrectAnswer;

        public event EventHandler NextQuestion;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public WrongAnswerFragment(string answer)  
        {
            CorrectAnswer = answer;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.WrongAnswerFragment, container, false);

            textView_DialogueFramentWrong_CorrectAnswer = view.FindViewById<TextView>(Resource.Id.TextView_DialogueFramentWrong_CorrectAnswer);
            textView_DialogueFramentWrong_CorrectAnswer.Text = $"The correct answer is \n \"{CorrectAnswer}\".";

            button_DialogueFragmentWrong_NextQuestion = view.FindViewById<Button>(Resource.Id.Button_DialogueFramentWrong_NextQuestion);
            button_DialogueFragmentWrong_NextQuestion.Click += Button_DialogueFramentWrong_NextQuestion_Click;
            return view;
        }

        private void Button_DialogueFramentWrong_NextQuestion_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            NextQuestion?.Invoke(this, new EventArgs());
        }
    }
}