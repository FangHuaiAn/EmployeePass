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
using Android.Views.InputMethods;

using Debug = System.Diagnostics.Debug;

namespace EmployeePass.Droid
{
	[Activity (Label = "員工票", Theme = "@style/MyTheme")]			
	public class LoginActivity : Activity
	{
		private InputMethodManager _InputMethodManager;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.loginview);

			_InputMethodManager = (InputMethodManager)GetSystemService (Context.InputMethodService); 

			var txtAccount = FindViewById<EditText> (Resource.Id.loginview_txtAccount); 
			var txtPassword = FindViewById<EditText> (Resource.Id.loginview_txtPassword);

			var btnLogin = FindViewById<Button> (Resource.Id.loginview_btnLogin);

			btnLogin.Click += (object sender, EventArgs e) => {

				if( txtAccount.HasFocus ){
					_InputMethodManager.HideSoftInputFromWindow( txtAccount.WindowToken, 0 );
				}

				if( txtPassword.HasFocus ){
					_InputMethodManager.HideSoftInputFromWindow( txtPassword.WindowToken, 0 );
				}

				if( 0 == txtAccount.Text.Trim().Length || 0 == txtPassword.Text.Trim().Length ){
					ShowAlert("認證", "帳號密碼欄位不得為空", "確認" );
					return;
				}

				var employeeManager = new EmployeeManager( new AndroidService () );
				if( null != employeeManager.IsPassAuthentication( txtAccount.Text.Trim(), txtPassword.Text.Trim() )){

					UniversalApplication.AppUser = new Employee{Name = @"Liddle Fang"};

					StartActivity(typeof(MenuActivity));
				}
				else{
					ShowAlert("認證", "帳號密碼認證失敗", "確認" );
				}
			};

		}

		private void ShowAlert(string title, string message, string confirmString, Action confirmAction = null, string cancelString = null, Action cancelAction = null ){

			AlertDialog.Builder alert = new AlertDialog.Builder (this);

			alert.SetTitle (title);
			alert.SetMessage (message);

			if (!string.IsNullOrEmpty (confirmString)) {
				alert.SetPositiveButton (confirmString, (sender, e) =>{ 
					if( null != confirmAction ){
						confirmAction(); 
					}
				});
			}

			if (!string.IsNullOrEmpty (cancelString)) {
				alert.SetNegativeButton (cancelString, (sender, e) =>{ 
					if( null != cancelAction){
						cancelAction(); 
					}
				});
			} 

			RunOnUiThread (() => {
				alert.Show();
			} );

		}
	}
}

