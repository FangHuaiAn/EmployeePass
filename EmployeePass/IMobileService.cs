using System;
using System.Linq;
using System.Collections.Generic;

namespace EmployeePass
{
	public interface IMobileService
	{
		string GetResponseFromUrl (string url, Dictionary<string, string> parameter);
		string PostResponseToUrl (string url, Dictionary<string, string> parameter);
	}
}

