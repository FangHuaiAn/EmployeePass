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
	[Register ("MenuViewController")]
	partial class MenuViewController
	{
		[Outlet]
		UIKit.UIButton btnQueryAirportCheckInfo { get; set; }

		[Outlet]
		UIKit.UIButton btnQueryFlight { get; set; }

		[Outlet]
		UIKit.UIButton btnQueryPassRecord { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnQueryFlight != null) {
				btnQueryFlight.Dispose ();
				btnQueryFlight = null;
			}

			if (btnQueryAirportCheckInfo != null) {
				btnQueryAirportCheckInfo.Dispose ();
				btnQueryAirportCheckInfo = null;
			}

			if (btnQueryPassRecord != null) {
				btnQueryPassRecord.Dispose ();
				btnQueryPassRecord = null;
			}
		}
	}
}
