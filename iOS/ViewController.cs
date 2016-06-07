using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;		

using UIKit;

using Debug = System.Diagnostics.Debug ;

namespace EmployeePass.iOS
{
	public partial class ViewController : UIViewController
	{
		
		public ViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			imageView.Image = UIImage.FromFile("Images/splash_logo.png");

			Task.Run (()=>{

				Thread.Sleep( 1000 );

				InvokeOnMainThread(()=>{
					PerformSegue("moveToLoginViewSegue", this);
				});



			});


		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}


	}
}
