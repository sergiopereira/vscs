using System;

namespace VSCheatSheets.Model {
	public abstract class Entity {
		public virtual long ID { get; set; }
		public virtual DateTime CreatedAtUtc { get; set; }
		public virtual User CreatedBy { get; set; }
		public virtual DateTime UpdatedAtUtc { get; set; }
		public virtual User UpdatedBy { get; set; }
	}
}