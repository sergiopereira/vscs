#region Copyright notice
// Copyright (c) 2011, Sergio Pereira, sergiopereira.com
// 
// The author doesn't speak legalese and doesn't want to even hear about it.
// Anyone is free to use this code as they wish as long as they assume total responsibility of such use and any damages caused by it.
// The author doesn't even care if you steal this code and never give proper attribution. 
// 
// THIS CODE WANTS TO BE FREE
#endregion
using System;

namespace VSCheatSheets.Model {
	public class SheetReview : Entity {
		public virtual User User { get; set; }
		public virtual Sheet Sheet { get; set; }
		public virtual int Rating { get; set; }
		public virtual string Comment { get; set; }
	}
}