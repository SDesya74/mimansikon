using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Mimansikon.Entities.Dices {
	public class Dice {
		private static Random DiceRandom = new Random(DateTime.Now.ToUniversalTime().Millisecond);
		public int Value { get; private set; }

		public Dice Roll() {
			Value = DiceRandom.Next(1, 7);
			return this;
		}

		
	}
}