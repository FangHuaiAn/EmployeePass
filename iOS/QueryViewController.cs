using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Foundation;
using UIKit;

using Debug = System.Diagnostics.Debug ;

namespace EmployeePass.iOS
{
	public partial class QueryViewController : UIViewController
	{
		public string NextSegueName { get; set; }

		FlightInfoManager FlightManager { get; set; }
		List<Route> SelectedRoutes { get; set; } 
		List<string> AirportsNameInStartRegion { get; set; }
		string SelectedStartAirport { get; set; }
		List<Region> StopRegions { get; set; }
		string _startAirportName ;
		Region _selectedRegion ;
		List<string> AirportsNameInStopRegion { get; set; }

		Route FinalRoute { get; set; } 

		RoutePickerViewModel CurrentModel { get; set; }

		public QueryViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//
			SelectedRoutes = new List<Route> ();
			AirportsNameInStartRegion = new List<string> ();
			StopRegions = new List<Region> ();
			AirportsNameInStopRegion = new List<string> ();

			//
			FlightManager = new FlightInfoManager();
			var routes = FlightManager.ReadRouteFromRemote ();

			//
			var regions = FlightManager.ReadRegions () ;
			Region seletedRegin = Region.NorthAmerica ;

			var airportList = routes.Where(route => route.StartAirport.GeoRegion == seletedRegin  ).ToList() ;
			AirportsNameInStartRegion.ClearThenAddRange( airportList.Select(r => r.StartAirport.Name ).Distinct().ToList() );
			_startAirportName = AirportsNameInStartRegion[0];

			startRegion.SetTitle (regions [0], UIControlState.Normal);
			startAirport.SetTitle( _startAirportName, UIControlState.Normal );

			CurrentModel = new RoutePickerViewModel (regions);
			pickerView.Model = CurrentModel ;
			CurrentModel.RowSelected += (object picker, RowSelectedEventArgs args) => {
				InvokeOnMainThread(()=>{
					pickerView.Hidden = true;
					btnAirport.Hidden = false ;
				});
			};

			// 

			startRegion.TouchUpInside += (object sender, EventArgs e) => {

				CurrentModel = new RoutePickerViewModel (FlightManager.ReadRegions ());
				pickerView.Model = CurrentModel ;
				CurrentModel.RowSelected += (object picker, RowSelectedEventArgs args) => {

					seletedRegin = (Region) args.SelectedIndex ;

					var list = routes.Where(route => route.StartAirport.GeoRegion == seletedRegin  ).ToList() ;
					AirportsNameInStartRegion.ClearThenAddRange( list.Select(r => r.StartAirport.Name ).Distinct().ToList() );


					_startAirportName = AirportsNameInStartRegion[0];

					InvokeOnMainThread(()=>{
						pickerView.Hidden = true;
						btnAirport.Hidden = false ;

						startRegion.SetTitle( args.SelectedTitle, UIControlState.Normal );
						startAirport.SetTitle( _startAirportName, UIControlState.Normal );
						//

					});
				};

				InvokeOnMainThread(()=>{
					pickerView.Hidden = false;
					btnAirport.Hidden = true ;
				});
					
			};

			startAirport.TouchUpInside += (object sender, EventArgs e) => {

				var list = routes.Where(route => route.StartAirport.GeoRegion == seletedRegin  ).ToList() ;
				AirportsNameInStartRegion.ClearThenAddRange( list.Select(r => r.StartAirport.Name ).Distinct().ToList() );
				//



				//
				CurrentModel = new RoutePickerViewModel (AirportsNameInStartRegion);
				pickerView.Model = CurrentModel ;
				CurrentModel.RowSelected += (object picker, RowSelectedEventArgs args) => {

					// Default Stop Region
					_startAirportName = args.SelectedTitle ;
					SelectedRoutes.ClearThenAddRange( routes.Where( r => r.StartAirport.Name == _startAirportName ).ToList() );
					StopRegions.ClearThenAddRange( SelectedRoutes.Select( r => r.StopAirport.GeoRegion  ).Distinct().ToList() );

					var stopRegionNameList = new List<string>();

					foreach(var region in StopRegions){
						stopRegionNameList.Add(region.ToString() );
					}
					var _selectedRegionName = stopRegionNameList[0] ;
					_selectedRegion = StopRegions[0];
					// Default Stop Airport
					var temp = routes.Where( r => r.StartAirport.Name == _startAirportName && r.StopAirport.GeoRegion == _selectedRegion ).ToList() ;
					AirportsNameInStopRegion.ClearThenAddRange( temp.Select( r => r.StopAirport.Name ).Distinct().ToList());



					InvokeOnMainThread(()=>{
						pickerView.Hidden = true;
						btnAirport.Hidden = false ;

						startAirport.SetTitle( args.SelectedTitle, UIControlState.Normal );
						endRegion.SetTitle ( _selectedRegionName, UIControlState.Normal );
						endAirport.SetTitle ( AirportsNameInStopRegion[0], UIControlState.Normal );
					});
				};

				InvokeOnMainThread(()=>{
					pickerView.Hidden = false;
					btnAirport.Hidden = true ;
				});
			};

			endRegion.TouchUpInside += (object sender, EventArgs e) => {

				SelectedRoutes.ClearThenAddRange( routes.Where( r => r.StartAirport.Name == _startAirportName ).ToList() );

				StopRegions.ClearThenAddRange( SelectedRoutes.Select( r => r.StopAirport.GeoRegion  ).Distinct().ToList() );

				var stopReionNameList = new List<string>();

				foreach(var region in StopRegions){
					stopReionNameList.Add(region.ToString() );
				}

				CurrentModel = new RoutePickerViewModel (stopReionNameList);
				pickerView.Model = CurrentModel ;
				CurrentModel.RowSelected += (object picker, RowSelectedEventArgs args) => {
					_selectedRegion = StopRegions[args.SelectedIndex];

					var temp = routes.Where( r => r.StartAirport.Name == _startAirportName && r.StopAirport.GeoRegion == _selectedRegion ).ToList() ;

					AirportsNameInStopRegion.ClearThenAddRange( temp.Select( r => r.StopAirport.Name ).Distinct().ToList());

					if( AirportsNameInStopRegion.Count == 1){
						var list = routes.Where( r => r.StartAirport.Name == _startAirportName && r.StopAirport.GeoRegion == _selectedRegion && r.StopAirport.Name == AirportsNameInStopRegion[0] ).ToList() ;

						if( 1 == list.Count ){
							FinalRoute = list[0] ;
						}

					}

					// Default Stop Airport
					InvokeOnMainThread(()=>{
						pickerView.Hidden = true;
						btnAirport.Hidden = false ;

						endRegion.SetTitle ( args.SelectedTitle, UIControlState.Normal );
						endAirport.SetTitle ( AirportsNameInStopRegion[0], UIControlState.Normal );
					});

				};

				InvokeOnMainThread(()=>{
					pickerView.Hidden = false;
					btnAirport.Hidden = true ;

				});
			};

			endAirport.TouchUpInside += (object sender, EventArgs e) => {


				var temp = routes.Where( r => r.StartAirport.Name == _startAirportName && r.StopAirport.GeoRegion == _selectedRegion ).ToList() ;

				AirportsNameInStopRegion.ClearThenAddRange( temp.Select( r => r.StopAirport.Name ).Distinct().ToList());


				CurrentModel = new RoutePickerViewModel (AirportsNameInStopRegion);
				pickerView.Model = CurrentModel ;
				CurrentModel.RowSelected += (object picker, RowSelectedEventArgs args) => {

					endAirport.SetTitle ( args.SelectedTitle, UIControlState.Normal );

					var list = routes.Where( r => r.StartAirport.Name == _startAirportName && r.StopAirport.GeoRegion == _selectedRegion && r.StopAirport.Name == args.SelectedTitle ).ToList() ;

					if( 1 == list.Count ){
						FinalRoute = list[0] ;
					}

				};


			};

			btnAirport.TouchUpInside += (object sender, EventArgs e) => {

				if( null != FinalRoute ){
					PerformSegue( NextSegueName, this );
				}
			};

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			FinalRoute.Flights = new FlightInfoManager ().ReadFlightByRouteId (FinalRoute.Id);

			switch (segue.Identifier) {
			case @"moveToFlightListViewSegue":
				{
					if (segue.DestinationViewController is RouteViewController) {
						var destinationViewController = segue.DestinationViewController as RouteViewController;
						destinationViewController.SelectedRoute = FinalRoute;
					}
				}
				break;
			case @"moveToCheckInfoViewSegue":
				{
					if (segue.DestinationViewController is CheckInfoViewController) {
						var destinationViewController = segue.DestinationViewController as CheckInfoViewController;
						destinationViewController.SelectedRoute = FinalRoute;
					}
				}
				break;
			}

		}


		public class RoutePickerViewModel : UIPickerViewModel {

			public List<string> Titles { get; set; }

			public RoutePickerViewModel(List<string> titles){
				Titles = new List<string>( titles );
			}

			public override nint GetRowsInComponent (UIPickerView pickerView, nint component)
			{
				return Titles.Count;
			}

			public override string GetTitle (UIPickerView pickerView, nint row, nint component)
			{
				return Titles[(int)row];
			}

			public override nint GetComponentCount (UIPickerView pickerView)
			{
				return 1;
			}

			public event EventHandler<RowSelectedEventArgs> RowSelected;

			public override void Selected (UIPickerView pickerView, nint row, nint component)
			{
				EventHandler<RowSelectedEventArgs> handle = RowSelected;

				if (null != handle) {
					var args = new RowSelectedEventArgs{ SelectedIndex = (int)row, SelectedTitle = Titles[(int)row]  };
					handle (this, args);
				}
			}



		}

		public class RowSelectedEventArgs : EventArgs{
			public string SelectedTitle { get; set;}
			public int SelectedIndex { get; set;}
		}
	}
}
