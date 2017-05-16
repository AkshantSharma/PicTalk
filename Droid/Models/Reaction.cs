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

namespace PicTalk.Droid.Models
{
    public class Reaction
    {
        public string Tag { get; set; }
        public string Image { get; set; }
        public int UID { get; set; }
        public int MovieID { get; set; }

    }
}