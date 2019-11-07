using Mimansikon.Util;

using System.Collections.Generic;

namespace Mimansikon.Entities.Players {
	class PlayerManager {
		public static List<Player> List;

		public static void Init() {
			List = new List<Player>();
		}

		public static void Save() {
			DataSaver.Save("players", List);
		}

		public static void Load() {
			List = (List<Player>) DataSaver.Read("players") ?? new List<Player>();
		}
	}
}