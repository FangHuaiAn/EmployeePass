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
	[Register ("PassDetailViewController")]
	partial class PassDetailViewController
	{
		[Outlet]
		UIKit.UILabel ibPassId { get; set; }

		[Outlet]
		UIKit.UILabel lbApplyId { get; set; }

		[Outlet]
		UIKit.UILabel lbEMDId { get; set; }

		[Outlet]
		UIKit.UILabel lbEmployeeName { get; set; }

		[Outlet]
		UIKit.UITableView passTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbEmployeeName != null) {
				lbEmployeeName.Dispose ();
				lbEmployeeName = null;
			}

			if (lbApplyId != null) {
				lbApplyId.Dispose ();
				lbApplyId = null;
			}

			if (ibPassId != null) {
				ibPassId.Dispose ();
				ibPassId = null;
			}

			if (lbEMDId != null) {
				lbEMDId.Dispose ();
				lbEMDId = null;
			}

			if (passTable != null) {
				passTable.Dispose ();
				passTable = null;
			}
		}
	}
}
