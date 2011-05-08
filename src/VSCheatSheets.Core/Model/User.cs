using System;

namespace VSCheatSheets.Model
{
    public class User : Entity
    {
        public virtual string Email { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string HomePageUrl { get; set; }
        public virtual string TwitterName { get; set; }
        public virtual DateTime  JoinedAt { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }
        public virtual AccountStatus Status { get; set; }
        public virtual DateTime LastLoginAt { get; set; }
        public virtual int FailedLoginCount { get; set; }
        /// <summary>
        /// Notes about the user. Only visible by the administrator.
        /// </summary>
        public virtual string AdminNotes { get; set; }
    }

    public enum AccountStatus
    {
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