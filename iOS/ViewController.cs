using System;
using System.Linq;
using System.Collections.Generic;
		
using UIKit;


using static System.Console ;

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

			var list = UserDataGenerator.ProduceUser();

			var tableSource = new UserTableSource (list);
			myTableView.Source = tableSource;

			tableSource.UserSelected += delegate(object sender, UserSelectedEventArgs e) {

				WriteLine (e.SelectedUser.Name);
			};

			myTableView.ReloadData ();
		
		
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}

		public class UserTableSource :UITableViewSource {

			/// <summary>
			/// 設計事件，回傳結果給呼叫端
			/// </summary>
			public event EventHandler<UserSelectedEventArgs> UserSelected;

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

			// Controller -> View
			public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
			{

                User user = Users[indexPath.Row];

                if (user.IsBlue ) {
					// Blue
					BlueCellView cell = tableView.DequeueReusableCell(BlueCellViewIdentifier)
						as BlueCellView;

					cell.UpdateUI(user);

					return cell;

				}
				else {
					// Green
					GreenCellView cell = tableView.DequeueReusableCell(GreenCellViewIdentifier)
						as GreenCellView;

                    cell.UpdateUI(user);

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

			// Add Row Action
			public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
            {
                var threeAction = indexPath.Row % 2 == 0;


                var actions = new List<UITableViewRowAction>();

                var viewAction = UITableViewRowAction.Create(
                    UITableViewRowActionStyle.Normal,
                    "檢視", 
                    (UITableViewRowAction arg1, Foundation.NSIndexPath arg2) =>
					{
                    User user = Users[arg2.Row];
                    WriteLine($" { user.Name } : 檢視 Action");
                    }
                );
                viewAction.BackgroundColor = UIColor.FromRGB(170,170,170);
                actions.Add(viewAction);

				var execAction = UITableViewRowAction.Create( UITableViewRowActionStyle.Normal,
                    "執行",
                    (UITableViewRowAction arg1, Foundation.NSIndexPath arg2) => 
					{
                    User user = Users[arg2.Row];
                    WriteLine($" { user.Name } : 執行 Action");
					}
				);
                execAction.BackgroundColor = UIColor.FromRGB(185, 185, 185);

                if( threeAction ){
                    actions.Add(execAction);
                }

				var changeAction = UITableViewRowAction.Create(UITableViewRowActionStyle.Normal,
					"異動",
					(UITableViewRowAction arg1, Foundation.NSIndexPath arg2) =>
					{
                    User user = Users[arg2.Row];
                    WriteLine($" { user.Name } : 異動 Action");
					}
				);
                changeAction.BackgroundColor = UIColor.FromRGB(200, 200, 200);

				if (threeAction)
				{
					actions.Add(changeAction);
				}

                return actions.ToArray();

            }

		}

		public class UserSelectedEventArgs : EventArgs{

			public User SelectedUser { get; set;}

		}


	}
}
