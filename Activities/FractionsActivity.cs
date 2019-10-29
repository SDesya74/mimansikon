
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Mimansikon.Dialogs;
using Mimansikon.Entities;
using Mimansikon.Entities.Fractions;
using Mimansikon.Util;
using Mimansikon.ViewUtil;
using Refractored.Fab;

using static Android.Views.ViewGroup.LayoutParams;
using ActionBar = Mimansikon.ViewUtil.ActionBar;
using Activity = Android.App.Activity;
using TextView = Mimansikon.ViewUtil.TextView;

namespace Mimansikon.Activities {
	[Activity(Label = "@string/fractions_activity")]
	public class FractionsActivity : ViewUtil.Activity {
		LinearLayout Main;
		protected override ActionBar OnCreateActionBar(ActionBar bar) {
			bar.Color = new Color(GetColor(Resource.Color.colorMimansikonPurple));
			bar.TextColor = Color.White;
			bar.Title = GetString(Resource.String.app_name);
			return bar;
		}

		protected override void OnCreateContent(ViewGroup Content) {
			ObservableScrollView scroll = new ObservableScrollView(this);
			//SetContentView(scroll);

			Main = new LinearLayout(this);
			scroll.AddView(Main);

			var parameters = new RelativeLayout.LayoutParams(WrapContent, WrapContent);
			parameters.AddRule(LayoutRules.AlignParentEnd);
			parameters.AddRule(LayoutRules.AlignParentBottom);
			parameters.BottomMargin = 30.Dip();
			parameters.MarginEnd = 30.Dip();

			FloatingActionButton button = new FloatingActionButton(this) {
				LayoutParameters = parameters
			};
			button.SetImageDrawable(GetDrawable(Resource.Drawable.add));
			button.ColorNormal = GetColor(Resource.Color.colorPrimary);
			button.ColorPressed = GetColor(Resource.Color.colorPrimaryDark);
			button.Click += delegate {
				var dialog = new NewFractionDialog(this);
				dialog.SetSize(Screen.Width / 4 * 3, Screen.Height / 2);
				dialog.ShowAt(button);
			};
			AddContentView(button);
			BuildList();
		}



		public void BuildList() {
			FractionManager.Load();
			Main.RemoveAllViews();
			FractionManager.List.ForEach(e => AddItem(e));
		}

		public void AddItem(Fraction item) {
			LinearLayout main = new LinearLayout(this);
			main.SetGravity(GravityFlags.Center | GravityFlags.Left);
			main.SetPadding(3.Dip(), 3.Dip(), 3.Dip(), 3.Dip());
			Main.AddView(main);

			TextView name = new TextView(this);
			name.Text = item.Name;
			name.Gravity = GravityFlags.Center | GravityFlags.Left;
			name.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
			main.AddView(name);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
			if(requestCode == 740) BuildList();
		}
	}
}