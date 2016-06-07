
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
	[Activity (Label = "航線資訊", Theme = "@style/MyTheme")]			
	public class QueryRouteResultActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.queryrouteresultview);

			string text = Intent.GetStringExtra ("route") ;
			var route = Newtonsoft.Json.JsonConvert.DeserializeObject<Route> (text);

			var listView = FindViewById<ListView> (Resource.Id.queryroutresultview_listview);
			listView.Adapter = new FlightListAdapter (this, route.Flights);


		}

		class FlightListAdapter : BaseAdapter<Flight>{

			List<Flight> items;

			Activity context;

			public FlightListAdapter(Activity context, List<Flight> items)
				: base()
			{
				this.context = context;
				this.items = new List<Flight>( items );
			}
			public override long GetItemId(int position)
			{
				return position;
			}
			public override Flight this[int position]
			{
				get { return items[position]; }
			}
			public override int Count
			{
				get { return items.Count; }
			}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				var item = items[position];
				var view = convertView;
				if (view == null)
				{
					//使用自訂的UserListItemLayout
					view = context.LayoutInflater.Inflate(Resource.Layout.passdetailitemview, null);
				}

				view.FindViewById<TextView> (Resource.Id.passdetailitemview_lbroute).Text = item.Id;
				view.FindViewById<TextView>(Resource.Id.passdetailitemview_lbclassname).Text = item.FlightRoute.StartAirport.Name;
				view.FindViewById<TextView>(Resource.Id.passdetailitemview_lbdate).Text =  item.FlightRoute.StopAirport.Name;


				return view;
			}


		}
	}
}

