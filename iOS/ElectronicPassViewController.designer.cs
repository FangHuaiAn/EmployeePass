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
	[Register ("ElectronicPassViewController")]
	partial class ElectronicPassViewController
	{
		[Outlet]
		UIKit.UIButton btnOther { get; set; }

		[Outlet]
		UIKit.UIButton btnUnused { get; set; }

		[Outlet]
		UIKit.UIButton btnUsed { get; set; }

		[Outlet]
		UIKit.UITableView passTable { get; set; }

		[Outlet]
		UIKit.UIView viewStatus { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnOther != null) {
				btnOther.Dispose ();
				btnOther = null;
			}

			if (btnUnused != null) {
				btnUnused.Dispose ();
				btnUnused = null;
			}

			if (btnUsed != null) {
				btnUsed.Dispose ();
				btnUsed = null;
			}

			if (passTable != null) {
				passTable.Dispose ();
				passTable = null;
			}

			if (viewStatus != null) {
				viewStatus.Dispose ();
				viewStatus = null;
			}
		}
	}
}
