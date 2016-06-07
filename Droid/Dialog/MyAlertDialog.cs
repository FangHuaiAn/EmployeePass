#define CreateDialogWithOnCreateView 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace EmployeePass.Droid
{
	
	public class MyAlertDialog : DialogFragment
	{
		public static MyAlertDialog NewInstance(Bundle bundle){
			MyAlertDialog fragment = new MyAlertDialog ();
			fragment.Arguments = bundle;
			return fragment;
		}


		#if (! CreateDialogWithOnCreateView )

		public override Dialog OnCreateDialog (Bundle savedInstanceState)
		{
			AlertDialog.Builder alert = new AlertDialog.Builder (Activity);
			alert.SetTitle ("Alert Title");
			alert.SetMessage ("Message");
			alert.SetPositiveButton ("Confirm", (senderAlert, args) => {
				Toast.MakeText(Activity ,"Confirm!" , ToastLength.Short).Show();
			});
			alert.SetNegativeButton ("Cancel", (senderAlert, args) => {
				Toast.MakeText(Activity ,"Cancel!" , ToastLength.Short).Show();
			});

			return alert.Create ();
		}

		#else

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view =  inflater.Inflate(Resource.Layout.dialog_myalertdialog, container, false);
			Button button = view.FindViewById<Button> (Resource.Id.dialog_myalertdialog_btnConfirm);

			button.Click += (object sender, EventArgs e) => {
				Dismiss();
			};


			return view;
		}

		#endif


		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}


	}
}

