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
	[Register ("QueryViewController")]
	partial class QueryViewController
	{
		[Outlet]
		UIKit.UIButton btnAirport { get; set; }

		[Outlet]
		UIKit.UIButton endAirport { get; set; }

		[Outlet]
		UIKit.UIButton endRegion { get; set; }

		[Outlet]
		UIKit.UIPickerView pickerView { get; set; }

		[Outlet]
		UIKit.UIButton startAirport { get; set; }

		[Outlet]
		UIKit.UIButton startRegion { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (pickerView != null) {
				pickerView.Dispose ();
				pickerView = null;
			}

			if (btnAirport != null) {
				btnAirport.Dispose ();
				btnAirport = null;
			}

			if (endAirport != null) {
				endAirport.Dispose ();
				endAirport = null;
			}

			if (endRegion != null) {
				endRegion.Dispose ();
				endRegion = null;
			}

			if (startAirport != null) {
				startAirport.Dispose ();
				startAirport = null;
			}

			if (startRegion != null) {
				startRegion.Dispose ();
				startRegion = null;
			}
		}
	}
}
