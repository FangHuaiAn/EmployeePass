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
	[Register ("RouteViewController")]
	partial class RouteViewController
	{
		[Outlet]
		UIKit.UITableView routeTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (routeTable != null) {
				routeTable.Dispose ();
				routeTable = null;
			}
		}
	}
}
