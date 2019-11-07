using Android.Content;
using Android.Graphics;

namespace Mimansikon.Util {
	class FontManager {
		public static Typeface Current { get; private set; }

		public static void Init(Context context) {
			Current = Typeface.CreateFromAsset(context.Assets, "Fonts/CenturyGothic.ttf");
		}
	}
}