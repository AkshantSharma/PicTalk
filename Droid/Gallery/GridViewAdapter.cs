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
using Com.Bumptech.Glide;

namespace PicTalk.Droid.Gallery
{
    public class GridViewAdapter : ArrayAdapter<ImageItem>
    {
        private Context context;
        private int layoutResourceId;
        private List<ImageItem> data = new List<ImageItem>();

        public GridViewAdapter(Context context, int layoutResourceId, List<ImageItem> data) : base(context, layoutResourceId, data)
        {
            this.layoutResourceId = layoutResourceId;
            this.context = context;
            this.data = data;
            

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            GViewHolder holder = null;
            if (row == null)
            {
                LayoutInflater inflater = ((Activity)context).LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);
                PicTalk.Utils.Utility util = new PicTalk.Utils.Utility();
                row.FindViewById<LinearLayout>(Resource.Id.linearmain)
                    .SetBackgroundColor(Android.Graphics.Color.ParseColor(util.BackgroundColor));
                row.FindViewById<ImageView>(Resource.Id.image)
                    .SetBackgroundColor(Android.Graphics.Color.ParseColor(util.BackgroundColor));
                row.FindViewById<ImageView>(Resource.Id.image)
                    .SetMaxHeight(util.GalleryImageHeight);
                row.FindViewById<ImageView>(Resource.Id.image)
                    .SetMaxHeight(util.GalleryImageWidth);
                row.FindViewById<ImageView>(Resource.Id.image)
                    .SetScaleType(ImageView.ScaleType.FitCenter);
                holder = new GViewHolder();
                holder.imageTitle = (TextView)row.FindViewById(Resource.Id.text);
                holder.image = (ImageView)row.FindViewById(Resource.Id.image);
                row.Tag = holder;// (holder);//lucky
            }
            else
            {
                holder = (GViewHolder)row.Tag;//  getTag();
            }
            ImageItem item = data[position];// .get(position);
            holder.image.SetImageBitmap(item.getImage());
            return row;
        }
    }


    class GViewHolder : Java.Lang.Object
    {
        public TextView imageTitle;
        public ImageView image;
    }
}