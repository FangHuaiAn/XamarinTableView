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
	[Register ("BlueCellView")]
	partial class BlueCellView
	{
		[Outlet]
		UIKit.UIButton btnConfirm { get; set; }

		[Outlet]
		UIKit.UIImageView iconImageView { get; set; }

		[Outlet]
		UIKit.UILabel lbName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnConfirm != null) {
				btnConfirm.Dispose ();
				btnConfirm = null;
			}

			if (iconImageView != null) {
				iconImageView.Dispose ();
				iconImageView = null;
			}

			if (lbName != null) {
				lbName.Dispose ();
				lbName = null;
			}
		}
	}
}
