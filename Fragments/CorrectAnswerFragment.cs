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
    public class CorrectAnswerFragment : Android.Support.V4.App.DialogFragment
    {
        Button button_DialogueFragmentCorrect_NextQuestion;

        public event EventHandler NextQuestion;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.CorrectAnswerFragment, container, false);

            button_DialogueFragmentCorrect_NextQuestion = view.FindViewById<Button>(Resource.Id.Button_DialogueFragmentCorrect_NextQuestion);
            button_DialogueFragmentCorrect_NextQuestion.Click += Button_DialogueFragmentCorrect_NextQuestion_Click;
            return view;
        }

        private void Button_DialogueFragmentCorrect_NextQuestion_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            NextQuestion?.Invoke(this, new EventArgs());
        }
    }
}