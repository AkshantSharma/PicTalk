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
using PicTalk.Droid;
using Android.Support.V4.View;
using PicTalk.Models;
using PicTalk.Droid.Adapters;
using PicTalk.Droid.Models;

namespace PicTalk.Droid.Activities
{
    [Activity(Label = "ImageFullView",Theme = "@style/PTAPPTheme")]
    public class ImageFullView : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ImageFullView);
            int Position = Intent.GetIntExtra("Position", 0);
            ViewPager ImagePager = FindViewById<ViewPager>(Resource.Id.ImageviewPager);
            ImagesCatalog imagesCatalogs = new ImagesCatalog();
            ImagePager.Adapter = new ImageViewPagerAdapter(this, imagesCatalogs);
            ImagePager.SetCurrentItem(Position, true);
        }

        protected override bool UseToolbar()
        {
            return true;
        }
    }
}