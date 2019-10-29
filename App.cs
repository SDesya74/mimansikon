using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Widget;

using Mimansikon.Entities.Fractions;
using Mimansikon.Entities.Players;
using Mimansikon.Util;
using System;

[Application]
public class App : Application {
	public App(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer) {
	}

	public static new Context Context;
	public static void Message(string text) {
		Toast.MakeText(Context, text.ToString(), ToastLength.Short).Show();
	}

	public override void OnCreate() {
		base.OnCreate();
		Context = ApplicationContext;

		FontManager.Init(Context);
		DataSaver.Init(Context);
		Screen.Init(Context);

		PlayerManager.Init();
		FractionManager.Init();
	}
}
