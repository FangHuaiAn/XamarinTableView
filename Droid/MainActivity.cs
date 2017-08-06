using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;

using AndroidSwipeLayout;
using AndroidSwipeLayout.Util;

namespace XamarinTableView.Droid
{
	[Activity (Label = "XamarinTableView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private ListView listView;
		private ListViewAdapter adapter;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);



		    LoadData();

		}

	    private void LoadData()
	    {

            var users = UserDataGenerator.ProduceUser();

			RunOnUiThread (
				() => {

					listView = FindViewById<ListView>(Resource.Id.listview);
					adapter = new ListViewAdapter(this, users);
					listView.Adapter = adapter;
					adapter.Mode = Attributes.Mode.Single;
					listView.ItemClick += (sender, e) =>
					{
						((SwipeLayout)(listView.GetChildAt(e.Position - listView.FirstVisiblePosition))).Open(true);
					};
					listView.Touch += (sender, e) =>
					{
						Console.WriteLine("ListView: OnTouch");
						e.Handled = false;
					};
					listView.ItemLongClick += (sender, e) =>
					{
						Toast.MakeText(this, "OnItemLongClickListener", ToastLength.Short).Show();
						e.Handled = true;
					};
					listView.ScrollStateChanged += (sender, e) =>
					{
						Console.WriteLine("ListView: OnScrollStateChanged");
					};
					listView.ItemSelected += (sender, e) =>
					{
						Console.WriteLine("ListView: OnItemSelected:" + e.Position);
					};
					listView.NothingSelected += (sender, e) =>
					{
						Console.WriteLine("ListView: OnNothingSelected:");
					};

				}
			);

	    }
	}
}


