using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Provider.MediaStore;
using static Android.Provider.MediaStore.Images;

namespace PicTalk.Droid.Activities
{
    [Activity(Label = "ImageFullView",Theme = "@style/PTAPPTheme")]
    public class SetingActivity : Activity
    {

        public SetingActivity()
        {
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                SetContentView(Resource.Layout.SetingLayout);

                TextView txtLocalStorage = FindViewById<TextView>(Resource.Id.editTextLocalStorage);
                txtLocalStorage.TextChanged += (sender, e) => {


                    if (txtLocalStorage.Text.Count() > 3)
					{
						txtLocalStorage.Text = "200";
					}

                    if(txtLocalStorage.Text == "")
                    {
                        txtLocalStorage.Text = "200";
                    }

                };
                Button btnShare = FindViewById<Button>(Resource.Id.buttonShare);

                btnShare.Click += (object sender, EventArgs e) => 
                {
				
                    Share("Share","Sharing PTAPP");


				};




			}
            catch (Exception e)
            {
                throw e;
            }
            // Create your application here
        }


		public void Share(string title, string content)
		{
			if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
				return;

            Bitmap b = BitmapFactory.DecodeResource(Resources, Resource.Mipmap.e);

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
			sharingIntent.PutExtra(Intent.ExtraStream, b);
			sharingIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
			StartActivity(Intent.CreateChooser(sharingIntent, title));
		}

        //protected override bool UseToolbar()
        //{
        //    return true;
        //}
    }
}