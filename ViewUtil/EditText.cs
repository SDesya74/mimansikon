using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;

using Mimansikon.Util;

using System;

namespace Mimansikon.ViewUtil {
	class EditText : Android.Widget.EditText {
		public EditText(Context context) : base(context) {
			SetTypeface(FontManager.Current, TypefaceStyle.Bold);
		}

		protected EditText(IntPtr javaReference, JniHandleOwnership transfer) 
			: base(javaReference, transfer) {}

		public void SetColor(Color color) {
			if(Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
				BackgroundTintList = ColorStateList.ValueOf(color);
			} else {
				Background.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
			}
		}
	}
}