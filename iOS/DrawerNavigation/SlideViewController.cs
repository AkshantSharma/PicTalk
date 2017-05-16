using System;
using System.Collections.Generic;
using System.Drawing;
using FontAwesomeXamarin;
using Foundation;
using UIKit;

namespace PicTalk.iOS
{
	public partial class SlideViewController : UIViewController
	{
		public SlideViewController() : base("SlideViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			
			base.ViewDidLoad();
			List<Menu> tableItems = new List<Menu>();

		//	table = new UITableView(View.Bounds); // defaults to Plain style
		//	table.AutoresizingMask = UIViewAutoresizing.All;

			//table.BackgroundColor = UIColor.FromRGB(105, 87, 93);

			//table.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			tableItems.Add(new Menu("Home") { ImageName = "home.png" });
			tableItems.Add(new Menu("My Reviews") { ImageName = "status.png" });
			tableItems.Add(new Menu("Settings") { ImageName = "Appointments.png" });
			tableItems.Add(new Menu("About Us") { ImageName = "Appointments.png" });

			table.Source = new TableSource(tableItems,this);
			table.ReloadData();

			//table.LayoutMargins = new UIEdgeInsets(0, 0, 0, 2);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
	public class Menu
	{
		public string Heading { get; set; }
		public string ImageName { get; set; }

		public Menu(string heading)
		{ Heading = heading; }

	}
	public class TableSource : UITableViewSource
	{
		private SlideViewController _controller;
		List<Menu> list = new List<Menu>();
		public TableSource(List<Menu> items,SlideViewController controller)
		{
			_controller = controller;
			list = items;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//base.RowSelected(tableView, indexPath);

			if(indexPath.Row == 2)
			_controller.NavigationController.PushViewController(new SetingsController(),true);

			if (indexPath.Row == 0)
			{
				_controller.NavigationController.PushViewController(new DashBoardController(),true);	
			}
		}


		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("TableCell");
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, "TableCell");

			}
			cell.TextLabel.Text = list[indexPath.Row].Heading.ToString();
			var ScreenWidth = UIScreen.MainScreen.Bounds.Width - 120;
			if (indexPath.Row == 0)
			{
				var deleteBtn = new FAButton(FontAwesome.FAHome, UIColor.Gray, 25)
				{
					Frame = new Rectangle(Convert.ToInt32(ScreenWidth)-20, 10, 30, 30)
						
				};
			cell.Add(deleteBtn);}
			if (indexPath.Row == 1)
			{
				var deleteBtn = new FAButton(FontAwesome.FAUsers, UIColor.Gray, 25)
				{
					Frame = new Rectangle(Convert.ToInt32(ScreenWidth) - 20, 10, 30, 30)

				};
				cell.Add(deleteBtn);}
			if (indexPath.Row == 2)
			{
				var deleteBtn = new FAButton(FontAwesome.FACogs, UIColor.Gray, 25)
				{
					Frame = new Rectangle(Convert.ToInt32(ScreenWidth)-20, 10, 30, 30)
				};
				cell.Add(deleteBtn);
			}if (indexPath.Row == 3)
			{
				var deleteBtn = new FAButton(FontAwesome.FAInfoCircle, UIColor.Gray, 25)
				{
					Frame = new Rectangle(Convert.ToInt32(ScreenWidth)-20, 10, 30, 30)
				};
				cell.Add(deleteBtn);
			}
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return list.Count;
		//	throw new NotImplementedException();
		}
	}
}

