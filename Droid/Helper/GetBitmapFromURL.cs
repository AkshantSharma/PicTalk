using System;
using Android.Graphics;
using System.Net;

namespace PicTalk.Droid.Helper
{
    public class GetBitmapImage
    {
        public static Bitmap GetImageBitmapFromURL(String URL)
        {
            String ImageURL = URL;
            Bitmap imageBitmap = null;
            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(ImageURL);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
                return imageBitmap;
            }

        }
    }
}