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
using Mimansikon.Util;

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