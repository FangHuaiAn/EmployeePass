using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;


namespace EmployeePass.Droid
{
	[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		static readonly string TAG = "EmployeePass:" + typeof(SplashActivity).Name;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			Task startupWork = new Task(() => {
				
				Task.Delay(5000);  // Simulate a bit of startup work.

			});

			startupWork.ContinueWith(t => {
				
				StartActivity(new Intent(Application.Context, typeof(LoginActivity)));

			}, TaskScheduler.FromCurrentSynchronizationContext());

			startupWork.Start();
		}
	}
}

