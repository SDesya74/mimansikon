using System.Collections.Generic;

namespace Mimansikon.Entities.Dices {
	public class DiceQueue<T> {
		public List<(T, List<Dice>)> Queue { get; private set; }


		public DiceQueue(List<T> list) {
			Queue = new List<(T, List<Dice>)>();
			list.ForEach(e => Queue.Add((e, new List<Dice>())));
		}


		public void Randomize() {
#warning RANDOMIZE
		}
	}
}