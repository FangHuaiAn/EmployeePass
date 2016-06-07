using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmployeePass
{
	public static class ExtensionMethods
	{
		public static void ClearThenAddRange<T> ( this List<T> origin, List<T> target){

			if (null == origin) {
				origin = new List<T> ();
			}

			if (null != target && target.Count > 0) {
				origin.Clear ();
				origin.AddRange (target);
			}

		}
	}
}

