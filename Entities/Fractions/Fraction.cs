using System;

namespace Mimansikon.Entities {
	[Serializable]
	public class Fraction {
		public Fraction(string name) {
			this.Name = name;
		}

		public String Name { get; set; }
		public String Description { get; set; }
	}
}