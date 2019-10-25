using Mimansikon.Misc;

using System.Collections.Generic;

namespace Mimansikon.Entities.Fractions {
	public static class FractionManager {
		public static List<Fraction> List;
		
		public static void Init() {
			List = new List<Fraction>();
		}

		public static void Save() {
			DataSaver.Save("fractions", List);
		}

		public static void Load() {
			List = (List<Fraction>) DataSaver.Read("fractions") ?? new List<Fraction>();
		}

	}
}