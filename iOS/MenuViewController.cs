// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Drawing;

using UIKit;
using Foundation;
using CoreGraphics;

using Debug = System.Diagnostics.Debug ;

namespace EmployeePass.iOS
{
	public partial class MenuViewController : UIViewController
	{

		private string NextSegueName { get; set; }

		public MenuViewController (IntPtr handle) : base (handle)
		{
		}

		// moveToQueryViewSegue
		// moveToPassViewSegue
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnQueryFlight.TouchUpInside += (object sender, EventArgs e) => {
				NextSegueName = @"moveToFlightListViewSegue";
				PerformSegue("moveToQueryViewSegue", this);
			};

			btnQueryPassRecord.TouchUpInside += (object sender, EventArgs e) => {
				PerformSegue("moveToPassViewSegue", this);
			};

			btnQueryAirportCheckInfo.TouchUpInside += (object sender, EventArgs e) => {
				NextSegueName = @"moveToCheckInfoViewSegue";
				PerformSegue("moveToQueryViewSegue", this);
			};
		}

		// moveToQueryViewSegue
		// 		moveToFlightListViewSegue
		// 		moveToCheckInfoViewSegue
		// moveToPassViewSegue
		// 
		// 

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			switch (segue.Identifier) {
			case @"moveToQueryViewSegue":
				{
					if (segue.DestinationViewController is QueryViewController) {
						var destinationViewController = segue.DestinationViewController as QueryViewController;
						destinationViewController.NextSegueName = NextSegueName;
					}
				}
				break;
			case @"moveToPassViewSegue":
				{

				}
				break;
			}
		}

	}
}
