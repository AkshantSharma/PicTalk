using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using UIKit;

namespace PicTalk.iOS
{
	public partial class ImageViewController : UIViewController
	{

		public ImageViewController(List<UIImage> list, int row): base("ImageViewController", null)
		{
			this.list = list;
			this.row = row;
			ImageScrollView.ImageData = list;

		}

		List<UIImage> list;
		int row;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			UIPageViewController viewController;

			viewController = new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll,
			UIPageViewControllerNavigationOrientation.Horizontal,
			UIPageViewControllerSpineLocation.None, 20f);

			CarouselViewController pageZero = CarouselViewController.ImageViewControllerForPageIndex(row);

			viewController.SetViewControllers(new UIViewController[] { pageZero },
            UIPageViewControllerNavigationDirection.Forward,
                false, null);
			viewController.DataSource = new MyDataSource(this,list);
			viewController.View.UserInteractionEnabled = true;

			viewController.View.Frame = new CGRect(0, 60, this.View.Frame.Width,this.View.Frame.Height- 70 );

            AddChildViewController(viewController);
			View.AddSubview (viewController.View);
			viewController.DidMoveToParentViewController (this);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}

	class MyDataSource : UIPageViewControllerDataSource
	{
	
		private ImageViewController helpScreenController;
		List<UIImage> list;

	public MyDataSource(ImageViewController helpScreenController,List<UIImage> list)
	{
		this.helpScreenController = helpScreenController;
		this.list = list;
	}

	public override UIViewController GetPreviousViewController(UIPageViewController pageViewController,
															   UIViewController referenceViewController)
	{
		int index = ((CarouselViewController)referenceViewController).PageIndex;
		return (CarouselViewController)CarouselViewController.ImageViewControllerForPageIndex(index - 1);
	}

	public override UIViewController GetNextViewController(UIPageViewController pageViewController,
														   UIViewController referenceViewController)
	{
		int index = ((CarouselViewController)referenceViewController).PageIndex;
		return (CarouselViewController)CarouselViewController.ImageViewControllerForPageIndex(index + 1);
	}
}





}

