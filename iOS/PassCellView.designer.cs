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
	[Register ("PassCellView")]
	partial class PassCellView
	{
		[Outlet]
		UIKit.UILabel lbApplyId { get; set; }

		[Outlet]
		UIKit.UILabel lbDate { get; set; }

		[Outlet]
		UIKit.UILabel lbPassId { get; set; }

		[Outlet]
		UIKit.UILabel lbRoute { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbApplyId != null) {
				lbApplyId.Dispose ();
				lbApplyId = null;
			}

			if (lbDate != null) {
				lbDate.Dispose ();
				lbDate = null;
			}

			if (lbPassId != null) {
				lbPassId.Dispose ();
				lbPassId = null;
			}

			if (lbRoute != null) {
				lbRoute.Dispose ();
				lbRoute = null;
			}
		}
	}
}
