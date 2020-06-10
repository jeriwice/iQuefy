using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using TestMe.DataModels;
using TestMe.Helpers;
using TestMe.Fragments;
using Android.Support.Design.Widget;

namespace TestMe.Activities
{
    [Activity(Label = "QuizPageActivity")]
    public class QuizPageActivity : AppCompatActivity
    {
        // Initializing Quiz Page Widgets and Views
        RadioButton radioButton_OptionA, radioButton_OptionB, radioButton_OptionC , radioButton_OptionD;
        TextView textView_OptionA, textView_OptionB, textView_OptionC, textView_OptionD, textView_CountDownTimer_QuizDuration, textView_QuizQuestion, textView_QuizQuestionProgressTracker;
        Button button_QuizPage_CheckAnswer;

        //Fieds
        List<QuizQuestions> quizQuestionsList = new List<QuizQuestions>();
        QuizHelpers quizHelpers = new QuizHelpers();
        string QuizTopic;
        int quizQuestionProgressTracker;
        double CorrectAnswerCount = 0;

        Android.Support.V7.Widget.Toolbar quizPageToolBar;

        //QuizTime Holders
        int timerCounter = 0;
        DateTime dateTimeMain;
        System.Timers.Timer QuizDuration_CountDownTimer = new System.Timers.Timer();
        string minutesString = "Mins";
        string secondsString = "Secs";

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.quiz_page);

            QuizTopic = Intent.GetStringExtra("topic");

            //SetUp ToolBar for QuizPage
            quizPageToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.ToolBar_QuizPage);
            SetSupportActionBar(quizPageToolBar);
            SupportActionBar.Title = QuizTopic + " Quiz";

            //SetUp ArrowBack on ActionBar
            Android.Support.V7.App.ActionBar quizPageActionBar = SupportActionBar;
            quizPageActionBar.SetHomeAsUpIndicator(Resource.Drawable.outline_arrowback);
            quizPageActionBar.SetDisplayHomeAsUpEnabled(true);

            ConnectQuizPageViews();
            BeginQuiz();
            QuizDuration_CountDownTimer.Interval = 1000;
            QuizDuration_CountDownTimer.Elapsed += QuizDuration_CountDownTimer_Elapsed;
        }

        private void QuizDuration_CountDownTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerCounter++;

            //SetUp countDown timer to always subtract One Sec in real time
            DateTime dateTimeReduce = new DateTime();
            dateTimeReduce = dateTimeMain.AddSeconds(-1);
            var dateDiff = dateTimeMain.Subtract(dateTimeReduce);
            dateTimeMain = dateTimeMain - dateDiff;

            RunOnUiThread(() =>
            {
                textView_CountDownTimer_QuizDuration.Text = $"Duration: \n{dateTimeMain.ToString("mm:ss")} minutes remaining";
            });

            //End Quiz on timeout
            if (timerCounter == ((quizQuestionsList.Count/2) * 60))
            {
                QuizDuration_CountDownTimer.Enabled = false;
                CompletedQuiz();
            }

        }

        void ConnectQuizPageViews()
        {
            //RadioButton
            radioButton_OptionA = FindViewById<RadioButton>(Resource.Id.RadioButton_OptionA);
            radioButton_OptionB = FindViewById<RadioButton>(Resource.Id.RadioButton_OptionB);
            radioButton_OptionC = FindViewById<RadioButton>(Resource.Id.RadioButton_OptionC);
            radioButton_OptionD = FindViewById<RadioButton>(Resource.Id.RadioButton_OptionD);

            //Click Action for RadioButton
            radioButton_OptionA.Click += RadioButton_OptionA_Click;
            radioButton_OptionB.Click += RadioButton_OptionB_Click;
            radioButton_OptionC.Click += RadioButton_OptionC_Click;
            radioButton_OptionD.Click += RadioButton_OptionD_Click;



            //TextView
            textView_OptionA = (TextView)FindViewById(Resource.Id.TextView_OptionA);
            textView_OptionB = (TextView)FindViewById(Resource.Id.TextView_OptionB);
            textView_OptionC = (TextView)FindViewById(Resource.Id.TextView_OptionC);
            textView_OptionD = (TextView)FindViewById(Resource.Id.TextView_OptionD);
            textView_CountDownTimer_QuizDuration = (TextView)FindViewById(Resource.Id.TextView_CountDownTimer_QuizDuration);
            textView_QuizQuestionProgressTracker = (TextView)FindViewById(Resource.Id.TextView_QuizQuestionProgressTracker);
            textView_QuizQuestion = (TextView)FindViewById(Resource.Id.TextView_QuizQuestion);
            
            //Button
            button_QuizPage_CheckAnswer = FindViewById<Button>(Resource.Id.Button_QuizPage_CheckAnswer);
            button_QuizPage_CheckAnswer.Click += Button_QuizPage_CheckAnswer_Click;
        }

        private void Button_QuizPage_CheckAnswer_Click(object sender, EventArgs e)
        {
            if (!radioButton_OptionA.Checked && !radioButton_OptionB.Checked && !radioButton_OptionC.Checked && !radioButton_OptionD.Checked)
            {
                Toast.MakeText(this, "Please, select an answer to proceed.".ToString(), ToastLength.Short).Show();
                //Snackbar.Make((View)sender, "Please, select an option to proceed.", Snackbar.LengthShort).Show(); 


            }
            //Check Correct Answer for OptionA
            else if(radioButton_OptionA.Checked)
            {
                if (textView_OptionA.Text == quizQuestionsList[quizQuestionProgressTracker - 1].QuizAnswer)
                {
                    CorrectAnswerCount++;
                    //Toast.MakeText(this, "Correct Answer!".ToString(), ToastLength.Short).Show();
                    CorrectAnswer();
                }
                else
                {
                    //Toast.MakeText(this, "Wrong Answer!".ToString(), ToastLength.Short).Show();
                    WrongAnswer();
                }
            }
            //Check Correct Answer for OptionB
            else if(radioButton_OptionB.Checked)
            { 
                if (textView_OptionB.Text == quizQuestionsList[quizQuestionProgressTracker - 1].QuizAnswer)
                {
                    CorrectAnswerCount++;
                    //Toast.MakeText(this, "Correct Answer!".ToString(), ToastLength.Short).Show();
                    CorrectAnswer();
                }
                else
                {
                    //Toast.MakeText(this, "Wrong Answer!".ToString(), ToastLength.Short).Show();
                    WrongAnswer(); 
                }
            }
            //Check Correct Answer for OptionC
            else if(radioButton_OptionC.Checked)
            {
                if (textView_OptionC.Text == quizQuestionsList[quizQuestionProgressTracker - 1].QuizAnswer)
                {
                    CorrectAnswerCount++;
                    //Toast.MakeText(this, "Correct Answer!".ToString(), ToastLength.Short).Show();
                    CorrectAnswer();
                }
                else
                {
                    //Toast.MakeText(this, "Wrong Answer!".ToString(), ToastLength.Short).Show();
                    WrongAnswer();
                }
            }
            //Check Correct Answer for OptionD
            else if(radioButton_OptionD.Checked)
            {
                if (textView_OptionD.Text == quizQuestionsList[quizQuestionProgressTracker - 1].QuizAnswer)
                {
                    CorrectAnswerCount++;
                    //Toast.MakeText(this, "Correct Answer!".ToString(), ToastLength.Short).Show();
                    CorrectAnswer();
                }
                else
                {
                    //Toast.MakeText(this, "Wrong Answer!".ToString(), ToastLength.Short).Show();
                    WrongAnswer();
                }
            }
            
        }


        #region QuizPage RadioButton ClickAction
        private void RadioButton_OptionD_Click(object sender, EventArgs e)
        {
            ClearOptionsSelected_RadioButton();
            radioButton_OptionD.Checked = true;
        }

        private void RadioButton_OptionC_Click(object sender, EventArgs e)
        {
            ClearOptionsSelected_RadioButton();
            radioButton_OptionC.Checked = true;
        }

        private void RadioButton_OptionB_Click(object sender, EventArgs e)
        {
            ClearOptionsSelected_RadioButton();
            radioButton_OptionB.Checked = true;
        }

        private void RadioButton_OptionA_Click(object sender, EventArgs e)
        {
            ClearOptionsSelected_RadioButton();
            radioButton_OptionA.Checked = true;
        }

        void ClearOptionsSelected_RadioButton()
        {
            radioButton_OptionA.Checked = false;
            radioButton_OptionB.Checked = false;
            radioButton_OptionC.Checked = false;
            radioButton_OptionD.Checked = false;
        }

        #endregion

        void BeginQuiz()
        {
            quizQuestionProgressTracker = 1;
            quizQuestionsList = quizHelpers.GetQuizQuestions(QuizTopic);
            textView_QuizQuestion.Text = quizQuestionsList[0].QuizQuestion;
            textView_OptionA.Text = quizQuestionsList[0].QuizOptionA;
            textView_OptionB.Text = quizQuestionsList[0].QuizOptionB;
            textView_OptionC.Text = quizQuestionsList[0].QuizOptionC;
            textView_OptionD.Text = quizQuestionsList[0].QuizOptionD;

            textView_QuizQuestionProgressTracker.Text = $"Question {quizQuestionProgressTracker.ToString()}/{quizQuestionsList.Count}";

            //SetUp Quiz Duration Time
            dateTimeMain = new DateTime();
            dateTimeMain = dateTimeMain.AddMinutes(quizQuestionsList.Count/2);
            textView_CountDownTimer_QuizDuration.Text = $"Duration: \n{dateTimeMain.ToString("mm:ss")} minutes remaining";
            QuizDuration_CountDownTimer.Enabled = true;

        }

        void CorrectAnswer()
        {
            CorrectAnswerFragment correctAnswerFragment = new CorrectAnswerFragment();
            var CorrectAnswerTransactionManager = SupportFragmentManager.BeginTransaction();
            correctAnswerFragment.Cancelable = false;
            correctAnswerFragment.Show(CorrectAnswerTransactionManager, "Correct Answer");
            correctAnswerFragment.NextQuestion += CorrectAnswerFragment_NextQuestion;
        }

        void WrongAnswer()
        {
            WrongAnswerFragment wrongAnswerFragment = new WrongAnswerFragment(quizQuestionsList[quizQuestionProgressTracker - 1].QuizAnswer);
            var wrongAnswerTransactionMananger = SupportFragmentManager.BeginTransaction();
            wrongAnswerFragment.Cancelable = false;
            wrongAnswerFragment.Show(wrongAnswerTransactionMananger, "Wrong Answer");
            wrongAnswerFragment.NextQuestion += CorrectAnswerFragment_NextQuestion;

        }

        private void CorrectAnswerFragment_NextQuestion(object sender, EventArgs e)
        {

            //Initiate Next Question
            quizQuestionProgressTracker++;
            
            if (quizQuestionProgressTracker > quizQuestionsList.Count)
            {
                //Toast.MakeText(this, "You have completed the number of \n questions for this quiz.", ToastLength.Short).Show();
                CompletedQuiz();
                return;
            }

            int nextQuizQuestionIndex = quizQuestionProgressTracker - 1;
            ClearOptionsSelected_RadioButton();

            textView_QuizQuestion.Text = quizQuestionsList[nextQuizQuestionIndex].QuizQuestion;
            textView_OptionA.Text = quizQuestionsList[nextQuizQuestionIndex].QuizOptionA;
            textView_OptionB.Text = quizQuestionsList[nextQuizQuestionIndex].QuizOptionB;
            textView_OptionC.Text = quizQuestionsList[nextQuizQuestionIndex].QuizOptionC;
            textView_OptionD.Text = quizQuestionsList[nextQuizQuestionIndex].QuizOptionD;

            textView_QuizQuestionProgressTracker.Text = $"Question {quizQuestionProgressTracker.ToString()}/{quizQuestionsList.Count.ToString()}";

        }

        void CompletedQuiz()
        {
            textView_CountDownTimer_QuizDuration.Text = "Time Elapsed: \n00:00 minutes".ToString();
            QuizDuration_CountDownTimer.Enabled = false;

            string score = $"Total Score: {CorrectAnswerCount.ToString()}/{quizQuestionsList.Count.ToString()}";
            double percentage = (CorrectAnswerCount / double.Parse(quizQuestionsList.Count.ToString())) * 100;
            string remarks = "";
            string images = "";

            if (percentage >= 50 && percentage < 60)
            {
                remarks = "Satisfactory! \nYou made a C.";
            }
            else if (percentage >= 60 && percentage < 70)
            {
                remarks = "Good! \nYou made a B.";
            }
            else if (percentage >= 70 && percentage < 80)
            {
                remarks = "Awesome! \nYou made a B+.";
            }
            else if (percentage >= 80 && percentage < 90)
            {
                remarks = "Very Good! You made a B++.";
            }
            else if (percentage >= 90 && percentage <= 100)
            {
                remarks = "Excellent! You made an A.";
            }
            else
            {
                remarks = "Poor Result! Try again.";
                images = "failed";
            }

            QuizCompletedFragment quizCompletedFragment = new QuizCompletedFragment(remarks, score, images);
            quizCompletedFragment.Cancelable = false;
            var transactionManager = SupportFragmentManager.BeginTransaction();
            quizCompletedFragment.Show(transactionManager, "Completed Quiz");

            quizCompletedFragment.ReturnToQuizMainMenu += (sender, e) =>
            {
                this.Finish();
            };

            

        }
         

    }
}