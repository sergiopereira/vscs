using System;
using System.IO;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace VSCheatSheets.Data.Tests {
	public class NHibernateConfiguratorTests {

		[Test, Ignore("Not really a test, just a utility task.")]
		[Category("Utility")]
		public void GenerateDatabaseSchema() {
			Configuration nhibConfig;
			try {
				nhibConfig = NHibernateConfigurator.GetConfiguration();
			} catch (Exception e) {
				Console.Out.WriteLine("ERROR " + e);
				throw;
			}
			string dropDbPath = @"..\..\..\db\drop_db.sql";

			using (var outFile = File.CreateText(dropDbPath))
			using (ISessionFactory sessionFactory = nhibConfig.BuildSessionFactory()) {
				AddHeader(outFile);
				using (ISession session = sessionFactory.OpenSession()) {
					new SchemaExport(nhibConfig).Execute(false, false, true, session.Connection, outFile);
				}
			}
			Console.Out.WriteLine("Drop DB script written to file " + new FileInfo(dropDbPath).FullName);

			string createDbPath = @"..\..\..\db\create_db.sql";
			using (var outFile = File.CreateText(createDbPath))
			using (ISessionFactory sessionFactory = nhibConfig.BuildSessionFactory()) {
				AddHeader(outFile);
				using (ISession session = sessionFactory.OpenSession()) {
					new SchemaExport(nhibConfig).Execute(false, false, false, session.Connection, outFile);
				}
			}
			Console.Out.WriteLine("Create DB script written to file " + new FileInfo(createDbPath).FullName);
			
		}

		private void AddHeader(StreamWriter outFile) {
			outFile.Write("/*\n");
			outFile.Write(" * Created at: " + DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm tt 'UTC'") + "\n");
			outFile.Write(" * Machine: " + System.Environment.MachineName + "\n");
			outFile.Write(" */\n");
		}

		[Test]
		public void ShouldBuildValidConfigurationObject() {
			Configuration configuration = NHibernateConfigurator.GetConfiguration();
			//the existence of mappings is checked in other test(s)
			Assert.IsNotNull(configuration);
		}
	}
}