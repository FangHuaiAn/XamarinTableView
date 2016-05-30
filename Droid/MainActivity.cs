using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace XamarinTableView.Droid
{
	[Activity (Label = "XamarinTableView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
	    private ListView _myListView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
		    _myListView = FindViewById<ListView>(Resource.Id.myListView);

		    LoadData();

		}

	    private void LoadData()
	    {

	        var list = new List<MyClass>
	        {
				new MyClass {Name = @"Aa", Description = @"aaaaaaa", ImageUrl = ""},
	            new MyClass {Name = @"Bb", Description = @"cccbbbaaa", ImageUrl = @"https://"},
				new MyClass {Name = @"Cc", Description = @"cccaaaaaaa", ImageUrl = ""},
	            new MyClass {Name = @"Dd", Description = @"ddcccaaaaaaa", ImageUrl = @"https://"}
	        };

			RunOnUiThread (
				() => {
					
					_myListView.Adapter = new MyClassListAdapter (list, this);
					_myListView.ItemClick += (sender, args) => {
						MyClass myclass = list [args.Position];

					};

				}
			);

	    }

        public class MyClassListAdapter : BaseAdapter<MyClass>
        {
            private Activity context;

            private List<MyClass> MyClasses { get; set; }

            public MyClassListAdapter(IEnumerable<MyClass> myclssesClasses, Activity context)
            {
                this.context = context;
                MyClasses = new List<MyClass>();

                MyClasses.AddRange(myclssesClasses);
            }


            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                MyClass myClass = MyClasses[position];

                var view = convertView;

                if (null == view)
                {
                    view = this.context.LayoutInflater.Inflate( Resource.Layout.myclass_listview_itemview, null );

                }

				view.FindViewById<TextView>(Resource.Id.myListView_itemview_txtName).Text = myClass.Name ;

                return view;
            }

            public override int Count => MyClasses.Count;

            public override MyClass this[int position] => MyClasses[position];
        }

	}
}


