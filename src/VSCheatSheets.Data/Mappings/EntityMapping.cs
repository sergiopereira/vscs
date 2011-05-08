using System;
using System.Linq.Expressions;
using FluentNHibernate.Mapping;
using VSCheatSheets.Model;

namespace VSCheatSheets.Data.Mappings {
	public abstract class EntityMapping<T> : ClassMap<T> where T : Entity {


		protected EntityMapping()
		{
			//MapIdentity();
			if (Audited)
			{
				//NOTE: I wish we could move the audit columns to the end of the table
				//	but the reference properties will also be added after (at least as of
				//  the FNH version 0.1.0.528
				MapStandardAuditingProperties();
			}
			MapProperties();
		} 

		public virtual bool Audited { get { return true; } }

		//protected virtual void MapIdentity()
		//{
		//    Id(x => x.Id).GeneratedBy.Identity().Column(EntityType.Name + "ID");
		//}

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
				.Column(FluentNHibernate.Utils.Reflection.ReflectionHelper.GetAccessor(expression).Name + "ID")
				.ForeignKey();
		}


	}
}