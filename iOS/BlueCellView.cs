// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace XamarinTableView.iOS
{
	public partial class BlueCellView : UITableViewCell
	{
		public BlueCellView (IntPtr handle) : base (handle)
		{
		}

		public void UpdateUI(User user){
		
			lbName.Text = user.Name;

		}
	}
}
