using System;
using System.Collections.Generic;
using UIKit;

namespace PicTalk.iOS
{
	public partial class CarouselViewController : BaseViewController
	{
		public int PageIndex { get; private set; }
		public CarouselViewController(int pageIndex)
		{
			PageIndex = pageIndex;
		}
		public static CarouselViewController ImageViewControllerForPageIndex(int pageIndex)
		{
		return pageIndex >= 0 && pageIndex < ImageScrollView.ImageCount ?
		new CarouselViewController(pageIndex) : null;
		}

		public override void LoadView()
		{
		ImageScrollView scrollView = new ImageScrollView()
		{
		Index = PageIndex,
		AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
		};
		var ds = scrollView.Index;
		this.View = scrollView;
 		}
	}

}
