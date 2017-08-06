using System;
using System.Collections.Generic;

namespace XamarinTableView
{
	public class User
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Password { get; set; }

		public bool IsBlue { get; set; }
	}

	public class UserDataGenerator
	{

		public static List<User> ProduceUser()
		{
			var list = new List<User>
			{
				new User {Name = @"Aa", Description = @"使用者 甲", IsBlue = false},
				new User {Name = @"Bb", Description = @"使用者 乙", IsBlue = true},
				new User {Name = @"Cc", Description = @"使用者 丙", IsBlue = false},
				new User {Name = @"Dd", Description = @"使用者 丁", IsBlue = true}
			};

			return list;
		}

	}
}




