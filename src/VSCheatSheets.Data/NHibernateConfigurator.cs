using System;
using FluentNHibernate;
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
					MsSqlConfiguration.MsSql2008.Dialect<MsSql2008Dialect>()
					//SQLiteConfiguration.Standard.Dialect<SQLiteDialect>()
						.ConnectionString(x => x.FromConnectionStringWithKey("CheatSheets"))
				)
				.ProxyFactoryFactory<ProxyFactoryFactory>()
				.Mappings(m => m.AutoMappings.Add(
				          	AutoMap
				          		.AssemblyOf<Entity>().Where(type => !type.IsAbstract && typeof(Entity).IsAssignableFrom(type))
				          		.Conventions.AddFromAssemblyOf<NamingConvention>()
				          		.Conventions.Add(
				          			PrimaryKey.Name.Is(x => "ID"),
				          			DefaultLazy.Always(),
				          			ForeignKey.Format(FormatFkName) //naming for FK  columns							
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

		private static string FormatFkName(Member member, Type type) {
			if (member == null) {
				return type.Name + "ID";
			}

			if(member.Name.EndsWith(type.Name, StringComparison.OrdinalIgnoreCase)){
				return member.Name + "ID";
			}

			return member.Name + type.Name + "ID";
		}
	}
}