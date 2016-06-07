using System;
using System.Linq;
using System.Collections.Generic;

using UIKit;
using Foundation ;

using Debug = System.Diagnostics.Debug ;

namespace EmployeePass.iOS
{
	public partial class RouteViewController : UIViewController
	{
		public Route SelectedRoute { get; set; }

		public RouteViewController (IntPtr handle) : base (handle)
		{
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var source = new TableSource (SelectedRoute.Flights);

			routeTable.Source = source;

			source.FlightSelected += (object sender, FlightSelectedEventArgs e) => {
				
			};
		}


		public class TableSource : UITableViewSource {

			const string FlightCellViewIdentifier = @"FlightCellView";

			public List<Flight> Source{ get; set;} 

			public TableSource(List<Flight> list){

				Source = new List<Flight>();
				Source.AddRange(list);
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return Source.Count ;
			}

			public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (FlightCellViewIdentifier) as FlightCellView;

				var flight = Source [indexPath.Row];

				cell.UpdateUIWith (flight);

				return cell;

			}

			// 
			public event EventHandler<FlightSelectedEventArgs> FlightSelected ;

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				var flight = Source [indexPath.Row];

				tableView.DeselectRow (indexPath, true);

				// Raise Event

				EventHandler<FlightSelectedEventArgs> handle = FlightSelected;

				if (null != handle) {

					var args = new FlightSelectedEventArgs { SelectedFlight = flight };

					handle (this, args);
				}

			}
		}

		public class FlightSelectedEventArgs : EventArgs {

			public Flight SelectedFlight { get; set;}
		}

	}
}
