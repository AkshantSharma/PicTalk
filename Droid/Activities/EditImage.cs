using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicTalk.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Graphics;
using Android;
using Android.Support.V4.App;
using Android.Content.PM;
using Android.Locations;
using Java.Util;
using Java.IO;
using PicTalk.Droid.Gallery;
using System.IO;
using Android.Graphics.Drawables;

namespace PicTalk.Droid.Activities
{
    [Activity(Label = "EditImage",Theme = "@style/PTAPPTheme")]
    public class EditImage : BaseActivity
    {
        private LinearLayout LinearlayoutRange;
        ImageView _imageView;
        private SeekBar _seekBar;
        private TextView _textView;
        private Location locallocation;
        public Location location
        {
            get
            {
                return locallocation;
            }
            set
            {
                if (value != null)
                {
                    locallocation = value;
                    this.RunOnUiThread(() =>
                    {
                        Geocoder geocoder = new Geocoder(ApplicationContext, Locale.Default);
                        try
                        {
                            var listAddresses = geocoder.GetFromLocation(value.Latitude, value.Longitude, 1);
                            if (null != listAddresses && listAddresses.Count > 0)
                            {
                                String _Location = listAddresses[0].GetAddressLine(0);
                                FindViewById<TextView>(PicTalk.Droid.Resource.Id.textView1).Text = FindViewById<TextView>
                                    (PicTalk.Droid.Resource.Id.textView1).Text + "nearby : " + _Location;
                            }
                        }
                        catch (System.IO.IOException e)
                        {
                            throw e;
                        }
                        
                    });
                }
            }
        }

        private void positive(object sender, DialogClickEventArgs e)
        {

        
        }
        private void negative(object sender, DialogClickEventArgs e)
        {
            return;
        }

		Bitmap bitmap = null;
		LocationManager locationManager;
        bool gps_enabled = false;
        bool network_enabled = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(PicTalk.Droid.Resource.Layout.EditImage);
                locationManager = (LocationManager)GetSystemService(Context.LocationService);
				Button btnShare = FindViewById<Button>(Resource.Id.buttonShare);

				btnShare.Click += (object sender, EventArgs e) =>
				{

					Share("Share", "Sharing PTAPP");


				};
				try
                {
                    gps_enabled = locationManager.IsProviderEnabled(LocationManager.GpsProvider);
                }
                catch (Exception ex) { }

                try
                {
                    network_enabled = locationManager.IsProviderEnabled(LocationManager.NetworkProvider);
                }
                catch (Exception ex) { }

                if (!gps_enabled && !network_enabled)
                {
                    // notify user
                    var dialog = new Android.Support.V7.App.AlertDialog.Builder(this);
                    dialog.SetMessage("Gps is not available. Please turn on.");
                    dialog.SetPositiveButton("Open Setings",
                        (o,e2) =>
                        {
                            Intent myIntent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                            this.StartActivityForResult(myIntent,555);
                        });
                    dialog.SetNegativeButton("Cancel",
                        (o1,e3) =>
                        {
                        _imageView = FindViewById<ImageView>(PicTalk.Droid.Resource.Id.imageView);
                            _seekBar = FindViewById<SeekBar>(PicTalk.Droid.Resource.Id.seekBar1);
                            _seekBar.Progress = 60;
                            _textView = FindViewById<TextView>(PicTalk.Droid.Resource.Id.textView1);
                            _textView.Text = string.Format("You are {0}% happy. ", 60);
                            _seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
                            {
                                if (e.FromUser)
                                {
                                        try
                                        {
                                                _textView.Text = string.Format("You are {0}% happy.", e.Progress);
                                        }
                                        catch (System.IO.IOException e1)
                                        {
                                            throw e1;
                                        }
                                }
                            };
                            int height = _imageView.Height;
                            int width = Resources.DisplayMetrics.WidthPixels;
                            BitmapFactory.Options bmOptions = new BitmapFactory.Options()
                            {
                                InSampleSize = 2,
                                InPreferredConfig = Android.Graphics.Bitmap.Config.Rgb565
                            };
                            Bitmap bitmap = null;
                            if (CommonClass.URI != null)
                            {
                                _imageView.SetImageURI(Gallery.CommonClass.URI);
                            }
                            else
                            {
                                bitmap = BitmapFactory.DecodeFile(CommonClass.File.AbsolutePath, bmOptions);

                                if (bitmap != null)
                                {
                                    bitmap = Bitmap.CreateBitmap(bitmap);
                                    _imageView.SetImageBitmap(bitmap);
                                }
                            }
                        });
                    dialog.Show();
                }
                else
                {
                    if (PackageManager.CheckPermission(Manifest.Permission.AccessCoarseLocation, this.PackageName) != Android.Content.PM.Permission.Granted)
                    {
                        ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation }, 001);
                    }
                    else
                    {
                        locallocation = locationManager.GetLastKnownLocation(LocationManager.GpsProvider);
                        locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, new ListnerClass(this));
                        if(locallocation == null)
                        {
                            locallocation = locationManager.GetLastKnownLocation(LocationManager.GpsProvider);
                        }
                    }



                    _imageView = FindViewById<ImageView>(PicTalk.Droid.Resource.Id.imageView);
                    _seekBar = FindViewById<SeekBar>(PicTalk.Droid.Resource.Id.seekBar1);
                    _seekBar.Progress = 60;
                    _textView = FindViewById<TextView>(PicTalk.Droid.Resource.Id.textView1);
                    if (locallocation != null)
                    {
                        Geocoder geocoder = new Geocoder(ApplicationContext, Locale.Default);
                        try
                        {
                            var listAddresses = geocoder.GetFromLocation(locallocation.Latitude, locallocation.Longitude, 1);
                            if (null != listAddresses && listAddresses.Count > 0)
                            {
                                String _Location = listAddresses[0].GetAddressLine(0);
                                _textView.Text = string.Format("You are {0}% happy. Nearby : {1}", 60,_Location );
                            }
                        }
                        catch (System.IO.IOException e)
                        {
                            throw e;
                        }

                    }
                    _seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
                    {
                        if (e.FromUser)
                        {
                            if (locallocation != null)
                            {
                                Geocoder geocoder = new Geocoder(ApplicationContext, Locale.Default);
                                try
                                {
                                    var listAddresses = geocoder.GetFromLocation(locallocation.Latitude, locallocation.Longitude, 1);
                                    if (null != listAddresses && listAddresses.Count > 0)
                                    {
                                        String _Location = listAddresses[0].GetAddressLine(0);
                                        _textView.Text = string.Format("You are {0}% happy. Nearby : {1}", e.Progress, _Location);
                                    }
                                }
                                catch (System.IO.IOException e1)
                                {
                                    throw e1;
                                }
                            }
                        }
                    };
                    int height = _imageView.Height;
                    int width = Resources.DisplayMetrics.WidthPixels;
                    BitmapFactory.Options bmOptions = new BitmapFactory.Options()
                    {
                        InSampleSize = 2,
                        InPreferredConfig = Android.Graphics.Bitmap.Config.Rgb565
                    };
                    if (CommonClass.URI != null)
                    {
                        _imageView.SetImageURI(CommonClass.URI);
                    }
                    else
                    {
                        bitmap = BitmapFactory.DecodeFile(CommonClass.File.AbsolutePath, bmOptions);

                        if (bitmap != null)
                        {
                            bitmap = Bitmap.CreateBitmap(bitmap);
                            _imageView.SetImageBitmap(bitmap);
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                Toast.MakeText(this, "Please Make Sure to select image from gallery", ToastLength.Long);
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 555)
            {
                try
                {
                    gps_enabled = locationManager.IsProviderEnabled(LocationManager.GpsProvider);
                }
                catch (Exception ex) { }

                if(!gps_enabled)
                {
                    return;
                }
                if (PackageManager.CheckPermission(Manifest.Permission.AccessCoarseLocation, this.PackageName) != Android.Content.PM.Permission.Granted)
                {
                    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation }, 001);
                }
                else
                {
                    //Thread.Sleep(100);
                    locallocation = locationManager.GetLastKnownLocation(LocationManager.GpsProvider);
                    locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, new ListnerClass(this));
                    
                }
                _imageView = FindViewById<ImageView>(PicTalk.Droid.Resource.Id.imageView);
                _seekBar = FindViewById<SeekBar>(PicTalk.Droid.Resource.Id.seekBar1);
                _seekBar.Progress = 60;
                _textView = FindViewById<TextView>(PicTalk.Droid.Resource.Id.textView1);
                if (locallocation == null)
                {
                    locallocation = locationManager.GetLastKnownLocation(LocationManager.GpsProvider);
                }

                if(locallocation != null)
                {
                    _textView.Text = string.Format("You are {0}% happy. Location is {1} : {2}", 60, locallocation.Latitude, locallocation.Longitude);
                }
                _seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
                {
                    if (e.FromUser)
                    {
                        if (locallocation != null)
                        {
                            _textView.Text = string.Format("You are {0}% happy. Location is {1} : {2}", e.Progress, locallocation.Latitude, locallocation.Longitude);
                        }
                    }
                };

                int height = _imageView.Height;
                int width = Resources.DisplayMetrics.WidthPixels;
                BitmapFactory.Options bmOptions = new BitmapFactory.Options()
                {
                    InSampleSize = 2,
                    InPreferredConfig = Android.Graphics.Bitmap.Config.Rgb565
                };
                Bitmap bitmap = null;
                if (CommonClass.URI != null)
                {
                    _imageView.SetImageURI(CommonClass.URI);
                }
                else
                {
                    bitmap = BitmapFactory.DecodeFile(CommonClass.File.AbsolutePath, bmOptions);

                    if (bitmap != null)
                    {
                        bitmap = Bitmap.CreateBitmap(bitmap);
                        _imageView.SetImageBitmap(bitmap);
                    }
                }

            }
        }


        public class ListnerClass : Java.Lang.Object, ILocationListener
        {
            private EditImage ed;

            public ListnerClass(EditImage ed)
            {
                this.ed = ed;
                
            }
            public void OnLocationChanged(Location location)
            {
                ed.location = location;
            }

            public void OnProviderDisabled(string provider)
            {
            }

            public void OnProviderEnabled(string provider)
            {
            }

            public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
            {
            }
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case 1:
                    if (grantResults.Length > 0 && grantResults[0] == Android.Content.PM.Permission.Granted)
                    {
                        var locationManager = (LocationManager)GetSystemService(Context.LocationService);
                        locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0,new ListnerClass(this));
                        //All good!
                    }
                    else
                    {

                        //Toast.makeText(this, "Need your location!", Toast.LENGTH_SHORT).show()
                    }

                    break;
            }

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override bool UseToolbar()
        {
            return true;
        }

		public void Share(string title, string content)
		{
			if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
				return;

            Bitmap b = ((BitmapDrawable)_imageView.Drawable).Bitmap;

			var tempFilename = "test.png";
			var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
			var filePath = System.IO.Path.Combine(sdCardPath, tempFilename);
			using (var os = new FileStream(filePath, FileMode.Create))
			{
				b.Compress(Bitmap.CompressFormat.Png, 100, os);
			}
			b.Dispose();

			var imageUri = Android.Net.Uri.Parse($"file://{sdCardPath}/{tempFilename}");
			var sharingIntent = new Intent();
			sharingIntent.SetAction(Intent.ActionSend);
			sharingIntent.SetType("image/*");
			sharingIntent.PutExtra(Intent.ExtraText, content);
			sharingIntent.PutExtra(Intent.ExtraStream, imageUri);
			sharingIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
			StartActivity(Intent.CreateChooser(sharingIntent, title));
		}
    }
}