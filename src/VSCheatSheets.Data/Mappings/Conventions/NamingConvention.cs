using System;
using System.Collections.Generic;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace VSCheatSheets.Data.Mappings.Conventions {
	public class NamingConvention : IClassConvention, IReferenceConvention, IHasManyToManyConvention {

		public void Apply(IClassInstance instance) {
			instance.Table(Inflector.Net.Inflector.Pluralize(instance.EntityType.Name));
		}

		public void Apply(IManyToOneInstance instance) {
			instance.ForeignKey(string.Format("FK_{0}_{1}", instance.EntityType.Name, instance.Name));
		}


		public void Apply(IManyToManyCollectionInstance instance) {
			instance.Table(GetManyToManyTableName(instance.TableName, instance.OtherSide.TableName));
			instance.Relationship.ForeignKey(string.Format("FK_{0}_{1}", instance.TableName, instance.OtherSide.TableName));
	    }

		private string GetManyToManyTableName(string table1, string table2) {
			var names = new List<string>(new[] { table1, table2 });
			names.Sort();
			return string.Join("", names.ToArray());
		}
	}
}