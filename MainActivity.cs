using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using TestMe.Activities;
using Android.Views;

namespace TestMe
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {

        Android.Support.V7.Widget.Toolbar toolbar;
        Android.Support.V4.Widget.DrawerLayout drawerLayout_Main;
        Android.Support.Design.Widget.NavigationView navigationView_DrawerLayout_Main;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            LinearLayout cardView_LinearLayout_RICI_History;
            LinearLayout cardView_LinearLayout_RIC2_Geography;
            LinearLayout cardView_LinearLayout_R2CI_Space;
            LinearLayout cardView_LinearLayout_R2C2_Engineering;
            LinearLayout cardView_LinearLayout_R3CI_Programming;
            LinearLayout cardView_LinearLayout_R3C2_Business;

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Initializing View references
            toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.ToolBar_QuizMainMenu_CardView);
            drawerLayout_Main = FindViewById<Android.Support.V4.Widget.DrawerLayout>(Resource.Id.DrawerLayout_Main);
            navigationView_DrawerLayout_Main = FindViewById<Android.Support.Design.Widget.NavigationView>(Resource.Id.NavigationView_DrawerLayout_Main);
            navigationView_DrawerLayout_Main.NavigationItemSelected += NavigationView_DrawerLayout_Main_NavigationItemSelected; //Navigation Item Click Action Identifier

            //SetUp ToolBar
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Topics";
            Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.menuaction);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            //Initialize and SetUp Views
            cardView_LinearLayout_RICI_History = FindViewById<LinearLayout>(Resource.Id.CardView_LinearLayout_RICI_History);
            cardView_LinearLayout_RIC2_Geography = FindViewById<LinearLayout>(Resource.Id.CardView_LinearLayout_RIC2_Geography);
            cardView_LinearLayout_R2CI_Space = FindViewById<LinearLayout>(Resource.Id.CardView_LinearLayout_R2CI_Space);
            cardView_LinearLayout_R2C2_Engineering = (LinearLayout)FindViewById(Resource.Id.CardView_LinearLayout_R2C2_Engineering);
            cardView_LinearLayout_R3CI_Programming = (LinearLayout)FindViewById(Resource.Id.CardView_LinearLayout_R3CI_Programming);
            cardView_LinearLayout_R3C2_Business = (LinearLayout)FindViewById(Resource.Id.CardView_LinearLayout_R3C2_Business);

            //Handle Topic click Events
            cardView_LinearLayout_RICI_History.Click += CardView_LinearLayout_RICI_History_Click;
            cardView_LinearLayout_RIC2_Geography.Click += CardView_LinearLayout_RIC2_Geography_Click;
            cardView_LinearLayout_R2CI_Space.Click += CardView_LinearLayout_R2CI_Space_Click;
            cardView_LinearLayout_R2C2_Engineering.Click += CardView_LinearLayout_R2C2_Engineering_Click;
            cardView_LinearLayout_R3CI_Programming.Click += CardView_LinearLayout_R3CI_Programming_Click;
            cardView_LinearLayout_R3C2_Business.Click += CardView_LinearLayout_R3C2_Business_Click;

        }
        #region Quiz Topics Click Intent
        void HistoryClickIntent()
        {
            Intent historyClickIntent = new Intent(this, typeof(QuizDescriptionPageActivity));
            historyClickIntent.PutExtra("topic", "History");
            StartActivity(historyClickIntent);
        }
        
        void GeographyClickIntent()
        {
            Intent geographyClickIntent = new Intent(this, typeof(QuizDescriptionPageActivity));
            geographyClickIntent.PutExtra("topic", "Geography");
            StartActivity(geographyClickIntent);
        }
        
        void SpaceClickIntent()
        {
            Intent spaceClickIntent = new Intent(this, typeof(QuizDescriptionPageActivity));
            spaceClickIntent.PutExtra("topic", "Space");
            StartActivity(spaceClickIntent);
        }
        
        void EngineeringClickIntent()
        {
            Intent engineeringClickIntent = new Intent(this, typeof(QuizDescriptionPageActivity));
            engineeringClickIntent.PutExtra("topic", "Engineering");
            StartActivity(engineeringClickIntent);
        }
        
        void ProgrammingClickIntent()
        {
            Intent programmingClickIntent = new Intent(this, typeof(QuizDescriptionPageActivity));
            programmingClickIntent.PutExtra("topic", "Programming");
            StartActivity(programmingClickIntent);
        }
        
        void BusinessClickIntent()
        {
            Intent businessClickIntent = new Intent(this, typeof(QuizDescriptionPageActivity));
            businessClickIntent.PutExtra("topic", "Business");
            StartActivity(businessClickIntent);
        }
        #endregion

        #region Click Action for CardVIew Topics 
        private void CardView_LinearLayout_R3C2_Business_Click(object sender, System.EventArgs e)
        {
            BusinessClickIntent();
        }

        private void CardView_LinearLayout_R3CI_Programming_Click(object sender, System.EventArgs e)
        {
            ProgrammingClickIntent();
        }

        private void CardView_LinearLayout_R2C2_Engineering_Click(object sender, System.EventArgs e)
        {
            EngineeringClickIntent();
        }

        private void CardView_LinearLayout_R2CI_Space_Click(object sender, System.EventArgs e)
        {
            SpaceClickIntent();
        }

        private void CardView_LinearLayout_RIC2_Geography_Click(object sender, System.EventArgs e)
        {
            GeographyClickIntent();
        }

        private void CardView_LinearLayout_RICI_History_Click(object sender, System.EventArgs e)
        {
            HistoryClickIntent();
        }
        #endregion

        #region Click Action for NavigationView TopicItems
        private void NavigationView_DrawerLayout_Main_NavigationItemSelected(object sender, Android.Support.Design.Widget.NavigationView.NavigationItemSelectedEventArgs e)
        {
            if (e.MenuItem.ItemId == Resource.Id.NavigationMenu_QuizTopic_History)
            {
                HistoryClickIntent();
                drawerLayout_Main.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.NavigationMenu_QuizTopic_Geography)
            {
                GeographyClickIntent();
                drawerLayout_Main.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.NavigationMenu_QuizTopic_Space)
            {
                SpaceClickIntent();
                drawerLayout_Main.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.NavigationMenu_QuizTopic_Engineering)
            {
                EngineeringClickIntent();
                drawerLayout_Main.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.NavigationMenu_QuizTopic_Programming)
            {
                ProgrammingClickIntent();
                drawerLayout_Main.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.NavigationMenu_QuizTopic_Business)
            {
                BusinessClickIntent();
                drawerLayout_Main.CloseDrawers();
            }
        }
        #endregion


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout_Main.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}