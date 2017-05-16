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
    [Register ("DashBoardController")]
    partial class DashBoardController
    {
        [Outlet]
        UIKit.UITableView movieTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (movieTableView != null) {
                movieTableView.Dispose ();
                movieTableView = null;
            }
        }
    }
}