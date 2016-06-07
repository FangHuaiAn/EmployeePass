
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

using Debug = System.Diagnostics.Debug ;

namespace EmployeePass.Droid
{
	[Activity (Label = "電子票詳細資料", Theme = "@style/MyTheme")]			
	public class PassDetailActivity : Activity
	{

		private EmployeeElectronicPass SelectedPass { get; set; }

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView( Resource.Layout.passdetailview );

			string text = Intent.GetStringExtra ("pass") ;
			SelectedPass = Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeeElectronicPass> (text);

			var lbName = FindViewById<TextView> (Resource.Id.passdetailview_lbname);
			var lbProcessId = FindViewById<TextView> (Resource.Id.passdetailview_lbprocessid);
			var lbPassId = FindViewById<TextView> (Resource.Id.passdetailview_lbpassid);
			var lbEMDId = FindViewById<TextView> (Resource.Id.passdetailview_lbemdid);

			lbName.Text = UniversalApplication.AppUser.Name;
			lbPassId.Text = SelectedPass.ElectronicPassId ;
			lbProcessId.Text = SelectedPass.ProcessId;
			lbEMDId.Text = SelectedPass.EMDId;

			var listPass = FindViewById<ListView> (Resource.Id.passdetailview_listpass);
			var adapter = new FlightListAdapter(this,SelectedPass.Tickets);
			listPass.Adapter = adapter ;

			listPass.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {

				var ticket = SelectedPass.Tickets[ e.Position ];

				Debug.WriteLine( $"{ticket.TicketFlight.FlightRoute.StartAirport.Name}-{ticket.TicketFlight.FlightRoute.StopAirport.Name}");
			};

		}

		class FlightListAdapter : BaseAdapter<Ticket>{

			List<Ticket> items;

			Activity context;

			public FlightListAdapter(Activity context, List<Ticket> items)
				: base()
			{
				this.context = context;
				this.items = new List<Ticket>( items );
			}
			public override long GetItemId(int position)
			{
				return position;
			}
			public override Ticket this[int position]
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

				view.FindViewById<TextView>(Resource.Id.passdetailitemview_lbroute).Text = $"{item.TicketFlight.FlightRoute.StartAirport.IATA_Code} - {item.TicketFlight.FlightRoute.StopAirport.IATA_Code}";
				view.FindViewById<TextView>(Resource.Id.passdetailitemview_lbclassname).Text = item.ClassName;
				view.FindViewById<TextView>(Resource.Id.passdetailitemview_lbdate).Text = item.StartDate.ToString ("d");


				return view;
			}


		}
	}
}

