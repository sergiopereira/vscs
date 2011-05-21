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
using Iesi.Collections.Generic;

namespace VSCheatSheets.Model {
	public class User : Entity {
		public const long AnonymousUserID = 1;

		public virtual string Email { get; set; }
		public virtual string DisplayName { get; set; }
		public virtual string HomePageUrl { get; set; }
		public virtual string TwitterName { get; set; }
		public virtual DateTime JoinedAt { get; set; }
		public virtual string PasswordHash { get; set; }
		public virtual string PasswordSalt { get; set; }
		public virtual AccountStatus Status { get; set; }
		public virtual DateTime LastLoginAt { get; set; }
		public virtual int FailedLoginCount { get; set; }

		/// <summary>
		/// Notes about the user. Only visible by the administrator.
		/// </summary>
		public virtual string AdminNotes { get; set; }

		public virtual ISet<Sheet> Sheets { get; set; }

		//public virtual ISet<Sheet> FavoriteSheets { get; set; }
	}
}