
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
using Button = Mimansikon.ViewUtil.Button;
using System;

namespace Mimansikon.Activities {
	[Activity(Label = "@string/fractions_activity")]
	public class FractionsActivity : ViewUtil.Activity {
		LinearLayout Main;
		protected override ActionBar OnCreateActionBar(ActionBar bar) {
			bar.Color = new Color(GetColor(Resource.Color.colorPrimaryDark));
			bar.TextColor = Color.White;
			bar.Title = GetString(Resource.String.fractions_activity);

			bar.AddButton(GetDrawable(Resource.Drawable.add), view => {
				var dialog = new NewFractionDialog(this);
				dialog.SetSize(Screen.Width / 4 * 3, Screen.Height / 2);
				dialog.AddButton("Ok", v => {
					if(String.IsNullOrWhiteSpace(dialog.FractionName)) return false;
					Fraction fraction = new Fraction(dialog.FractionName);
					FractionManager.Add(fraction);
					BuildList();
					return true;
				});
				dialog.ShowAt(view);

			});
			return bar;
		}

		protected override void OnCreateContent(ViewGroup Content) {
			var scroll = new ObservableScrollView(this);
			scroll.LayoutParameters = new RelativeLayout.LayoutParams(MatchParent, MatchParent);
			Content.AddView(scroll);

			Main = new LinearLayout(this) {
				Orientation = Orientation.Vertical
			};
			Main.LayoutParameters = new RelativeLayout.LayoutParams(MatchParent, MatchParent);
			scroll.AddView(Main);

			BuildList();
		}

		public void BuildList() {
			Main.RemoveAllViews();
			FractionManager.List.ForEach(e => AddItem(e));
		}

		public void AddItem(Fraction item) {
			LinearLayout main = new LinearLayout(this);
			main.SetGravity(GravityFlags.Center | GravityFlags.Left);
			main.SetPadding(5.Dip(), 15.Dip(), 5.Dip(), 15.Dip());
			main.Click += delegate {
				OpenFractionInfoActivity(item);
			};
			Main.AddView(main);

			TextView name = new TextView(this) {
				Text = item.Name,
				Gravity = GravityFlags.Center | GravityFlags.Left
			};
			name.SetTypefaceStyle(TypefaceStyle.Bold);
			main.AddView(name);
		}



		private static int InfoRequestCode = 740;
		private void OpenFractionInfoActivity(Fraction fraction) {
			Intent intent = new Intent(this, typeof(FractionInfoActivity));
			StartActivityForResult(intent, InfoRequestCode);
		}


		protected override void OnActivityResult(int requestCode, Result result, Intent intent) {
			if(requestCode == InfoRequestCode) {
				FractionManager.Load();
				BuildList();
			}
		}
	}
}