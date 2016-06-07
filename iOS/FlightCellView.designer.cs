// WARNING
//
// This file has been generated automatically by Xamarin Studio Community to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace EmployeePass.iOS
{
	[Register ("FlightCellView")]
	partial class FlightCellView
	{
		[Outlet]
		UIKit.UILabel lbFlightId { get; set; }

		[Outlet]
		UIKit.UILabel lbStartAirport { get; set; }

		[Outlet]
		UIKit.UILabel lbStopAirport { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbFlightId != null) {
				lbFlightId.Dispose ();
				lbFlightId = null;
			}

			if (lbStartAirport != null) {
				lbStartAirport.Dispose ();
				lbStartAirport = null;
			}

			if (lbStopAirport != null) {
				lbStopAirport.Dispose ();
				lbStopAirport = null;
			}
		}
	}
}
