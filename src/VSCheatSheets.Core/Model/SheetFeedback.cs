using System;

namespace VSCheatSheets.Model
{
    public class SheetFeedback : Entity
    {
        public virtual User User { get; set; }
        public virtual Sheet Sheet { get; set; }
        public virtual int Rating { get; set; }
        public virtual string Comment { get; set; }

    }
}