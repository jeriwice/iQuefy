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
    public class QuizCompletedFragment : Android.Support.V4.App.DialogFragment
    {
        public event EventHandler ReturnToQuizMainMenu;

        ImageView imageView_QuizCompletedPage;
        TextView textView_QuizCompletedPage_ScoreText;
        TextView textView_QuizCompletedPage_RemarkText;
        Button button_QuizCompletedPage_MainMenu;

        string remarks, scores, images;

        public QuizCompletedFragment(string _remarks, string _scores, string _images)
        {
            remarks = _remarks;
            scores = _scores;
            images = _images;
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
           View view =  inflater.Inflate(Resource.Layout.QuizCompletedFragment, container, false);

            imageView_QuizCompletedPage = view.FindViewById<ImageView>(Resource.Id.ImageView_QuizCompletedPage);
            textView_QuizCompletedPage_ScoreText = view.FindViewById<TextView>(Resource.Id.TextView_QuizCompletedPage_ScoreText);
            textView_QuizCompletedPage_RemarkText = view.FindViewById<TextView>(Resource.Id.TextView_QuizCompletedPage_RemarkText);
            button_QuizCompletedPage_MainMenu = view.FindViewById<Button>(Resource.Id.Button_QuizCompletedPage_MainMenu);

            button_QuizCompletedPage_MainMenu.Click += Button_QuizCompletedPage_MainMenu_Click;

            textView_QuizCompletedPage_ScoreText.Text = scores;
            textView_QuizCompletedPage_RemarkText.Text = remarks;
            if (images == "failed")
            {
                imageView_QuizCompletedPage.SetImageResource(Resource.Drawable.sad);
            }

            return view;
        }

        private void Button_QuizCompletedPage_MainMenu_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            ReturnToQuizMainMenu?.Invoke(this, new EventArgs());
        }
    }
}