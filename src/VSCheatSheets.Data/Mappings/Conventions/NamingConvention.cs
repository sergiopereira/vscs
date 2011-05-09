using System;
using System.Collections.Generic;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace VSCheatSheets.Data.Mappings.Conventions {
	public class NamingConvention : IClassConvention, IReferenceConvention, IHasManyToManyConvention, IHasManyConvention {

		/// <summary>
		/// The naming convention for tables
		/// </summary>
		/// <param name="instance"></param>
		public void Apply(IClassInstance instance) {
			instance.Table(Inflector.Net.Inflector.Pluralize(instance.EntityType.Name));
		}

		/// <summary>
		/// The naming convention for FK constraints
		/// </summary>
		/// <param name="instance"></param>
		public void Apply(IManyToOneInstance instance) {
			instance.ForeignKey(string.Format("FK_{0}_{1}", instance.EntityType.Name, instance.Name));
		}

		/// <summary>
		/// The naming convention for many-to-many tables and constraints
		/// </summary>
		/// <param name="instance"></param>
		public void Apply(IManyToManyCollectionInstance instance) {
			instance.Table(GetManyToManyTableName(instance.TableName, instance.OtherSide.TableName));
			instance.Relationship.ForeignKey(string.Format("FK_{0}_{1}", instance.TableName, instance.OtherSide.TableName));
	    }

		private string GetManyToManyTableName(string table1, string table2) {
			var names = new List<string>(new[] { table1, table2 });
			names.Sort();
			return string.Join("", names.ToArray());
		}

		/// <summary>
		/// The naming convention for the one-to-many relationships
		/// </summary>
		/// <param name="instance"></param>
		public void Apply(IOneToManyCollectionInstance instance) {
			Console.Out.WriteLine("entity " + instance.EntityType.Name);
			Console.Out.WriteLine("member " + instance.Member.Name);
		}
	}
}