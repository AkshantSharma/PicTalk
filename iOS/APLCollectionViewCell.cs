using System;
using CoreGraphics;
using CoreAnimation;
using Foundation;
using UIKit;

namespace PicTalk.iOS {

	public partial class APLCollectionViewCell : UICollectionViewCell {

		public static readonly NSString Key = new NSString ("APLCollectionViewCell");

		[Export ("initWithFrame:")]
		public APLCollectionViewCell (CGRect frame) : base (frame)
		{
			BackgroundColor = UIColor.Cyan;
			ImageView = new UIImageView (Bounds);
			ImageView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
			ImageView.Layer.BorderWidth = 3.0f;
			ImageView.ClipsToBounds = true;
			ImageView.Layer.BorderColor = UIColor.White.CGColor;
			ImageView.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.LeftEdge | CAEdgeAntialiasingMask.RightEdge | CAEdgeAntialiasingMask.BottomEdge | CAEdgeAntialiasingMask.TopEdge;
			ImageView.LayoutMargins = new UIEdgeInsets(0, 0, 0, 0);
			ContentView.AddSubview (ImageView);

		}

		public UIImageView ImageView { get; private set; }
	}
}
