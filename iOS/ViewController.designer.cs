// WARNING
//
// This file has been generated automatically by Xamarin Studio Community to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinTableView.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITableView myTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (myTableView != null) {
				myTableView.Dispose ();
				myTableView = null;
			}
		}
	}
}
