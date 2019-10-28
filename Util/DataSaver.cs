using Android.Content;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mimansikon.Util {
	class DataSaver {
		private static readonly BinaryFormatter Formatter = new BinaryFormatter();
		public static string InternalStorage { get; private set; }

		public static void Init(Context context) {
			InternalStorage = context.FilesDir.ToString();
		}

		public static void Save(string name, object data) {
			try {
				using(var writer = File.Create(Path.Combine(InternalStorage, name)))
					Formatter.Serialize(writer, data);
			} catch {
				App.Message("Ошиб очка");
			}
		}

		public static object Read(string name) {
			try {
				using(var stream = File.OpenRead(Path.Combine(InternalStorage, name))) 
					return Formatter.Deserialize(stream);
			} catch {
				return null;
			}
		}

		public static void Delete(string name) {
			File.Delete(Path.Combine(InternalStorage, name));
		}
	}
}