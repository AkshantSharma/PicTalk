using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Graphics;
using System;

namespace PicTalk.Droid.Gallery
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : Activity
    {
      
        //private Bitmap _image;
        //public DetailsActivity(Bitmap image)
        //{
        //    _image = image;
        //}
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.details_activity);
            



            string title = Intent.GetStringExtra("title");
            Bitmap bitmap = CommonClass.btMap;
            //Bitmap bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.image_1);
            //notBuilder.setLargeIcon(largeIcon);

            TextView titleTextView = (TextView)FindViewById(Resource.Id.title);
            titleTextView.Text = "hello";// setText(title);

            ImageView imageView = (ImageView)FindViewById(Resource.Id.image);
            imageView.SetImageBitmap(bitmap);

            // Create your application here
        }

       
    }
}