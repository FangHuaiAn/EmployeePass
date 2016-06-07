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
	[Register ("CheckInfoViewController")]
	partial class CheckInfoViewController
	{
		[Outlet]
		UIKit.UILabel lbEndAirport { get; set; }

		[Outlet]
		UIKit.UILabel lbStartAirport { get; set; }

		[Outlet]
		UIKit.UILabel lbStartTerminalEnglish { get; set; }

		[Outlet]
		UIKit.UILabel lbStartTerminalName { get; set; }

		[Outlet]
		UIKit.UILabel lbStartTerminalNote { get; set; }

		[Outlet]
		UIKit.UILabel lbStartTerminalPhone { get; set; }

		[Outlet]
		UIKit.UILabel lbStartTerminalWeb { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbStartAirport != null) {
				lbStartAirport.Dispose ();
				lbStartAirport = null;
			}

			if (lbStartTerminalName != null) {
				lbStartTerminalName.Dispose ();
				lbStartTerminalName = null;
			}

			if (lbStartTerminalEnglish != null) {
				lbStartTerminalEnglish.Dispose ();
				lbStartTerminalEnglish = null;
			}

			if (lbEndAirport != null) {
				lbEndAirport.Dispose ();
				lbEndAirport = null;
			}

			if (lbStartTerminalNote != null) {
				lbStartTerminalNote.Dispose ();
				lbStartTerminalNote = null;
			}

			if (lbStartTerminalPhone != null) {
				lbStartTerminalPhone.Dispose ();
				lbStartTerminalPhone = null;
			}

			if (lbStartTerminalWeb != null) {
				lbStartTerminalWeb.Dispose ();
				lbStartTerminalWeb = null;
			}
		}
	}
}
