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
using Android.Support.V7.App;
using TestMe.Helpers;

namespace TestMe.Activities
{
    [Activity(Label = "QuizDescriptionPageActivity", Theme = "@style/AppTheme")]
    public class QuizDescriptionPageActivity : AppCompatActivity
    {
        TextView textView_DescriptionPage_TopicText;
        TextView textView_DescriptionPage_DescriptionText;
        ImageView imageView_DescriptionPage_ImagePlaceholder;
        Button button_DescriptionPage_StartText;

        string QuizTopic;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.selected_topic);

            // SetUp Views
            textView_DescriptionPage_TopicText = FindViewById<TextView>(Resource.Id.TextView_DescriptionPage_TopicText);
            textView_DescriptionPage_DescriptionText = FindViewById<TextView>(Resource.Id.TextView_DescriptionPage_DescriptionText);
            imageView_DescriptionPage_ImagePlaceholder = FindViewById<ImageView>(Resource.Id.ImageView_DescriptionPage_ImagePlaceholder);
            button_DescriptionPage_StartText = FindViewById<Button>(Resource.Id.Button_DescriptionPage_StartTest);

            //Quiz Description Page setUp
            QuizTopic = Intent.GetStringExtra("topic");
            textView_DescriptionPage_TopicText.Text = QuizTopic;
            imageView_DescriptionPage_ImagePlaceholder.SetImageResource(GetTopicImage(QuizTopic));
                
            //Connect Description
            QuizHelpers quizHelper = new QuizHelpers();
            textView_DescriptionPage_DescriptionText.Text = quizHelper.GetTopicDescription(QuizTopic);
            button_DescriptionPage_StartText.Click += Button_DescriptionPage_StartText_Click;
        }

        private void Button_DescriptionPage_StartText_Click(object sender, EventArgs e)
        {
            Intent startQuizButtonIntent = new Intent(this, typeof(QuizPageActivity));
            startQuizButtonIntent.PutExtra("topic", QuizTopic);
            StartActivity(startQuizButtonIntent);
            Finish();
        }

        int GetTopicImage (string quizTopic)
        {
            int ImageTopicID = 0;

            if (quizTopic == "History")
            {
                ImageTopicID = Resource.Drawable.history;
            }
            else if (quizTopic == "Geography")
            {
                ImageTopicID = Resource.Drawable.geography;
            }
            else if (quizTopic == "Space")
            {
                ImageTopicID = Resource.Drawable.space;
            }
            else if (quizTopic == "Engineering")
            {
                ImageTopicID = Resource.Drawable.engineering;
            }
            else if (quizTopic == "Programming")
            {
                ImageTopicID = Resource.Drawable.programming;
            }
            else if (quizTopic == "Business")
            {
                ImageTopicID = Resource.Drawable.business;
            }

            return ImageTopicID;
        }
    }
}