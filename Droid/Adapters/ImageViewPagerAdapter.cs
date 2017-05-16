using Android.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Content;
using Android.Widget;
using PicTalk.Droid.Models;
using Android.Runtime;
using Android.Graphics;
using Android.Graphics.Drawables;
using Com.Bumptech.Glide;

namespace PicTalk.Droid.Adapters
{
    [Activity(Label = "ImageViewPagerAdapter")]
    public class ImageViewPagerAdapter : PagerAdapter
    {
        private Context context;
        private ImagesCatalog images;

        public ImageViewPagerAdapter(Context context, ImagesCatalog images)
        {
            this.context = context;
            this.images = images;
        }

        public override int Count => images.Catalogs;

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }
        ImageView imgView;
        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
           
            imgView = new ImageView(context);
            Glide.With(this.context)  // Activity or Fragment
                        .Load(images[position].Images)
                        .Into(imgView);
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.AddView(imgView);
            return imgView;
        }

        // Display a caption for each Tree page in the PagerTitleStrip:
        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return null;//new Java.Lang.String(SplashCatalog[position].caption);
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object view)
        {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }
    }
}