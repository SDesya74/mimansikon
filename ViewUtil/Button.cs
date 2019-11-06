using Android.Content;
using Android.Graphics;
using Android.Runtime;

using Mimansikon.Util;

using System;

namespace Mimansikon.ViewUtil {
	public class Button : Android.Widget.Button {
		public Button(Context context) : base(context) {
			SetTypeface(FontManager.Current, Android.Graphics.TypefaceStyle.Bold);
		}

		private Android.Graphics.Color _color;
		public Android.Graphics.Color Color {
			get {
				return _color;
			}
			set {
				_color = value;
				Background.SetColorFilter(value, PorterDuff.Mode.Multiply);
			}
		}

		protected Button(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) {
		}
	}
}