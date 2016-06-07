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
	public partial class PassDetailViewController : UIViewController
	{
		public EmployeeElectronicPass SelectedPass { get; set; }

		public PassDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			lbApplyId.Text = SelectedPass.ProcessId;
			lbEmployeeName.Text = AppDelegate.AppUser.Name ;
			ibPassId.Text = SelectedPass.ElectronicPassId;
			lbEMDId.Text = SelectedPass.EMDId;

			var source = new PassDetailTableSource(SelectedPass.Tickets);
			passTable.Source = source ;

		}

		public class PassDetailTableSource : UITableViewSource
		{

			string PassDetailCellViewIdentifier = "PassDetailCellView";

			List<Ticket> Tickets { get; set;}

			public PassDetailTableSource (List<Ticket> tickets){

				Tickets = new List<Ticket>();
				Tickets.ClearThenAddRange( tickets );

			}

			public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
			{
				return (nfloat)80.0;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return Tickets.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				PassDetailCellView cell = tableView.DequeueReusableCell (PassDetailCellViewIdentifier) as PassDetailCellView;

				// Data
				var ticket = Tickets[indexPath.Row];

				cell.UploadTicket (ticket);

				return cell;

			}

			public event EventHandler<TicketSelectedEventArgs> TicketSelected;

			public virtual void OnTicketSelected(TicketSelectedEventArgs e){
				EventHandler<TicketSelectedEventArgs> handler = TicketSelected;

				if (null != handler) {
					handler( this, e);
				}

			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow (indexPath, true);

				OnTicketSelected ( new TicketSelectedEventArgs{ SelectedTicket = Tickets[indexPath.Row] });
			}

			public class TicketSelectedEventArgs : EventArgs{
				public Ticket SelectedTicket { get; set;}
			}

		}
	}
}
