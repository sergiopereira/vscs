using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using NHibernate.Event;
using NHibernate.Event.Default;
using VSCheatSheets.Model;

namespace VSCheatSheets.Data {
	public class NHibernateAuditSaveListener : DefaultSaveOrUpdateEventListener {
		protected override object PerformSaveOrUpdate(SaveOrUpdateEvent evt) {
			var entity = evt.Entity as Entity;
			if(entity != null) {
				ProcessEntityBeforeInsert(entity, evt.Session);
			}

			return base.PerformSaveOrUpdate(evt);
		}

		internal virtual void ProcessEntityBeforeInsert(Entity entity, IEventSource session) {
			IIdentity identity = Thread.CurrentPrincipal.Identity;

			long userID = identity != null && !string.IsNullOrEmpty(identity.Name)
			              	? long.Parse(identity.Name)
			              	: User.AnonymousUserID;

			Debug.Assert(userID > 0);

			var user = session.Load<User>(userID);
			entity.UpdatedBy = user;
			entity.UpdatedAtUtc = DateTime.UtcNow;

			//the creation audit fields only need to be updated if this is a new object
			if(entity.ID == 0) {
				entity.CreatedBy = user;
				entity.CreatedAtUtc = DateTime.UtcNow;
			}
		}
	}
}