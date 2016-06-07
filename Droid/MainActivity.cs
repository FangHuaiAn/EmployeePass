using Android.App;
using Android.Widget;
using Android.OS;

namespace EmployeePass.Droid
{
	[Activity (Theme = "@style/MyTheme",Label = "員工票", Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {

				/*
				FragmentTransaction ft = FragmentManager.BeginTransaction();
				//Remove fragment else it will crash as it is already added to backstack
				Fragment prev = FragmentManager.FindFragmentByTag("dialog");
				if (prev != null) {
					ft.Remove(prev);
				}
				ft.AddToBackStack(null);
				// Create and show the dialog.
				MyAlertDialog newFragment = MyAlertDialog.NewInstance(null);
				//Add fragment
				newFragment.Show(ft, "dialog");
				*/

				/*
				AlertDialog.Builder alert = new AlertDialog.Builder (this);

				alert.SetTitle ("Title");
				alert.SetMessage ("Message");

				alert.SetPositiveButton ("OK", (senderAlert, args) => {
					Android.Util.Log.Info("Demo", "Click OK");
				} );

				alert.SetNegativeButton ("NO", (senderAlert, args) => {
					Android.Util.Log.Info("Demo", "Click NO");
				} );

				RunOnUiThread (() => {
					alert.Show();
				} );
				*/

			};

		}
	}
}


