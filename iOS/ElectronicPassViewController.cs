using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using UIKit;
using Foundation;

using Newtonsoft.Json;


using Debug = System.Diagnostics.Debug;

namespace EmployeePass.iOS
{
	public partial class ElectronicPassViewController : UIViewController
	{
		private List<EmployeeElectronicPass> SourcePass { get; set;}
		private List<EmployeeElectronicPass> DisplayPass { get; set;}
		private EmployeeElectronicPass SelectedPass { get; set;}

		public ElectronicPassViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//
			SourcePass = new List<EmployeeElectronicPass>();
			DisplayPass = new List<EmployeeElectronicPass> ();


			btnUsed.TouchUpInside += (object sender, EventArgs e) => {
				ReloadTableSource(PassStatus.Used);
			};

			btnUnused.TouchUpInside += (object sender, EventArgs e) => {
				ReloadTableSource(PassStatus.Unused);
			};

			btnOther.TouchUpInside += (object sender, EventArgs e) => {
				ReloadTableSource(PassStatus.Other);
			};


			//
			SourcePass.ClearThenAddRange( LoadPass () );
			ReloadTableSource(PassStatus.Used);



		}

		private void ReloadTableSource(PassStatus status){
			
			DisplayPass.ClearThenAddRange( SourcePass.Where( p => p.Status == status ).ToList() );

			var source = new PassTableSource(DisplayPass);

			passTable.Source = source ;

			source.PassSelected += delegate(object sender, PassTableSource.PassSelectedEventArgs e) {
				SelectedPass = e.SelectedPass ;

				InvokeOnMainThread (()=>{
					PerformSegue("moveToPassDetailViewSegue", this);

				});
			};


			InvokeOnMainThread (
				()=>{
					passTable.ReloadData();
				}
			);
		}

		private List<EmployeeElectronicPass> LoadPass(){

			var manager = new PassManager ();


			var list = manager.ReadPassRecordFromRemote ();

			return list;

		}


		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			if ("moveToPassDetailViewSegue" == segue.Identifier) {

				if (segue.DestinationViewController is PassDetailViewController) {
				
					var destViewController = segue.DestinationViewController as PassDetailViewController;
					destViewController.SelectedPass = SelectedPass;
				}
			
			}
		}

		public class PassTableSource : UITableViewSource
		{

			string PassCellViewIdentifier = "PassCellView";

			List<EmployeeElectronicPass> Passes { get; set;}

			public PassTableSource (List<EmployeeElectronicPass> passes){

				Passes = new List<EmployeeElectronicPass>();
				Passes.ClearThenAddRange( passes );

			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return Passes.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				PassCellView cell = tableView.DequeueReusableCell (PassCellViewIdentifier) as PassCellView;

				// Data
				var pass = Passes[indexPath.Row];

				cell.UploadPass (pass);

				return cell;

			}

			public event EventHandler<PassSelectedEventArgs> PassSelected;

			public virtual void OnPassSelected(PassSelectedEventArgs e){
				EventHandler<PassSelectedEventArgs> handler = PassSelected;

				if (null != handler) {
					handler( this, e);
				}

			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow (indexPath, true);

				OnPassSelected (new PassSelectedEventArgs {SelectedPass = Passes[indexPath.Row]});
			}

			public class PassSelectedEventArgs : EventArgs{
				public EmployeeElectronicPass SelectedPass { get; set;}
			}

		}
	}
}
