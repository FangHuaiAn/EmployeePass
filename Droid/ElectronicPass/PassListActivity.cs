using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;

namespace EmployeePass.Droid
{
	[Activity (Label = "電子票列表", Theme = "@style/MyTheme")]			
	public class PassListActivity : Activity
	{
		private List<EmployeeElectronicPass> SourcePass { get; set;}
		private List<EmployeeElectronicPass> DisplayPass { get; set;}

		ListView _listView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//
			SourcePass = new List<EmployeeElectronicPass>();
			DisplayPass = new List<EmployeeElectronicPass> ();

			// Create your application here
			SetContentView(Resource.Layout.passlistview);

			var btnUsed = FindViewById<Button> (Resource.Id.passlistview_btnUsed);
			btnUsed.Click += (object sender, EventArgs e) => {

				BindDataWithStatus(PassStatus.Used );

			};

			var btnUnused = FindViewById<Button> (Resource.Id.passlistview_btnUnused);
			btnUnused.Click += (object sender, EventArgs e) => {

				BindDataWithStatus(PassStatus.Unused );

			};

			var btnOther = FindViewById<Button> (Resource.Id.passlistview_btnOther);
			btnOther.Click += (object sender, EventArgs e) => {

				BindDataWithStatus(PassStatus.Other );

			};

			_listView = FindViewById<ListView> (Resource.Id.passlistview_listview);

			Task.Run (() => {

				SourcePass.ClearThenAddRange( LoadPass () );

				BindDataWithStatus(PassStatus.Used );

			}) ;

		}

		private void BindDataWithStatus(PassStatus status){
		
			RunOnUiThread (
				()=>{

					DisplayPass.ClearThenAddRange( SourcePass.Where( p => p.Status == status ).ToList() );

					var adapter = new PassListAdapter(this,DisplayPass);
					_listView.Adapter = adapter ;

					adapter.ElectronicPassSelected += delegate(object sender, PassListAdapter.ElectronicPassSelectedEventArgs e) {
						MoveToNextView(e.SelectedPass);
					};


				}
			);
		}



		private List<EmployeeElectronicPass> LoadPass(){

			var manager = new PassManager ();


			var list = manager.ReadPassRecordFromRemote ();

			return list;
			
		}

		private void MoveToNextView(EmployeeElectronicPass pass){
			
			var passString = Newtonsoft.Json.JsonConvert.SerializeObject( pass );

			RunOnUiThread (()=>{
				
				var detailView = new Intent (this, typeof(PassDetailActivity));
				detailView.PutExtra ("pass", passString);
				StartActivity (detailView);
			});



		}

		class PassListAdapter : BaseAdapter<EmployeeElectronicPass>{

			List<EmployeeElectronicPass> items;

			Activity context;

			public PassListAdapter(Activity context, IEnumerable<EmployeeElectronicPass> items)
				: base()
			{
				this.context = context;
				this.items = new List<EmployeeElectronicPass>( items );
			}
			public override long GetItemId(int position)
			{
				return position;
			}
			public override EmployeeElectronicPass this[int position]
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
					view = context.LayoutInflater.Inflate(Resource.Layout.passlistitemview, null);
				}

				view.FindViewById<TextView>(Resource.Id.passlistitemview_lbairports).Text = item.FlightsToString;
				view.FindViewById<TextView>(Resource.Id.passlistitemview_lbid).Text = $"Apply Id : {item.ProcessId}";
				view.FindViewById<TextView>(Resource.Id.passlistitemview_lbpassid).Text = $"Pass Id : { item.ElectronicPassId}";
				view.FindViewById<TextView>(Resource.Id.passlistitemview_lbdate).Text = item.AppliedDate.ToString("yyyy-MM-dd");

				Button btnMore = view.FindViewById<Button> (Resource.Id.passlistitemview_btnmore);
				btnMore.Click += (object sender, EventArgs e) => {
					EventHandler<ElectronicPassSelectedEventArgs> handle = ElectronicPassSelected ;

					if( null != handle ){
						handle( btnMore, new ElectronicPassSelectedEventArgs{SelectedPass = item });
					}
				};

				return view;
			}

			public event EventHandler<ElectronicPassSelectedEventArgs> ElectronicPassSelected ;

			public class ElectronicPassSelectedEventArgs : EventArgs {
				public EmployeeElectronicPass SelectedPass { get; set;}
			}
		}


	}
}

