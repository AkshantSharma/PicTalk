using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content;
using PicTalk.Droid.Activities;
using Android.Support.V4.Widget;
using Android.Support.V4.App;

namespace PicTalk.Droid.Fragments
{
    
    public class NavigationDrawerFragment : Fragment
    {
        #region Private fields
        private Android.Support.V7.App.ActionBarDrawerToggle mDrawerToggle;
        #endregion

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Create your fragment here
        }
        View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            try
            {

            
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            view = inflater.Inflate(Resource.Layout.Navigation_Drawer, container, false);
            Typeface fonts = Typeface.CreateFromAsset(Context.Assets, "fontawesome-webfont.ttf");
            Button btnHome = view.FindViewById<Button>(Resource.Id.btnHome);
            Button btnMyReviews = view.FindViewById<Button>(Resource.Id.btnMyReviews);
            Button btnSettings = view.FindViewById<Button>(Resource.Id.btnFriends);
            Button btnInfo = view.FindViewById<Button>(Resource.Id.btnInfo);
            btnHome.SetTypeface(fonts, TypefaceStyle.Normal);
            btnInfo.SetTypeface(fonts, TypefaceStyle.Normal);
            btnSettings.SetTypeface(fonts, TypefaceStyle.Normal);
            btnMyReviews.SetTypeface(fonts, TypefaceStyle.Normal);
            btnHome.Click += BtnHome_Click;
            btnSettings.Click += BtnSettings_Click;
            return view;
			
            }
			catch (System.Exception ex)
			{
                return null;

			}
        }

        public void BtnSettings_Click(object sender, System.EventArgs e)
        {
            try
            {
                var galleryPage = new Intent(this.Context, typeof(SetingActivity));
                StartActivity(galleryPage);
            }
            catch (System.Exception e1)
            {

                throw e1;
            }
            
        }

        private void BtnHome_Click(object sender, System.EventArgs e)
        {
            var galleryPage = new Intent(this.Context , typeof(DashboardActivity));
            StartActivity(galleryPage);

        }

        private void BtnGroup_Click(object sender, System.EventArgs e)
        {
            //var intent = new Intent(Activity, typeof(DashboardActivity));
            //StartActivity(intent);
            Toast.MakeText(Activity, "Clicked", ToastLength.Long).Show();
        }

        #region Setting Up recycler View With Divider
        //private void SetUpRecyclerView(View view)
        //{
        //    RecyclerView recyclerView = view.FindViewById<RecyclerView>(Resource.Id.drawerList);
        //    //List<Category> MainMenu = TGFPizzaService.GetMainMenu("EN80BX");
        //    //if(MainMenu!=null)
        //    //{
        //        NavDrawer adapter = new NavDrawer(Activity, NavigationCatagoriesList.GetNavCatagoryList());//NavigationCatagoriesList.GetNavCatagoryList()
        //        recyclerView.AddItemDecoration(new DividerItemDecoration(Activity, Resource.Xml.divider));
        //        recyclerView.SetAdapter(adapter);
        //        recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
        //    //}
        //    //else
        //    //{

        //    //}

        //}

        #endregion


        #region SetUpDrawer
        public void setUpDrawer(int fragmentId, DrawerLayout drawerLayout, Android.Support.V7.Widget.Toolbar toolbar)
        {
            mDrawerToggle = new Android.Support.V7.App.ActionBarDrawerToggle(Activity, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerLayout.AddDrawerListener(mDrawerToggle);  
            mDrawerToggle.SyncState();
        }
        #endregion
    }
}