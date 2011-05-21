#region Copyright notice
// Copyright (c) 2011, Sergio Pereira, sergiopereira.com
// 
// The author doesn't speak legalese and doesn't want to even hear about it.
// Anyone is free to use this code as they wish as long as they assume total responsibility of such use and any damages caused by it.
// The author doesn't even care if you steal this code and never give proper attribution. 
// 
// THIS CODE WANTS TO BE FREE
#endregion

using Iesi.Collections.Generic;

namespace VSCheatSheets.Model {
	public class Sheet : Entity {
		public const int ContentMaxLength = 5000;
		public const int PermalinkMaxLength = 60;
		public const int NameMaxLength = DefaultNameMaxLength;
		public const int DescriptionMaxLength = DefaultDescriptionMaxLength;

		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual bool Private { get; set; }
		public virtual string ContentMarkdown { get; set; }
		public virtual string Permalink { get; set; }
		public virtual User User { get; set; }

		/// <summary>
		/// Average voted rating. From 0 to 10 (even if we show 0 to 5 stars)
		/// </summary>
		public virtual int AverageRating { get; set; }

		public virtual ISet<SheetReview> Reviews { get; set; }
	}
}