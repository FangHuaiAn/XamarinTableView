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
		
			var list = new List<MyClass> ();
		
			list.Add (new MyClass{ Name = @"Aa", Description = @"aaaaaaa" });
			list.Add (new MyClass{ Name = @"Bb", Description = @"cccbbbaaa", ImageUrl =@"https://" });
			list.Add (new MyClass{ Name = @"Cc", Description = @"cccaaaaaaa" });
			list.Add (new MyClass{ Name = @"Dd", Description = @"ddcccaaaaaaa", ImageUrl =@"https://" });


			var tableSource = new MyClassTableSource (list);
			myTableView.Source = tableSource;

			tableSource.MyClassSelected += delegate(object sender, MyClassSelectedEventArgs e) {

				Debug.WriteLine (e.SelectedMyClass.Name);
			};

			myTableView.ReloadData ();
		
		
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}

		public class MyClassTableSource :UITableViewSource {
			// CellView Identifier
			const string BlueCellViewIdentifier = @"BlueCellView";
			const string GreenCellViewIdentifier = @"GreenCellView";

			// ctor. Model

			private List<MyClass> MyClasses { get; set;}

			public MyClassTableSource( IEnumerable<MyClass> myClasses ){
				MyClasses = new List<MyClass>();
				MyClasses.AddRange( myClasses );
			}

			// Model -> Controller -> View

			// Memory
			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return (nint)MyClasses.Count;
			}

			public override nfloat GetHeightForRow (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				MyClass myClass = MyClasses[indexPath.Row];

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

				MyClass myClass = MyClasses[indexPath.Row];

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

				MyClass myClass = MyClasses[indexPath.Row];

				EventHandler<MyClassSelectedEventArgs> handle = MyClassSelected;

				if (null != handle) {

					var args = new MyClassSelectedEventArgs{ SelectedMyClass = myClass };
				
					handle (this, args);
				}

			}

			public event EventHandler<MyClassSelectedEventArgs> MyClassSelected ;

		}

		public class MyClassSelectedEventArgs : EventArgs{

			public MyClass SelectedMyClass { get; set;}

		}


	}
}
