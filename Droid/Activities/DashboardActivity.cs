using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using PicTalk.Droid.Adapters;
using PicTalk.Droid.Models;
using PicTalk.Models;
using System;
using PicTalk.Droid.Util;
using Android.Content;
using PicTalk;
using PicTalk.ViewModels;
using Android.Runtime;
using System.Threading.Tasks;
using PicTalk.Models.ModelResponses;
using System.Net.Http;
using PicTalk.Helpers;
using System.Timers;
using static Android.Text.TextUtils;
using PicTalk.Droid;
using PicTalk.Utils;
using PicTalk.Droid.Gallery;

namespace PicTalk.Droid.Activities
{
    [Activity(Label = "PTAPP", MainLauncher = false, Icon = "@mipmap/icon", Theme = "@style/PTAPPTheme")]
    public class DashboardActivity : BaseActivity
    {
        #region Private Member
        private RecyclerView CategoryRecyclerView;
        public CategoryListAdapter adapter;
        List<MoviesModel> MoviesList;
        HomeViewModel hm;
        TextView TextNews;
        #endregion
        
        #region Task Schedular Exception

        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            var newExc = new Exception("TaskSchedulerOnUnobservedTaskException", unobservedTaskExceptionEventArgs.Exception);

            PicTalk.Helpers.ExceptionHandling.LogUnhandledException(newExc);
        }

        #endregion

        #region Current Domain Exception

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var newExc = new Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as Exception);
            PicTalk.Helpers.ExceptionHandling.LogUnhandledException(newExc);
        }

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            SetContentView(Resource.Layout.DashboardLayout);
            hm = new HomeViewModel();
            InitView();

        }

        protected override bool UseToolbar()
        {
            return true;
        }

        private void InitView()
        {
            Utility utils = new Utility();
            FindViewById<LinearLayout>(Resource.Id.layout_main).SetBackgroundColor(Android.Graphics.Color.ParseColor(utils.BackgroundColor));
            FindViewById<LinearLayout>(Resource.Id.layout_snckBar).SetBackgroundColor(Android.Graphics.Color.ParseColor(utils.SnackBarColor));
            TextNews = FindViewById<TextView>(Resource.Id.TextNews);
            TextNews.SetTextColor(Android.Graphics.Color.ParseColor(utils.BackgroundColor));
            TextNews.SetMarqueeRepeatLimit(50);
            TextNews.Ellipsize = TruncateAt.Marquee;
            TextNews.SetSingleLine(true);
            TextNews.Selected = true;
            TextNews.SetTextSize(Android.Util.ComplexUnitType.Dip, utils.TextSize);
            TextNews.Text = "Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.";
            CategoryRecyclerView = FindViewById<RecyclerView>(Resource.Id.category_recycler_view);
            CategoryRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            adapter = new CategoryListAdapter(this, hm.MoviesmodelResponse);
            CategoryRecyclerView.AddItemDecoration(new Util.DividerItemDecoration(this, Resource.Xml.divider));
            CategoryRecyclerView.SetAdapter(adapter);
            adapter.ItemClick += OnItemClick;
        }

        private void OnItemClick(object sender, int position)
        {
            var galleryPage = new Intent(this.BaseContext, typeof(GalleryActivity));            
            StartActivity(galleryPage);
        }
    }
}