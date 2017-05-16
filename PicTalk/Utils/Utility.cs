using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicTalk.Utils
{
    public class Utility
    {

        public Utility()
        {
            BackgroundColor = "#FFFFFF";

            ForegroundColor = "#439DBB";

            SnackBarColor = "#439DBB";

            TextSize = 12;

            DashboardImageSize = 50;

            GalleryImageWidth = 100;

            GalleryImageHeight = 100;

            TextSizeHeader = 16;
        }
        public int GalleryImageHeight { get; set; }

        public int GalleryImageWidth { get; set; }

        public int DashboardImageSize { get; set; }

        public float TextSize { get; set; }

        public float TextSizeHeader { get; set; }

        public string BackgroundColor { get; set; }

        public string ForegroundColor { get; set; }

        public string SnackBarColor { get; set; }









    }
}
