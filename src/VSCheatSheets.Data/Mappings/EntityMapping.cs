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
using System.Linq.Expressions;
using FluentNHibernate.Mapping;
using FluentNHibernate.Utils.Reflection;
using VSCheatSheets.Model;

namespace VSCheatSheets.Data.Mappings {
	
	public abstract class EntityMapping<T> : ClassMap<T> where T : Entity {
		protected EntityMapping()
		{
			MapIdentity();
			if (Audited)
			{
				//NOTE: I wish we could move the audit columns to the end of the table
				//	but the reference properties will also be added after (at least as of
				//  the FNH version 0.1.0.528
				MapStandardAuditingProperties();
			}
			MapProperties();
		}

		protected virtual void MapIdentity() {
			Id(x => x.ID).GeneratedBy.Identity();//.Column(EntityType.Name + "ID");
		}

		public virtual bool Audited { get { return true; } }

		protected abstract void MapProperties();

		protected void MapStandardAuditingProperties()
		{
			MapReference(x => x.CreatedBy).Not.Nullable();
			Map(x => x.CreatedAtUtc).Not.Nullable();
			MapReference(x => x.UpdatedBy).Not.Nullable();
			Map(x => x.UpdatedAtUtc).Not.Nullable();
		}

		public ManyToOnePart<TOther> MapReference<TOther>(Expression<Func<T, TOther>> expression) {
			return References(expression)
				.Column(ReflectionHelper.GetAccessor(expression).Name + "ID")
				.ForeignKey();
		}


	}
}