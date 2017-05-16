using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using FontAwesomeXamarin;
using Foundation;
using UIKit;

namespace PicTalk.iOS
{
	public partial class movieTableCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("movieTableCell");
		public static readonly UINib Nib;

		 static movieTableCell()
		{
			Nib = UINib.FromName("movieTableCell", NSBundle.MainBundle);

		}

		protected movieTableCell(IntPtr handle) : base(handle)
		{
			var ScreenWidth = UIScreen.MainScreen.Bounds.Width -40 ;
			//var ScreenHeight = UIScreen.MainScreen.Bounds.Height -25;
			var deleteBtn = new FAButton(FontAwesome.FAPlusCircle, UIColor.Gray, 25)
			{
				Frame = new RectangleF(Convert.ToInt32(ScreenWidth),36, 30, 30)
			};
			Add(deleteBtn);

			// Note: this .ctor should not contain any initialization logic.
		}
		public async Task  BindData(MoviesModelResponse model)
		{

			movieNameLabel.Text = model.Name;
			movieTimeLabel.Text = model.Release.ToString("D");
			image1.Image = UIImage.FromBundle ("sa0.jpg");
			image2.Image =UIImage.FromBundle ("sa1.jpg");
			image3.Image =UIImage.FromBundle ("sa2.jpg");
			//PlusBtn = new FAButton(FontAwesome.FATrashO, UIColor.White, 20);
		}
		public async Task<UIImage> FromUrl(string Uri)
		{
			var httpClient = new HttpClient();
			Task<byte[]> contentTask = httpClient.GetByteArrayAsync(Uri);
			var content = await contentTask;

			return UIImage.LoadFromData(NSData.FromArray(content));
		}
	}
}
