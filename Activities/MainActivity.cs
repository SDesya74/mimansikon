
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

using Mimansikon.Entities.Fractions;
using Mimansikon.Entities.Players;
using Mimansikon.Util;
using Mimansikon.ViewUtil;

using Refractored.Fab;

using System;

using static Android.Views.ViewGroup.LayoutParams;

using ActionBar = Mimansikon.ViewUtil.ActionBar;
using Button = Mimansikon.ViewUtil.Button;

namespace Mimansikon.Activities {
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : ViewUtil.Activity {
		protected override ActionBar OnCreateActionBar(ActionBar bar) {
			bar.Color = new Color(GetColor(Resource.Color.colorPrimary));
			bar.TextColor = Color.White;
			bar.Title = GetString(Resource.String.app_name);
			return bar;
		}


		protected override void OnCreateContent(ViewGroup Content) {
			LinearLayout parent = new LinearLayout(this);
			parent.SetGravity(GravityFlags.Center);
			Content.AddView(parent);

			LinearLayout main = new LinearLayout(this) {
				Orientation = Orientation.Vertical
			};
			parent.AddView(main);

			var players = CreateButton(Resource.String.players_activity, delegate {
				Intent intent = new Intent(this, typeof(PlayersActivity));
				StartActivity(intent);
			});
			main.AddView(players);

			var fractions = CreateButton(Resource.String.fractions_activity, delegate {
				Intent intent = new Intent(this, typeof(FractionsActivity));
				StartActivity(intent);
			});
			main.AddView(fractions);

			var pick = CreateButton(Resource.String.pick_menu_activity, delegate {
				Intent intent = new Intent(this, typeof(PickMenuActivity));
				StartActivity(intent);
			});
			main.AddView(pick);

			var dices = CreateButton(Resource.String.dices_activity, delegate {
				Intent intent = new Intent(this, typeof(DicesActivity));
				StartActivity(intent);
			});
			main.AddView(dices);

			LoadManagers();
		}

		private Button CreateButton(int resource, EventHandler handler) {
			Button button = new Button(this) {
				Color = new Color(GetColor(Resource.Color.colorPrimaryDark))
			};
			button.SetTextColor(Color.White);
			button.SetText(resource);
			button.Click += handler;
			return button;
		}

		public static void LoadManagers() {
			PlayerManager.Load();
			FractionManager.Load();
		}
	}
}