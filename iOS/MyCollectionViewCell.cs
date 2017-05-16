using System;
using CoreGraphics;
using CoreAnimation;
using Foundation;
using UIKit;

namespace PicTalk.iOS
{
	public partial class MyCollectionViewCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString("MyCollectionViewCell");
		public static readonly UINib Nib;

		static MyCollectionViewCell()
		{
			Nib = UINib.FromName("MyCollectionViewCell", NSBundle.MainBundle);
		}

		protected MyCollectionViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			BackgroundColor = UIColor.Cyan;
			ImageView = new UIImageView(Bounds);
			ImageView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
			ImageView.Layer.BorderWidth = 3.0f;
			ImageView.ClipsToBounds = true;
			ImageView.Layer.BorderColor = UIColor.White.CGColor;
			ImageView.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.LeftEdge | CAEdgeAntialiasingMask.RightEdge | CAEdgeAntialiasingMask.BottomEdge | CAEdgeAntialiasingMask.TopEdge;
			ImageView.LayoutMargins = new UIEdgeInsets(0,0,0,0);
			ContentView.AddSubview(ImageView);
		}
		public UIImageView ImageView { get; private set; }

	}
}
