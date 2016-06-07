using System;

namespace EmployeePass
{
	public class Employee{
		public string Name { get; set; }
		public string PhotoPath { get; set; }
	}


	public class EmployeeManager
	{
		private IMobileService MobileService { get; set;}

		public EmployeeManager (IMobileService mobileService)
		{
			MobileService = mobileService;
		}

		public Employee IsPassAuthentication( string account, string password ){
			return new Employee{Name = @"Tester", PhotoPath = @"http://img.vogue.com.tw/userfiles/thumbnail/sm1280_images_A0/12931/2014012153733473.jpg"};
		}

	}
}

