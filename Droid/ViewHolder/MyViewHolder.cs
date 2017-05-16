using System;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace PicTalk.Droid.ViewHolder
{
    class MyViewHolder: RecyclerView.ViewHolder
    {
        public ImageView Icon;
        public TextView txtTitle;

        public MyViewHolder(View view) :
            base(view)
        {
            //txtDesName = view.FindViewById<TextView>(Resource.Id.txtDesName);
            txtTitle = view.FindViewById<TextView>(Resource.Id.txtTitle);
            Icon = view.FindViewById<ImageView>(Resource.Id.arrowIcon);
        }
    }
}