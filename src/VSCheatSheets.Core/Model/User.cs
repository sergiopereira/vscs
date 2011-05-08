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

		public virtual ISet<Sheet> FavoriteSheets { get; set; }
	}
}