namespace VSCheatSheets.Model {
	public enum AccountStatus {
		/// <summary>
		/// Account created but not validated yet
		/// </summary>
		PendingValidation = 0,
		/// <summary>
		/// Nothing wrong with this account
		/// </summary>
		Active,
		/// <summary>
		/// Locked for too many failed attempts to login.
		/// </summary>
		LockedTooManyFailedLogins,
		/// <summary>
		/// User has misbehaved
		/// </summary>
		UserFlagged,
		/// <summary>
		/// The system administrator has locked this account for some other reason.
		/// </summary>
		AdminLocked,
	}
}