
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EmployeePass.Droid
{
	[Activity (Label = "機場報到資訊", Theme = "@style/MyTheme")]			
	public class QueryRouteCheckInfoActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			string text = Intent.GetStringExtra ("route") ;

			var route = Newtonsoft.Json.JsonConvert.DeserializeObject<Route> (text);

			SetContentView ( Resource.Layout.queryroutecheckinfo );

			var lbStartAirportName = FindViewById<TextView> (Resource.Id.queryroutecheckinfoview_lbStartAirportName);
			lbStartAirportName.Text = string.Format (@"{0}  - {1}", route.StartAirport.Name, route.StartAirport.IATA_Code);

			var lbterminal = FindViewById<TextView> (Resource.Id.queryroutecheckinfoview_lbterminal);
			lbterminal.Text = route.StartTerminal.Name ;

			var lbterminalEnglishName = FindViewById<TextView> (Resource.Id.queryroutecheckinfoview_lbterminalenglishname);
			lbterminalEnglishName.Text = route.StartTerminal.EnglishName ;

			var lbEndAirportName = FindViewById<TextView> (Resource.Id.queryroutecheckinfoview_lbEndAirportName);
			lbEndAirportName.Text = string.Format (@"{0}  - {1}", route.StopAirport.Name, route.StopAirport.IATA_Code);


			// queryroutecheckinfoview_lbnote
			FindViewById<TextView> (Resource.Id.queryroutecheckinfoview_lbnote).Text = route.StartTerminal.Note ;
			// queryroutecheckinfoview_lbphone
			FindViewById<TextView> (Resource.Id.queryroutecheckinfoview_lbphone).Text = route.StartTerminal.Phone ;
			// queryroutecheckinfoview_lbwebsite
			FindViewById<TextView> (Resource.Id.queryroutecheckinfoview_lbwebsite).Text = route.StartTerminal.Web ;

		}
	}
}

