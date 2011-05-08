using Iesi.Collections.Generic;

namespace VSCheatSheets.Model {
	public class Sheet : Entity {
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual bool Private { get; set; }
		public virtual string ContentMarkdown { get; set; }
		public virtual string Permalink { get; set; }

		/// <summary>
		/// Average voted rating. From 0 to 10 (even if we show 0 to 5 stars)
		/// </summary>
		public virtual int AverageRating { get; set; }

		public virtual ISet<SheetRating> Ratings { get; set; }
	}
}