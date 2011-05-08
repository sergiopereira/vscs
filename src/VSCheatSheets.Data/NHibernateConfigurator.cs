using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Event;
using VSCheatSheets.Data.Mappings.Conventions;
using VSCheatSheets.Model;

namespace VSCheatSheets.Data {
	public class NHibernateConfigurator {
		public static Configuration GetConfiguration() {
			FluentConfiguration fluentConfig = Fluently.Configure()
				.Database(
					SQLiteConfiguration.Standard
						.Dialect<SQLiteDialect>()
						.ConnectionString(x => x.FromConnectionStringWithKey("CheatSheets"))
				)
				.ProxyFactoryFactory<ProxyFactoryFactory>()
				.Mappings(m => m.AutoMappings.Add(
				          	AutoMap
				          		.AssemblyOf<Entity>().Where(type => !type.IsAbstract && typeof(Entity).IsAssignableFrom(type))
				          		.Conventions.AddFromAssemblyOf<TableNamingConvention>()
				          		.Conventions.Add(
				          			PrimaryKey.Name.Is(x => "ID"),
				          			DefaultLazy.Always(),
				          			ForeignKey.EndsWith("ID")
				          		)
				          	))
				.ExposeConfiguration(config => config.Properties.Add("use_proxy_validator", "false"));

			Configuration cfg = fluentConfig.BuildConfiguration();
			cfg.EventListeners.SaveEventListeners = new ISaveOrUpdateEventListener[]{
				new NHibernateAuditSaveListener()
			};
			cfg.EventListeners.SaveOrUpdateEventListeners = new ISaveOrUpdateEventListener[]{
				new NHibernateAuditSaveListener()
			};

			return cfg;
		}
	}
}