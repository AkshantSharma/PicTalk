using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content;
using System;
using Android.Runtime;
using PicTalk.Droid.Fragments;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using PicTalk.Utils;
using Android.Support.Design.Widget;
using Android.Support.V4.View;

namespace PicTalk.Droid.Activities
{
    [Activity(Label = "BaseActivity",Theme = "@style/PTAPPTheme")]
    public abstract class BaseActivity : AppCompatActivity
    {

        #region Private Member Variable

        private DrawerLayout FullLayout;
        private Android.Support.V7.Widget.Toolbar toolbar;
        private ProgressBar LoadingBar;
        FrameLayout FrameContent;
        private NavigationDrawerFragment drawerFragment;
        private IntPtr javaReference;
        private JniHandleOwnership transfer;

        //public BaseActivity(IntPtr javaReference, JniHandleOwnership transfer)
        //    :base(javaReference,transfer)
        //{
           
        //}




        #endregion

        #region Overide Set Content View
        public override void SetContentView(int layoutResID)
        {
            try
            {
                FullLayout = (DrawerLayout)LayoutInflater.Inflate(Resource.Layout.BaseLayout,null);
                Utility utils = new Utility();

                FullLayout.FindViewById<RelativeLayout>(Resource.Id.llContent)
                        .SetBackgroundColor(Android.Graphics.Color.ParseColor(utils.BackgroundColor));
                FrameContent = FullLayout.FindViewById<FrameLayout>(Resource.Id.activity_content);
                LayoutInflater.Inflate(layoutResID, FrameContent, true);

                base.SetContentView(FullLayout);

                toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.App_toolbar);

                if (UseToolbar())
                {
                    SetupToolbar();
                    SetupNavDrawer();
                }
                else
                {
                    toolbar.Visibility = ViewStates.Gone;
                    Window.AddFlags(WindowManagerFlags.Fullscreen);
                }

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                    Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                    Window.SetStatusBarColor(Color.Gray);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
        #endregion

        #region Setup Nav Drawer
        protected void SetupNavDrawer()
        {
            drawerFragment = (NavigationDrawerFragment)SupportFragmentManager.FindFragmentById(Resource.Id.navigation_drawer_fragment);
            FullLayout = FindViewById<DrawerLayout>(Resource.Id.nav_drawer_layout);
            drawerFragment.setUpDrawer(Resource.Id.navigation_drawer_fragment, FullLayout, toolbar);
        }
        #endregion

        #region UseToolbar
        /// <summary>
        /// Helper method that can be used by child classes to
        ///  specify that they don't want a link Toolbar or not
        /// </summary>
        /// <returns></returns>
        protected abstract bool UseToolbar();

        #endregion

        #region Show Snackbar
        /// <summary>
        /// This method will be used to show snack bar throughtout the app.
        /// </summary>
        /// <param name="SnackText"> Pass the text to show in snack bar</param>
        protected void ShowSnackbar(string SnackText)
        {
            Snackbar snackbar;
            snackbar = Snackbar.Make(FrameContent, SnackText, Snackbar.LengthLong);
            View SnackBarView = snackbar.View;
            SnackBarView.SetBackgroundResource(Resource.Color.nav_list_color);
            TextView Message = SnackBarView.FindViewById<TextView>(Resource.Id.snackbar_text);
            Message.SetTextColor(Color.Black);
            Typeface fonts = Typeface.CreateFromAsset(Assets, "open-sans.regular.ttf");
            Message.SetTypeface(fonts,TypefaceStyle.Bold);
            snackbar.SetActionTextColor(Resource.Color.primary_dark);
            
            snackbar.SetAction("SETTINGS", (view) =>
            {
                //Snackbar.Make(layout, "RETRY clicked", Snackbar.LengthLong).Show();
                //SetupNavDrawer();
                //InitView();
                StartActivity(new Intent(Android.Provider.Settings.ActionSettings));
            })
            .Show();
        }
        #endregion

        #region SetUp Toolbar
        private void SetupToolbar()
        {
                      
            TextView txt = FindViewById<TextView>(Resource.Id.txtTitle);
            Typeface tp = Typeface.CreateFromAsset(Assets, "Ceria Lebaran.ttf");
            txt.SetTypeface(tp, TypefaceStyle.Normal);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);

        }
        #endregion

        #region OnCreateOptionsMenu
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
        //    return base.OnCreateOptionsMenu(menu);
        //}

        #endregion

        #region OnOptionsItemSelected
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                //case Resource.Id.action_cart:
                //    StartActivity(typeof(PhoneVerificationActivity));
                //    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        #endregion

        #region On Back pressed when Drawer is opened
        public override void OnBackPressed()
        {
            if (FullLayout.IsDrawerOpen(GravityCompat.Start))
            {
                FullLayout.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        #endregion

    }
}