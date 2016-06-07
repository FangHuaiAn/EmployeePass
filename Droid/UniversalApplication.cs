using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;


namespace EmployeePass.Droid
{
	[Application]
	public class UniversalApplication : Android.App.Application
	{
		public static Employee AppUser {get;set;}
		
		public UniversalApplication(IntPtr handle, JniHandleOwnership transfer)
			: base(handle,transfer)
		{
			
		}

	}
}

