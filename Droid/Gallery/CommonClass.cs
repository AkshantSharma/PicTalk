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
using Android.Net;

namespace PicTalk.Droid.Gallery
{
    public static class CommonClass
    {
        public static Bitmap btMap;
        public static string ImageTitle;

        public static File File { get; internal set; }
        public static Android.Net.Uri URI { get; internal set; }
    }
}