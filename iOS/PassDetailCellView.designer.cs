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
	[Register ("PassDetailCellView")]
	partial class PassDetailCellView
	{
		[Outlet]
		UIKit.UILabel lbClass { get; set; }

		[Outlet]
		UIKit.UILabel lbDate { get; set; }

		[Outlet]
		UIKit.UILabel lbRoute { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbRoute != null) {
				lbRoute.Dispose ();
				lbRoute = null;
			}

			if (lbClass != null) {
				lbClass.Dispose ();
				lbClass = null;
			}

			if (lbDate != null) {
				lbDate.Dispose ();
				lbDate = null;
			}
		}
	}
}
