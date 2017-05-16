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
using Android.Graphics;
using Java.IO;
using Com.Bumptech.Glide;

namespace PicTalk.Droid.Gallery
{
    
    public class ImageItem
    {
        private Bitmap image;
        private String title;

     

        public ImageItem(Bitmap image, String title)
        {
           

            this.image = image;
            this.title = title;
        }

        public Bitmap getImage()
        {
            return image;
        }

        public void setImage(Bitmap image)
        {
            this.image = image;
        }

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

      
    }
}