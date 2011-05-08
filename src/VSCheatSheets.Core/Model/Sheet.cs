using System;
using Iesi.Collections.Generic;

namespace VSCheatSheets.Model
{
    public class Sheet : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string ContentMarkdown { get; set; }
        /// <summary>
        /// Average voted rating. From 0 to 10 (even if we show 0 to 5 stars)
        /// </summary>
        public virtual int AverageRating { get; set; }

        public virtual ISet<SheetRating> Ratings { get; set; }
    }

    public class SheetRating : Entity
    {
        public virtual User User { get; set; }
        public virtual Sheet Sheet { get; set; }
        public virtual int Rating { get; set; }
        public virtual string Comment { get; set; }
        public virtual DateTime CommentedAt { get; set; }

    }
}