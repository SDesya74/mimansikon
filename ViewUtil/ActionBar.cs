using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using Android.Widget;

using Mimansikon.Util;

using System;

using static Android.Views.ViewGroup.LayoutParams;

namespace Mimansikon.ViewUtil {
	public class ActionBar {
		private readonly RelativeLayout Main;
		private readonly LinearLayout Buttons;
		public View View {
			get {
				return Main;
			}
		}

		readonly LinearLayout TitleLayout;
		readonly TextView TitleView;
		readonly TextView SubtitleView;

		public string Title {
			get {
				return TitleView.Text;
			}
			set {
				TitleView.Text = value;
			}
		}
		public string Subtitle {
			get {
				return SubtitleView.Text;
			}
			set {
				SubtitleView.Text = value;
				SubtitleView.Visibility = String.IsNullOrEmpty(value) ? ViewStates.Gone : ViewStates.Visible;
			}
		}


		public Android.Graphics.Color Color {
			get {
				return ((ColorDrawable) Main.Background).Color;
			}
			set {
				Main.SetBackgroundColor(value);
			}
		}

		private Android.Graphics.Color _textColor;
		public Android.Graphics.Color TextColor {
			get {
				return _textColor;
			}
			set {
				_textColor = value;
				TitleView.SetTextColor(value);
				SubtitleView.SetTextColor(value);
			}
		}

		public ActionBar(Context context) {
			Main = new RelativeLayout(context);
			Main.SetPadding(5.Dip(), 0, 5.Dip(), 0);
			Main.LayoutParameters = new ViewGroup.LayoutParams(MatchParent, Screen.ActionBarHeight);

			TitleLayout = new LinearLayout(context) {
				Orientation = Orientation.Vertical
			};
			TitleLayout.LayoutParameters = new ViewGroup.LayoutParams(WrapContent, MatchParent);
			TitleLayout.SetGravity(GravityFlags.CenterVertical | GravityFlags.Left);
			Main.AddView(TitleLayout);

			TitleView = new TextView(context) {
				TextSize = TypedValue.ApplyDimension(ComplexUnitType.Sp, 8, Screen.DisplayMetrics)
			};
			TitleLayout.AddView(TitleView);

			SubtitleView = new TextView(context) {
				TextSize = TypedValue.ApplyDimension(ComplexUnitType.Sp, 4, Screen.DisplayMetrics)
			};
			SubtitleView.Visibility = ViewStates.Gone;
			TitleLayout.AddView(SubtitleView);


			Buttons = new LinearLayout(context);
			var p = new RelativeLayout.LayoutParams(WrapContent, WrapContent);
			p.AddRule(LayoutRules.AlignParentEnd);
			p.AddRule(LayoutRules.CenterVertical);
			Buttons.LayoutParameters = p;
			Main.AddView(Buttons);
		}


		public delegate void OnClick(View view);
		public void AddButton(Drawable icon, OnClick listener) {
			ImageView view = new ImageView(View.Context);
			view.SetImageDrawable(icon);

			int pd = Screen.Dip(16);
			view.SetPadding(pd, pd, pd, pd);
			view.LayoutParameters = new LinearLayout.LayoutParams(Screen.ActionBarHeight, Screen.ActionBarHeight);
			view.Click += delegate {
				listener(view);
			};
			Buttons.AddView(view);
		}
	}
}