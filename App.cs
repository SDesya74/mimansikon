using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Mimansikon.Entities.Fractions;

using Android.Graphics;
using Android.Widget;

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
		FractionManager.Init();
	}
}
