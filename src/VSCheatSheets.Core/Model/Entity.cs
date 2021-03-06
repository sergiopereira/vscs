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
	public abstract class Entity {
		protected const int DefaultNameMaxLength = 50;
		protected const int DefaultDescriptionMaxLength = 200;
		protected const int DefaultUrlMaxLength = 100;

		public virtual long ID { get; set; }
		public virtual DateTime CreatedAtUtc { get; set; }
		public virtual User CreatedBy { get; set; }
		public virtual DateTime UpdatedAtUtc { get; set; }
		public virtual User UpdatedBy { get; set; }
	}
}