// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PTApp
{
    [Register ("movieTableCell")]
    partial class movieTableCell
    {
        [Outlet]
        UIKit.UIImageView image1 { get; set; }


        [Outlet]
        UIKit.UIImageView image2 { get; set; }


        [Outlet]
        UIKit.UIImageView image3 { get; set; }


        [Outlet]
        UIKit.UILabel movieNameLabel { get; set; }


        [Outlet]
        UIKit.UILabel movieTimeLabel { get; set; }


        [Outlet]
        UIKit.UIButton PlusBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (image1 != null) {
                image1.Dispose ();
                image1 = null;
            }

            if (image2 != null) {
                image2.Dispose ();
                image2 = null;
            }

            if (image3 != null) {
                image3.Dispose ();
                image3 = null;
            }

            if (movieNameLabel != null) {
                movieNameLabel.Dispose ();
                movieNameLabel = null;
            }

            if (movieTimeLabel != null) {
                movieTimeLabel.Dispose ();
                movieTimeLabel = null;
            }
        }
    }
}