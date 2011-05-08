using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace VSCheatSheets.Data.Mappings.Conventions {
	public class TableNamingConvention : IClassConvention {
		public void Apply(IClassInstance instance) {
			instance.Table(Inflector.Net.Inflector.Pluralize(instance.EntityType.Name));
		}
	}
}