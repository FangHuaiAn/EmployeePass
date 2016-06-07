using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;

namespace EmployeePass.Droid
{
	[Activity (Label = "員工票", Theme = "@style/MyTheme")]			
	public class MenuActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView( Resource.Layout.menuview );

			var btnQueryFlight = FindViewById<Button> (Resource.Id.menuview_btnQueryFlight);
			btnQueryFlight.Click += (object sender, EventArgs e) => {
				var queryRoute = new Intent(this, typeof( QueryRouteActivity ));
				queryRoute.PutExtra( @"feature", @"flight");
				StartActivity( queryRoute );
			};

			var btnQueryAirportCheckInfo = FindViewById<Button> (Resource.Id.menuview_btnQueryAirportCheckInfo);
			btnQueryAirportCheckInfo.Click += (object sender, EventArgs e) => {
				var queryRoute = new Intent(this, typeof( QueryRouteActivity ));
				queryRoute.PutExtra( @"feature", @"airport");
				StartActivity( queryRoute );
			};

			var btnQueryPassRecord = FindViewById<Button> (Resource.Id.menuview_btnQueryPassRecord);
			btnQueryPassRecord.Click += (object sender, EventArgs e) => {
				StartActivity(typeof(PassListActivity));
			};


		}
	}
}