
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Mimansikon.Util;
using System.Collections.Generic;
using System.Linq;
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
			Dialogs = new List<Dialog>();

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

		public void RemoveContentView(View view) {
			DecorView.RemoveView(view);
		}

		private RelativeLayout DialogLayout;
		private List<Dialog> Dialogs;
		internal void AddDialog(Dialog dialog) {
			if(DialogLayout == null) {
				DialogLayout = new RelativeLayout(this) {
					LayoutParameters = new ViewGroup.LayoutParams(MatchParent, MatchParent)
				};
				DialogLayout.SetBackgroundColor(new Color(0x55000000));
				DialogLayout.Click += delegate {
					TryCloseLastDialog();
				};
				AddContentView(DialogLayout);
			}
			AddDialogToLayout(dialog);
		}


		public void AddDialogToLayout(Dialog dialog) {
			DialogLayout.AddView(dialog.View);
			Dialogs.Add(dialog);
		}

		public void OnDialogClosed(Dialog dialog) {
			Dialogs.Remove(dialog);
			dialog.Dispose();
			if(Dialogs.Count > 0 || DialogLayout== null) return;
			DecorView.RemoveView(DialogLayout);
			DialogLayout = null;
		}

		public void TryCloseLastDialog() {
			if(Dialogs.Count < 1) return;
			Dialog dialog = Dialogs.Last();
			if(dialog == null || !dialog.Closeable) return;

			dialog.Close();
			Dialogs.Remove(dialog);
		}


		public override void OnBackPressed() {
			if(Dialogs.Count > 0) TryCloseLastDialog();
			else base.OnBackPressed();
		}
	}
}