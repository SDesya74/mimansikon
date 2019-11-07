using System;

namespace Mimansikon.Entities.Dices {
	public class Dice {
		private static Random DiceRandom = new Random(DateTime.Now.ToUniversalTime().Millisecond);
		public int Value { get; private set; }

		public Dice Roll() {
			Value = DiceRandom.Next(1, 7);
			return this;
		}


		public static Dice Random() {
			return new Dice().Roll();
		}

	}
}