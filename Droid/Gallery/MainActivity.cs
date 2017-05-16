using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Content;
using System;
using Android.Provider;
using Android.Content.PM;
using PicTalk.Droid.Activities;
using Java.IO;
using static Android.Graphics.Bitmap;
using PicTalk.Droid.Models;
using System.Threading;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Request.Target;
//using Android.Support.V7.Widget;

namespace PicTalk.Droid.Gallery
{
    [Activity(Label = "Gallery",Theme = "@style/PTAPPTheme")]
    public class GalleryActivity : BaseActivity
    {
        private GridView gridView;
        private GridViewAdapter gridAdapter;

        Java.IO.File _file;
        Java.IO.File _dir;
        ImageView _imageView;

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities = PackageManager.QueryIntentActivities
                                    (intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void CreateDirectoryForPictures()
        {
            _dir = new Java.IO.File
                    (Android.OS.Environment.GetExternalStoragePublicDirectory
                        (Android.OS.Environment.DirectoryPictures), "PTGALLERY");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            _file = new Java.IO.File(_dir, String.Format("PTPhoto_{0}.jpg", Guid.NewGuid()));

            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Android.Net.Uri contentUri = null;
            if (resultCode == Result.Canceled) return;

            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                contentUri = data.Data;
                Intent intent = new Intent(this.BaseContext, typeof(EditImage));
                CommonClass.File = null;
                CommonClass.URI = contentUri;
                StartActivity(intent);
                return;
            }

            // make it available in the gallery
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            if (_file != null)
            {
                CommonClass.URI = null;
                contentUri = Android.Net.Uri.FromFile(_file);
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);

                // display in ImageView. We will resize the bitmap to fit the display
                // Loading the full sized image will consume to much memory 
                // and cause the application to crash.
                //send to next activity

                Intent intent = new Intent(this.BaseContext, typeof(EditImage));
                CommonClass.File = _file;
                StartActivity(intent);
                //int height = _imgView.Height;
                //int width = Resources.DisplayMetrics.WidthPixels;
                //using (Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height))
                //{
                //    _imgView.SetImageBitmap(bitmap);
                //}
            }

        }

        Button btnCamera;
        Button btnGallery;
        protected override void OnCreate(Bundle bundle)
        {
            try
            {

                    base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);
            PicTalk.Utils.Utility utils = new PicTalk.Utils.Utility();
            Typeface fonts = Typeface.CreateFromAsset(BaseContext.Assets, "fontawesome-webfont.ttf");
            FindViewById<RelativeLayout>(Resource.Id.relativeMain).SetBackgroundColor(Android.Graphics.Color.ParseColor(utils.BackgroundColor));
            btnCamera = FindViewById<Button>(Resource.Id.btnCamera);
            //btnCamera.Text = "";
            btnCamera.SetTypeface(fonts, TypefaceStyle.Normal);
            btnCamera.SetTextColor(Android.Graphics.Color.ParseColor(utils.ForegroundColor));
            btnCamera.SetTextSize(Android.Util.ComplexUnitType.Dip, 50);
            btnCamera.SetMaxHeight(utils.DashboardImageSize);
            btnCamera.SetMaxWidth(utils.DashboardImageSize);
            System.Threading.Timer tm = new Timer(Tick, null, 1, 100);
            //GlideDrawableImageViewTarget imageViewTarget = new GlideDrawableImageViewTarget(btnCamera);
            //Glide.With(this).Load(Resource.Raw.cameraicon).Into(imageViewTarget);
            btnGallery = FindViewById<Button>(Resource.Id.btnGallery);
            btnGallery.SetTypeface(fonts, TypefaceStyle.Normal);
            btnGallery.SetTextColor(Android.Graphics.Color.ParseColor(utils.ForegroundColor));
            btnGallery.SetTextSize(Android.Util.ComplexUnitType.Dip, 50);
            btnGallery.SetMaxHeight(utils.DashboardImageSize);
            btnGallery.SetMaxWidth(utils.DashboardImageSize);
            // GlideDrawableImageViewTarget imageViewTarget1 = new GlideDrawableImageViewTarget(btnGallery);
            // Glide.With(this).Load(Resource.Raw.galleryicon).Into(imageViewTarget1);
            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
                btnCamera.Click += TakeAPicture;
            }
            btnGallery.Click += BtnGallery_Click;
            gridView = (GridView)FindViewById(Resource.Id.gridView);
            gridAdapter = new GridViewAdapter(this, Resource.Layout.grid_item_layout, getData());
            gridView.Adapter = gridAdapter;
            gridView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                try
                {

                    var item = args.Parent.GetItemAtPosition(args.Position).Cast<ImageItem>();
                    //Create intent
                    int Position = args.Position;
                    Intent intent = new Intent(this.BaseContext, typeof(ImageFullView));
                    intent.PutExtra("Position", Position);
                   // Intent intent = new Intent(this.BaseContext, typeof(DetailsActivity));
                    CommonClass.ImageTitle = item.getTitle();
                    CommonClass.btMap = item.getImage();
                    //Start details activity
                    StartActivity(intent);
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            };
			}
			catch (Exception ex)
			{

			}

		}

        int i = 0;
        private void Tick(object state)
        {
            this.RunOnUiThread(() =>
            {
                switch (i)
                {
                    case 0:
                        btnGallery.SetTextColor(Android.Graphics.Color.ParseColor("#4c4cff"));
                        btnCamera.SetTextColor(Android.Graphics.Color.ParseColor ("#4c4cff"));
                        i = 1;
                        break;
                    case 1:
                        btnGallery.SetTextColor(Android.Graphics.Color.ParseColor("#6666ff"));
                        btnCamera.SetTextColor(Android.Graphics.Color.ParseColor ("#6666ff"));
                        i = 2;
                        break;
                    case 2:
                        btnGallery.SetTextColor(Android.Graphics.Color.ParseColor("#7f7fff"));
                        btnCamera.SetTextColor(Android.Graphics.Color.ParseColor ("#7f7fff"));
                        i = 3;
                        break;
                    case 3:
                        btnGallery.SetTextColor(Android.Graphics.Color.ParseColor("#9999ff"));
                        btnCamera.SetTextColor(Android.Graphics.Color.ParseColor ("#9999ff"));
                        i = 4;
                        break;
                    case 4:
                        btnGallery.SetTextColor(Android.Graphics.Color.ParseColor("#b2b2ff"));
                        btnCamera.SetTextColor(Android.Graphics.Color.ParseColor ("#b2b2ff"));
                        i = 5;
                        break;
                    case 5:
                        btnGallery.SetTextColor(Android.Graphics.Color.ParseColor("#ccccff"));
                        btnCamera.SetTextColor(Android.Graphics.Color.ParseColor ("#ccccff"));
                        i = 0;
                        break;
                    default:
                        break;
                }
            });
        }

        public static readonly int PickImageId = 1000;

        private void BtnGallery_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);

        }

       
        private List<ImageItem> getData()
        {
            GC.Collect();
            List<ImageItem> imageItems = new List<ImageItem>();
            var a = new BitmapFactory.Options()
            {
                InSampleSize = 2,
                InPreferredConfig = Config.Rgb565
            };

            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources,Resource.Mipmap.a,a),""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.b,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.c,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.d,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.e,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.f,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.g,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.h,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.i,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.j,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.k,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.l,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.m,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.n,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.o,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.p,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.q,a), ""));
            imageItems.Add(new ImageItem(BitmapFactory.DecodeResource(this.Resources, Resource.Mipmap.r,a), ""));
            return imageItems;
        }

        protected override bool UseToolbar()
        {
            return true;
        }
    }

    public static class ObjectTypeHelper
    {

        public static T Cast<T>(this Java.Lang.Object obj) where T : class
        {
            var propertyInfo = obj.GetType().GetProperty("Instance");
            return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
        }

    }
}

