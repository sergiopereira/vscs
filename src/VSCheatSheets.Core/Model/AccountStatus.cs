#region Copyright notice
// Copyright (c) 2011, Sergio Pereira, sergiopereira.com
// 
// The author doesn't speak legalese and doesn't want to even hear about it.
// Anyone is free to use this code as they wish as long as they assume total responsibility of such use and any damages caused by it.
// The author doesn't even care if you steal this code and never give proper attribution. 
// 
// THIS CODE WANTS TO BE FREE
#endregion
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