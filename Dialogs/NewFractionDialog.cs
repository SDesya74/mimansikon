using Android.Views;
using Android.Widget;

using Mimansikon.ViewUtil;

using TextView = Mimansikon.ViewUtil.TextView;
using static Android.Views.ViewGroup.LayoutParams;

namespace Mimansikon.Dialogs {
	public class NewFractionDialog : Dialog {
		public NewFractionDialog(Activity context) : base(context) {
		}

		protected override void OnCreate() {
			LinearLayout layout = new LinearLayout(Context);
			layout.LayoutParameters = new ViewGroup.LayoutParams(MatchParent, MatchParent);
			SetContentView(layout);

			TextView view = new TextView(Context);
			view.Text = "Hello World!";
			layout.AddView(view);
		}
	}
}