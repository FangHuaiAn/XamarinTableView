using System;
using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;

using AndroidSwipeLayout;
using AndroidSwipeLayout.Adapters;

namespace XamarinTableView.Droid
{
	public class ListViewAdapter : BaseSwipeAdapter
	{
		private Context context;
		private List<User> Users { get; set; }

		public ListViewAdapter(Context context, IEnumerable<User> users)
		{
			this.context = context;

			Users = new List<User>();
			Users.AddRange(users);
		}

		public override int GetSwipeLayoutResourceId(int position)
		{
			if (position % 2 == 0)
			{
				return Resource.Id.swipe;
			}
			else
			{
				return Resource.Id.swipe2;
			}


		}

		public override View GenerateView(int position, ViewGroup parent)
		{
			if (position % 2 == 0)
			{

				var view = LayoutInflater.From(context).Inflate(Resource.Layout.listview_item1, null);
				var swipeLayout = view.FindViewById<SwipeLayout>(GetSwipeLayoutResourceId(position));

				//swipeLayout.Opened += (sender, e) => {
				//  YoYo.With (Techniques.Tada)
				//      .Duration (500)
				//      .Delay (100)
				//      .PlayOn (e.Layout.FindViewById (Resource.Id.item_view ));
				//};

				swipeLayout.DoubleClick += (sender, e) =>
				{
					var pos = (int)view.Tag;
					Toast.MakeText(context, "DoubleClick " + pos, ToastLength.Short).Show();
				};

				view.FindViewById(Resource.Id.item_view).Click += (sender, e) =>
				{
					var pos = (int)view.Tag;
					Toast.MakeText(context, "click item_view: " + pos, ToastLength.Short).Show();
				};

				view.FindViewById(Resource.Id.item_action).Click += (sender, e) =>
				{
					var pos = (int)view.Tag;
					Toast.MakeText(context, "click item_action: " + pos, ToastLength.Short).Show();
				};

				view.FindViewById(Resource.Id.item_save).Click += (sender, e) =>
				{
					var pos = (int)view.Tag;
					Toast.MakeText(context, "click item_save: " + pos, ToastLength.Short).Show();
				};

				return view;
			}
			else
			{
				var view = LayoutInflater.From(context).Inflate(Resource.Layout.listview_item2, null);
				var swipeLayout = view.FindViewById<SwipeLayout>(GetSwipeLayoutResourceId(position));

				swipeLayout.DoubleClick += (sender, e) =>
				{
					var pos = (int)view.Tag;
					Toast.MakeText(context, "DoubleClick " + pos, ToastLength.Short).Show();
				};

				view.FindViewById(Resource.Id.item_view2).Click += (sender, e) =>
				{
					var pos = (int)view.Tag;
					Toast.MakeText(context, "click item_view2: " + pos, ToastLength.Short).Show();
				};

				view.FindViewById(Resource.Id.item_action2).Click += (sender, e) =>
				{
					var pos = (int)view.Tag;
					Toast.MakeText(context, "click item2_action: " + pos, ToastLength.Short).Show();
				};

				return view;

			}


		}

		public override void FillValues(int position, View convertView)
		{
			convertView.Tag = position;

			if (position % 2 == 0)
			{
				var t = (TextView)convertView.FindViewById(Resource.Id.position);
				t.Text = (position + 1) + ".";

				var label = (TextView)convertView.FindViewById(Resource.Id.text_data);
				label.Text = Users[position].Name;
			}
			else
			{
				var t = (TextView)convertView.FindViewById(Resource.Id.position2);
				t.Text = (position + 1) + ".";

				var label = (TextView)convertView.FindViewById(Resource.Id.text_data2);
				label.Text = Users[position].Name;

			}


		}

		public override int Count
		{
			get
			{
				return Users.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
	}
}
