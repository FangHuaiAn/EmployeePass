using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Debug = System.Diagnostics.Debug ;

namespace EmployeePass.Droid
{
	[Activity (Label = "查詢航線", Theme = "@style/MyTheme")]			
	public class QueryRouteActivity : Activity
	{
		FlightInfoManager FlightManager { get; set; }
		List<Route> SelectedRoutes { get; set; } 
		List<string> AirportsNameInStartRegion { get; set; }
		string SelectedStartAirport { get; set; }
		List<Region> StopRegions { get; set; }
		string _startAirportName ;
		Region _selectedRegion ;
		List<string> AirportsNameInStopRegion { get; set; }

		Route FinalRoute { get; set; } 

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.queryrouteview);

			var startRegion = FindViewById <Spinner>( Resource.Id.queryrouteview_startregion );
			var startAirport = FindViewById <Spinner>( Resource.Id.queryrouteview_startairport );
			var endRegion = FindViewById <Spinner>( Resource.Id.queryrouteview_endregion );
			var endAirport = FindViewById <Spinner>( Resource.Id.queryrouteview_endairport );

			var btnAirport = FindViewById <Button> ( Resource.Id.queryrouteview_btnairport);
			string text = Intent.GetStringExtra ("feature") ;

			int next = -1;
			if ("flight" == text) {
				next = 0;
				btnAirport.Text = "查詢航線資訊";
			} 
			else if ("airport" == text) {
				next = 1;
				btnAirport.Text = "查詢機場報到資訊";
			}
			else {
				btnAirport.Enabled = false;
			}


			btnAirport.Click += (object sender, EventArgs e) => {

				FinalRoute.Flights = new FlightInfoManager ().ReadFlightByRouteId (FinalRoute.Id);

				var routeString = Newtonsoft.Json.JsonConvert.SerializeObject( FinalRoute );

				if (0 == next) {


					RunOnUiThread (()=>{
						var detailView = new Intent (this, typeof(QueryRouteResultActivity));
						detailView.PutExtra ("route", routeString);
						StartActivity (detailView);
					});
				} 
				else if (1 == next) {

					RunOnUiThread (()=>{
						var detailView = new Intent (this, typeof(QueryRouteCheckInfoActivity));
						detailView.PutExtra ("route", routeString);
						StartActivity (detailView);
					});

				}


			};

			//
			SelectedRoutes = new List<Route> ();
			AirportsNameInStartRegion = new List<string> ();
			StopRegions = new List<Region> ();
			AirportsNameInStopRegion = new List<string> ();

			//
			FlightManager = new FlightInfoManager();
			var routes = FlightManager.ReadRouteFromRemote ();

			//

			startRegion.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, FlightManager.ReadRegions());

			startRegion.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {


				var list = routes.Where(route => route.StartAirport.GeoRegion == (Region)e.Position ).ToList() ;
				AirportsNameInStartRegion.ClearThenAddRange( list.Select(r => r.StartAirport.Name ).Distinct().ToList() );
				startAirport.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, AirportsNameInStartRegion );


			};


			startAirport.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {

				//
				_startAirportName = AirportsNameInStartRegion[e.Position];


				SelectedRoutes.ClearThenAddRange( routes.Where( r => r.StartAirport.Name == _startAirportName ).ToList() );

				StopRegions.ClearThenAddRange( SelectedRoutes.Select( r => r.StopAirport.GeoRegion  ).Distinct().ToList() );

				var list = new List<string>();

				foreach(var region in StopRegions){
					list.Add(region.ToString() );
				}

				endRegion.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, list ); 

			};

			endRegion.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {


				_selectedRegion = StopRegions[e.Position];

				var temp = routes.Where( r => r.StartAirport.Name == _startAirportName && r.StopAirport.GeoRegion == _selectedRegion ).ToList() ;

				AirportsNameInStopRegion.ClearThenAddRange( temp.Select( r => r.StopAirport.Name ).Distinct().ToList());

				endAirport.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, AirportsNameInStopRegion ); 



			};

			endAirport.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {

				var airportName = AirportsNameInStopRegion[e.Position];

				var list = routes.Where( r => r.StartAirport.Name == _startAirportName && r.StopAirport.GeoRegion == _selectedRegion && r.StopAirport.Name == airportName ).ToList() ;

				if( 1 == list.Count ){
					FinalRoute = list[0] ;
				}
			};
		}
	}
}

