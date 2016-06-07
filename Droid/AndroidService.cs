using System;
using System.Linq;
using System.Collections.Generic;

namespace EmployeePass.Droid
{
	public class AndroidService : IMobileService
	{
		public AndroidService ()
		{
		}

		public string GetResponseFromUrl (string url, Dictionary<string, string> parameter){
			return string.Empty;
		}

		public string PostResponseToUrl (string url, Dictionary<string, string> parameter){
			return string.Empty;
		}
	}
}

