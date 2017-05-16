using System;
using System.Collections.Generic;
using CoreGraphics;
using CoreLocation;
using FontAwesomeXamarin;
using Foundation;
using UIKit;

namespace PicTalk.iOS
{
	public partial class DashBoardController : UIViewController
	{
public List<MoviesModelResponse> list = new List<MoviesModelResponse>();
		public DashBoardController() : base("DashBoardController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.Title = "PICK TAXI";
			NavigationItem.RightBarButtonItem = new FABarButtonItem(FontAwesome.FACamera, UIColor.Blue, delegate
			{
				//Click event handler
			});
			movieTableView.RegisterNibForCellReuse(UINib.FromName("movieTableCell", null), "movieTableCell");
			list = PopulateMovies();
			var movieSource = new MoviesSource(this);
			movieTableView.Source = movieSource;
			UIView NewsView = new UIView(new CGRect(0, this.View.Frame.Height+20 , this.View.Frame.Width, 50));
			NewsView.BackgroundColor = UIColor.Blue;
			UILabel label = new UILabel(new CGRect(0,0,this.View.Frame.Width,50));
			label.LayoutMargins = new UIEdgeInsets(0, 20, 0, 0);
			label.Text = "Bahubali 2 gets 15000 reactions. La La Land gets 3600 reactions.";
			label.TextColor = UIColor.White;
			label.MinimumFontSize = 20;
			label.LineBreakMode = UILineBreakMode.WordWrap;
			NewsView.AddSubview(label);
			View.AddSubview(NewsView);


			//UIAlertView control = new UIAlertView("Location", "Please Enable Location.", new UIAlertViewDelegate()
			//{
				
			//}, "Not Now", null);
			//control.Show();
			//control.Clicked += (sender, e) =>
			//{
				
			//};				


			var locationManager = new CLLocationManager();
			//locationManager.r
			locationManager.RequestAlwaysAuthorization(); //to access user's location in the background
            locationManager.RequestWhenInUseAuthorization(); //to access user's location when the app is in use.
            locationManager.DistanceFilter =CLLocationDistance.FilterNone  ;
            locationManager.DesiredAccuracy = CLLocation.AccuracyBest;
            //locationManager.RequestLocation();
            var a = locationManager.Location;

			if (a != null)
			{
				CLGeocoder cg = new CLGeocoder();
				cg.ReverseGeocodeLocation(a, (placemarks, error) =>
				{ 
					label.Text = placemarks[0].Locality.ToString();
				});

			}
			locationManager.LocationsUpdated += delegate (object sender, CLLocationsUpdatedEventArgs e)
            {

                foreach (CLLocation loc in e.Locations)
                {
                    //Console.WriteLine(loc.Coordinate.Latitude);
                    label.Text = (loc.Coordinate.Latitude + "  "+ loc.Coordinate.Latitude).ToString();
                }
            };

            locationManager.StartUpdatingLocation();

            if (CLLocationManager.LocationServicesEnabled)
            {
                locationManager.StartMonitoringSignificantLocationChanges();
            }
            else
            {
                Console.WriteLine("Location services not enabled, please enable this in your Settings");
            }

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		private List<MoviesModelResponse> PopulateMovies()
		{
			var moviesList = 
new List<MoviesModelResponse>
            {
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://orig03.deviantart.net/4386/f/2016/017/8/1/batman_vs_superman_icon_by_jeorgebgeorge-d9o9nwx.png",
                    Name = "Khaidi No 150",
                    Reactions = new List<Reaction>
                                {
                                    new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,01,11)
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://a316.phobos.apple.com/us/r30/Purple1/v4/8b/ec/20/8bec203c-b7d5-8214-8323-6b9f32d26788/mzl.ytvxhekz.512x512-75.png",
                    Name = "La La Land",
                    Reactions = new List<Reaction>
                                {
                                 new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2016,02,14)//La La Land 14/2/2016
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://is5.mzstatic.com/image/thumb/Purple111/v4/9d/f9/8d/9df98da9-da24-84ec-6544-89346c238be4/source/512x512bb.jpg",
                    Name = "The Ghazi Attack",
                    Reactions = new List<Reaction>
                                {
                                   new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,02,17)//17/02/2017
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://orig03.deviantart.net/4386/f/2016/017/8/1/batman_vs_superman_icon_by_jeorgebgeorge-d9o9nwx.png",
                    Name = " Fast & Furious 8",
                    Reactions = new List<Reaction>
                                {
                                    new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,04,14)//14/4/2017
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://a316.phobos.apple.com/us/r30/Purple1/v4/8b/ec/20/8bec203c-b7d5-8214-8323-6b9f32d26788/mzl.ytvxhekz.512x512-75.png",
                    Name = "Bahubali 2 The conclusion",
                    Reactions = new List<Reaction>
                                {
                         new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,04,28)// 28/04/2017
                   
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://is5.mzstatic.com/image/thumb/Purple111/v4/9d/f9/8d/9df98da9-da24-84ec-6544-89346c238be4/source/512x512bb.jpg",
                    Name = " Half Girlfriend",
                    Reactions = new List<Reaction>
                                {
                                new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,05,19)//19/05/2017
                           
       
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://orig03.deviantart.net/4386/f/2016/017/8/1/batman_vs_superman_icon_by_jeorgebgeorge-d9o9nwx.png",
                    Name = "Jagga Jasoos",
                    Reactions = new List<Reaction>
                                {
                                  new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,07,14)//14/7/2017
                },
             
            };
			return moviesList;

		}
	}
public class MoviesModelResponse
{
	public int ID { get; set; }
	public string Logo { get; set; }
	public string Name { get; set; }
		public string Icon { get; set; }
	public System.DateTime Release { get; set; }
	public List<Reaction> Reactions { get; set; }
}
public class Reaction
{
	public string Tag { get; set; }
	public string Image { get; set; }
	public int UID { get; set; }
	public int MovieID { get; set; }

}

	public class MoviesSource : UITableViewSource
	{
		private DashBoardController _controller;
		public MoviesSource(DashBoardController controller)
		{
			_controller = controller;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cellMovie = tableView.DequeueReusableCell(movieTableCell.Key) as movieTableCell;
				
			cellMovie.BindData(_controller.list[indexPath.Row]);
			return cellMovie;
		}
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 75f;
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _controller.list.Count;

		}
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			UICollectionViewFlowLayout grid = new UICollectionViewFlowLayout()
			{
				ItemSize = new CGSize(75.0f, 75.0f),
				SectionInset = new UIEdgeInsets(10.0f, 10.0f, 10.0f, 10.0f)
			};

			_controller.NavigationController.PushViewController(new GalleryController(grid), true);
			//_controller.NavigationController.PushViewController(new Controller(), false);
}
	
	}


}

