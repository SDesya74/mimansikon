using Android.Content;
using Android.Graphics;
using Android.Runtime;

using Mimansikon.Util;

using System;

namespace Mimansikon.ViewUtil {
	class TextView : Android.Widget.TextView {
		public TextView(Context context) : base(context) {
			Typeface = FontManager.Current;
		}

		protected TextView(IntPtr javaReference, JniHandleOwnership transfer) 
			: base(javaReference, transfer) {}

		public void SetTypefaceStyle(TypefaceStyle style) {
			SetTypeface(FontManager.Current, style);
		}
	}
}