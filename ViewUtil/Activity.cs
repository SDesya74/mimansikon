
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Mimansikon.Util;
using static Android.Views.ViewGroup.LayoutParams;

namespace Mimansikon.ViewUtil {
	[Activity(Label = "Activity")]
	public class Activity : Android.App.Activity {
		public RelativeLayout DecorView { get; private set; }
		private new ActionBar ActionBar;
		private LinearLayout Content;

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			Screen.Init(this);

			DecorView = new RelativeLayout(this) {
				LayoutParameters = new ViewGroup.LayoutParams(MatchParent, MatchParent)
			};
			SetContentView(DecorView);

			ActionBar = OnCreateActionBar(new ActionBar(this));
			if(ActionBar != null) DecorView.AddView(ActionBar.View);

			Content = new LinearLayout(this) {
				LayoutParameters = new RelativeLayout.LayoutParams(MatchParent,
				Screen.Height - Screen.ActionBarHeight) {
					TopMargin = Screen.ActionBarHeight
				}
			};
			Content.SetGravity(GravityFlags.Center);
			DecorView.AddView(Content);

			OnCreateContent(Content);
		}

		protected virtual void OnCreateContent(ViewGroup Parent) {
		}

		protected virtual ActionBar OnCreateActionBar(ActionBar bar) {
			var component = new ComponentName(this, Java.Lang.Class.FromType(typeof(Activity)));
			var activityInfo = PackageManager.GetActivityInfo(component, 0);
			var label = activityInfo.NonLocalizedLabel.ToString();

			bar.Title = label;
			bar.Subtitle = "Activity";
			return ActionBar;
		}

		public void AddContentView(View view) {
			DecorView.AddView(view);
			view.BringToFront();
		}
	}
}