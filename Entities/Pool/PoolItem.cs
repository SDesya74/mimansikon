using Mimansikon.Entities.Items;

namespace Mimansikon.Entities.Pool {
	class PoolItem {
		public ItemType Type { get; set; }
		public int Count { get; set; } = 0;
		public ItemParameters Parameters { get; set; }
	}
}