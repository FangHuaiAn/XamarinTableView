using System;
using System.Linq;
using System.Collections.Generic;
		
using UIKit;


using Debug = System.Diagnostics.Debug ;

namespace XamarinTableView.iOS
{
	public partial class ViewController : UIViewController
	{
		
		public ViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ShowTable ();
		}

		public void ShowTable(){

			var list = new List<User>
			{
				new User {Name = @"Aa", Description = @"使用者 甲", ImageUrl = ""},
				new User {Name = @"Bb", Description = @"使用者 乙", ImageUrl = @"https://"},
				new User {Name = @"Cc", Description = @"使用者 丙", ImageUrl = ""},
				new User {Name = @"Dd", Description = @"使用者 丁", ImageUrl = @"https://"}
			};

			var tableSource = new UserTableSource (list);
			myTableView.Source = tableSource;

			tableSource.UserSelected += delegate(object sender, UserSelectedEventArgs e) {

				Debug.WriteLine (e.SelectedUser.Name);
			};

			myTableView.ReloadData ();
		
		
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}

		public class UserTableSource :UITableViewSource {
			// CellView Identifier
			const string BlueCellViewIdentifier = @"BlueCellView";
			const string GreenCellViewIdentifier = @"GreenCellView";

			// ctor. Model

			private List<User> Users { get; set;}

			public UserTableSource( IEnumerable<User> users ){
				Users = new List<User>();
				Users.AddRange( users );
			}

			// Model -> Controller -> View

			// Memory
			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return (nint)Users.Count;
			}

			public override nfloat GetHeightForRow (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				User myClass = Users[indexPath.Row];

				if (string.IsNullOrEmpty (myClass.ImageUrl)) {
					// Green
					return 100.0f;
				}
				else {
					// Blue
					return 150.0f;
				
				}
			}

			// Controller -> View
			public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
			{

				User myClass = Users[indexPath.Row];

				if (string.IsNullOrEmpty (myClass.ImageUrl)) {
					// Green
					GreenCellView cell = tableView.DequeueReusableCell( GreenCellViewIdentifier ) 
						as GreenCellView ;

					cell.UpdateUI (myClass);

					return cell;

				}
				else {
					// Blue
					BlueCellView cell = tableView.DequeueReusableCell( BlueCellViewIdentifier ) 
						as BlueCellView ;

					cell.UpdateUI (myClass);

					return cell;

				}


			}


			// View -> Controller

			public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				tableView.DeselectRow (indexPath, true);

				User user = Users[indexPath.Row];

				EventHandler<UserSelectedEventArgs> handle = UserSelected;

				if (null != handle) {

					var args = new UserSelectedEventArgs{ SelectedUser = user };
				
					handle (this, args);
				}

			}

			/// <summary>
			/// 設計事件，回傳結果給呼叫端
			/// </summary>
			public event EventHandler<UserSelectedEventArgs> UserSelected ;

		}

		public class UserSelectedEventArgs : EventArgs{

			public User SelectedUser { get; set;}

		}


	}
}
