using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using AVFoundation;
using CoreGraphics;
using FontAwesomeXamarin;
using Foundation;
using ObjCRuntime;
using Photos;
using UIKit;

namespace PicTalk.iOS
{
	public partial class GalleryController : UICollectionViewController
	{
public const int MAX_COUNT = 20;

		List<UIImage> list;

		UIImagePickerController imagePicker;


public Task RequestAccess()
{
	var tcs = new TaskCompletionSource<object>();
	PHPhotoLibrary.RequestAuthorization(_ => tcs.SetResult(null));
	return tcs.Task;
}


public async void requestPermission()
{
	await AuthorizeCameraUse();
}


async Task AuthorizeCameraUse()
{
	var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);

	if (authorizationStatus != AVAuthorizationStatus.Authorized)
	{
		await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
	}
}


		public void callActionSheet(int mediaType)
		{
			//1 for photoGalleryBtn 
			//2 fro camera
			string message = "Application is not allowed to access capture device. Please click on Settings to change the security options.";

			if (mediaType == 1)
			{
				var status = PHPhotoLibrary.AuthorizationStatus;
				if (status == PHAuthorizationStatus.Authorized)
				{

					imagePicker = new UIImagePickerController();
					imagePicker.Delegate = this;
					imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
					imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
					imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
					imagePicker.Canceled += Handle_Canceled;
					NavigationController.PresentModalViewController(imagePicker, true);
				}
				if (status == PHAuthorizationStatus.NotDetermined)
				{
					RequestAccess();
				}
				else
				{
					Console.WriteLine("access not granted");
					var alert = UIAlertController.Create("Access Denied.", message, UIAlertControllerStyle.Alert);
					NSUrl url = new NSUrl(UIApplication.OpenSettingsUrlString);
					alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
					alert.AddAction(UIAlertAction.Create("Settings", UIAlertActionStyle.Default, delegate (UIAlertAction obj)
					{
						if (UIApplication.SharedApplication.CanOpenUrl(url))
						{
							UIApplication.SharedApplication.OpenUrl(url);
						}
					}));
					PresentViewController(alert, true, null);
				}
			}
			else
			{

				AVAuthorizationStatus permission_status = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);

				if (permission_status == AVAuthorizationStatus.Authorized)
				{
					imagePicker = new UIImagePickerController();

					imagePicker.Delegate = this;
					imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
					imagePicker.CameraDevice = UIImagePickerControllerCameraDevice.Front;

					imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
					imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
					imagePicker.Canceled += Handle_Canceled;
					NavigationController.PresentModalViewController(imagePicker, true);
				}
				if (permission_status == AVAuthorizationStatus.NotDetermined)
				{
					requestPermission();
				}
				else
				{
					Console.WriteLine("Access denied!!");
					var alert = UIAlertController.Create("Access Denied", message, UIAlertControllerStyle.Alert);
					NSUrl url = new NSUrl(UIApplication.OpenSettingsUrlString);
					alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
					alert.AddAction(UIAlertAction.Create("Settings", UIAlertActionStyle.Default, delegate (UIAlertAction obj)
					{
						if (UIApplication.SharedApplication.CanOpenUrl(url))
						{
							UIApplication.SharedApplication.OpenUrl(url);
						}
					}));
					PresentViewController(alert, true, null);

				}

			}
		}

public static bool IsCameraAuthorized()
{
	
	AVAuthorizationStatus authStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);
	if (authStatus == AVAuthorizationStatus.Authorized)
	{
		// do your logic
		return true;
	}
	else if (authStatus == AVAuthorizationStatus.Denied)
	{
		// denied
		return false;
	}
	else if (authStatus == AVAuthorizationStatus.Restricted)
	{
		// restricted, normally won't happen
		return false;
	}
	else if (authStatus == AVAuthorizationStatus.NotDetermined)
	{
		// not determined?!
		return false;
	}
	else
	{
		return false;
		// impossible, unknown authorization status
	}
}
		UIButton cameraBtn;
UIButton galleryBtn;
		public GalleryController(UICollectionViewLayout layout) : base(layout)
		{
			list = new List<UIImage>();
			CollectionView.RegisterClassForCell(typeof(APLCollectionViewCell), APLCollectionViewCell.Key);
			CollectionView.BackgroundColor = UIColor.White;

			//camera and gallery icon
			cameraBtn = new FAButton(FontAwesome.FACamera, UIColor.Blue, 20)
			{
				Frame = new RectangleF((float)((this.View.Frame.Width/2)/2)-10, 0, 30, 30)
			};
			System.Threading.Timer tm = new System.Threading.Timer(Tick, null, 1,100);
			cameraBtn.AddGestureRecognizer(new UITapGestureRecognizer((UITapGestureRecognizer obj) =>
			{
				AVCaptureDevice.RequestAccessForMediaType(AVMediaType.Video, (accessGranted) => 
				{
					imagePicker = new UIImagePickerController();
					imagePicker.PrefersStatusBarHidden();
					imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;

					//Add event handlers when user finished Capturing image or Cancel
					imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
					imagePicker.Canceled += Handle_Canceled;

					//present 
					PresentViewController(imagePicker, true, () => { });
				});
			}));

			galleryBtn = new FAButton(FontAwesome.FAClipboard, UIColor.Blue, 20)
			{
				Frame = new RectangleF((float)(((this.View.Frame.Width/2)/2)*3)-10, 0, 30, 30)		
			};


			galleryBtn.AddGestureRecognizer(new UITapGestureRecognizer(() =>
		   {

			   if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			   {

				   UIAlertController actionSheetAlert = UIAlertController.Create("Select Source", "", UIAlertControllerStyle.ActionSheet);

				   actionSheetAlert.AddAction(UIAlertAction.Create("Gallery", UIAlertActionStyle.Default, (action) =>

				   callActionSheet(1)
					   ));

				   actionSheetAlert.AddAction(UIAlertAction.Create("Camera", UIAlertActionStyle.Default, (action) =>

				   callActionSheet(2)
					   ));

				   actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

				   UIPopoverPresentationController presentationPopover = actionSheetAlert.PopoverPresentationController;
				   if (presentationPopover != null)
				   {
					   presentationPopover.SourceView = this.View;

					   presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
				   }

				   this.PresentViewController(actionSheetAlert, true, null);
			   }
			   else
			   {
				   string[] sd = new string[] { "Gallery", "Camera" };
				   UIActionSheet sheet = new UIActionSheet("Select Source", null, "Cancel", null, sd);
				   sheet.ShowInView(this.View);
				   sheet.Clicked += (object sender, UIButtonEventArgs e) =>
				   {
					   if (e.ButtonIndex == 0)
					   {
						   callActionSheet(1);
					   }
					   else if (e.ButtonIndex == 1)
					   {
						   callActionSheet(2);
					   }
				   };

				}

		   }));










			UIView CameraView = new UIView(new CGRect(0, this.View.Frame.Height - 100, this.View.Frame.Width, 100));
			CameraView.BackgroundColor = UIColor.White;
			CollectionView.AddSubview(CameraView);
			CameraView.AddSubview(cameraBtn);
			CameraView.AddSubview(galleryBtn);
		}

		private int i = 0;
		void Tick(object state)
		{
			
            this.BeginInvokeOnMainThread(() =>
			{
			if (i == 0)
			{
					var b = galleryBtn.ContentEdgeInsets;
					b.Right = b.Right + 2;
					b.Bottom = b.Bottom + 2;
					galleryBtn.ContentEdgeInsets = b;
					
					var a = cameraBtn.ContentEdgeInsets;
					a.Right = a.Right + 2;
					a.Bottom = a.Bottom + 2;
					cameraBtn.ContentEdgeInsets = a;
					i = 1;
			}
			else
			{
					var b = galleryBtn.ContentEdgeInsets;
					b.Right = b.Right -2;
					b.Bottom = b.Bottom - 2;
					galleryBtn.ContentEdgeInsets = b;
					
					var a = cameraBtn.ContentEdgeInsets;
				a.Right = a.Right - 2;
				a.Bottom = a.Bottom - 2;
					cameraBtn.ContentEdgeInsets = a;
				i = 0;
			}
			});

		}

		protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
{
// determine what was selected, video or image
bool isImage = false;
switch (e.Info[UIImagePickerController.MediaType].ToString())
{
case "public.image":
Console.WriteLine("Image selected");
isImage = true;
break;
case "public.video":
Console.WriteLine("Video selected");
break;
}

// get common info (shared between images and video)
NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
if (referenceURL != null)
Console.WriteLine("Url:" + referenceURL.ToString());

// if it was an image, get the other image info
if (isImage)
{
// get the original image
UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
if (originalImage != null)
{
// do something with the image
Console.WriteLine("got the original image");
//imageView.Image = originalImage; // display
}
}
else
{ // if it's a video
  // get video url
NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
if (mediaURL != null)
{
Console.WriteLine(mediaURL.ToString());
}
}
// dismiss the picker
//imagePicker.DismissModalViewControllerAnimated(true);
}

void Handle_Canceled(object sender, EventArgs e)
{
//	imagePicker.DismissModalViewControllerAnimated(true);
}

		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return MAX_COUNT;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.DequeueReusableCell(APLCollectionViewCell.Key, indexPath) as APLCollectionViewCell;
#if NO_IMAGES
			float hue = indexPath.Item / (float) MAX_COUNT;
			UIColor cellColor = UIColor.FromHSB (hue, 1.0f, 1.0f);
			cell.ContentView.BackgroundColor = cellColor;
#else
			cell.ImageView.Image = UIImage.FromFile("Images/sa" + indexPath.Item + ".jpg");
#endif

			list.Add(cell.ImageView.Image);

			return cell;
		}

		public override UICollectionViewTransitionLayout TransitionLayout(UICollectionView collectionView, UICollectionViewLayout fromLayout, UICollectionViewLayout toLayout)
		{
			return new APLTransitionLayout(fromLayout, toLayout);
		}

		public virtual UICollectionViewController NextViewControllerAtPoint(CGPoint p)
		{
			return null;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			//base.ItemSelected(collectionView, indexPath);
			//var a = collectionView as List<APLCollectionViewCell>
			//var Image = list[indexPath.Row];
			//send to next page
			this.NavigationController.PushViewController(new ImageViewController(list,indexPath.Row),true);
			

		}
	}

}
