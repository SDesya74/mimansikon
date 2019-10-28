﻿using Android.Content;
using Android.Content.Res;
using Android.Graphics;

namespace Mimansikon.Util {
	class FontManager {
		public static Typeface Current { get; private set; }

		private static AssetManager Assets;

		public static void Init(Context context) {
			Current = Typeface.CreateFromAsset(context.Assets, "Fonts/CenturyGothic.ttf");
		}
	}
}