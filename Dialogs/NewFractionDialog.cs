using Android.Graphics;
using Android.Views;
using Android.Widget;

using Mimansikon.Util;
using Mimansikon.ViewUtil;

using static Android.Views.ViewGroup.LayoutParams;

using EditText = Mimansikon.ViewUtil.EditText;
using TextView = Mimansikon.ViewUtil.TextView;

namespace Mimansikon.Dialogs {
	public class NewFractionDialog : Dialog {
		public NewFractionDialog(Activity context) : base(context) {
		}




		public string FractionName { get { return NameEdit.Text; } }
		private EditText NameEdit;

		protected override void OnCreate() {
			LinearLayout layout = new LinearLayout(Context) {
				LayoutParameters = new ViewGroup.LayoutParams(MatchParent, MatchParent)
			};
			int pd = 6.Dip();
			layout.SetPadding(pd, pd, pd, pd);
			layout.Orientation = Orientation.Vertical;
			SetContentView(layout);

			TextView tv = new TextView(Context);
			tv.SetText(Resource.String.enter_fraction_name);
			layout.AddView(tv);

			NameEdit = new EditText(Context);
			NameEdit.SetMaxEms(30);
			NameEdit.SetColor(new Color(Context.GetColor(Resource.Color.colorPrimaryDark)));
			NameEdit.SetSingleLine();
			layout.AddView(NameEdit);

			Title = "Создание фракции";
			TitleColor = new Color(Context.GetColor(Resource.Color.colorPrimaryDark));
			TitleTextColor = Color.White;
			AddButton("Close", view => {
				return true;
			});
		}
	}
}