using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using PicTalk.Droid.Adapters;
using System;

namespace PicTalk.Droid.ViewHolder
{
    public class CategoryListViewHolder: RecyclerView.ViewHolder
    {
        #region Private Members
        public ImageView ImageLogo, Imageone, Imagetwo, Imagethree;
        public TextView TextMovieName, TextDate;
        #endregion
        public CategoryListViewHolder(Context context, View view,Action<int> OnClickItem) :
            base(view)
        {

            PicTalk.Utils.Utility utils = new PicTalk.Utils.Utility();
            Typeface fonts = Typeface.CreateFromAsset(context.Assets, "fontawesome-webfont.ttf");


            view.FindViewById<LinearLayout>(Resource.Id.LinearMain).SetBackgroundColor(Android.Graphics.Color.ParseColor(utils.BackgroundColor));
            view.FindViewById<LinearLayout>(Resource.Id.LinearMain).SetBackgroundColor(Android.Graphics.Color.ParseColor(utils.BackgroundColor));


            TextMovieName = view.FindViewById<TextView>(Resource.Id.TextMovieName);
            TextMovieName.SetTextColor(Android.Graphics.Color.ParseColor(utils.ForegroundColor));
            TextMovieName.SetTextSize(Android.Util.ComplexUnitType.Dip,utils.TextSize);
            TextDate = view.FindViewById<TextView>(Resource.Id.TextDate);
            TextDate.SetTextColor(Android.Graphics.Color.ParseColor(utils.ForegroundColor));
            TextDate.SetTextSize(Android.Util.ComplexUnitType.Dip,utils.TextSize);

            Imageone = view.FindViewById<ImageView>(Resource.Id.Imageone);
            Imageone.SetMaxHeight(utils.DashboardImageSize);
            Imageone.SetMaxWidth(utils.DashboardImageSize);
            Imagetwo = view.FindViewById<ImageView>(Resource.Id.Imagetwo);
            Imagetwo.SetMaxHeight(utils.DashboardImageSize);
            Imagetwo.SetMaxWidth(utils.DashboardImageSize);

            Imagethree = view.FindViewById<ImageView>(Resource.Id.Imagethree);
            Imagethree.SetMaxHeight(utils.DashboardImageSize);
            Imagethree.SetMaxWidth(utils.DashboardImageSize);

            Button btnCamera = view.FindViewById<Button>(Resource.Id.btnCamera);
            btnCamera.SetTypeface(fonts, TypefaceStyle.Normal);
            btnCamera.SetTextColor(Android.Graphics.Color.ParseColor(utils.ForegroundColor));
            btnCamera.SetTextSize(Android.Util.ComplexUnitType.Dip, utils.TextSize);
            btnCamera.SetMaxHeight(utils.DashboardImageSize);
            btnCamera.SetMaxWidth(utils.DashboardImageSize);
            btnCamera.Click += (sender, e) => OnClickItem(Position);
            view.Click += (sender, e) => OnClickItem(Position);

        }
    }
}