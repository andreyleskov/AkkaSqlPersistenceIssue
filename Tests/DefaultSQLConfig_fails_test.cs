using NUnit.Framework;

namespace AkkaSqlPersistenceIssue.Tests
{
    class DefaultSQLConfig_fails_test : Sql_journal_test
    {
        //intentionally connection string was empty for getting any kind of connection-related error
        private static readonly string cfg = @"{
  akka : {
    persistence : {
                  journal : {
                    plugin = ""akka.persistence.journal.sql-server""
                    sql-server : {
                      class : ""Akka.Persistence.SqlServer.Journal.SqlServerJournal, Akka.Persistence.SqlServer""
                      plugin-dispatcher : akka.actor.default-dispatcher
                      connection-string : 
                      connection-timeout : 30s
                      schema-name : dbo
                      table-name : EventJournal
                      auto-initialize : off
                      timestamp-provider :""Akka.Persistence.Sql.Common.Journal.DefaultTimestampProvider, Akka.Persistence.Sql.Common""
                            }
                    }
        snapshot-store : {
                plugin = ""akka.persistence.snapshot-store.sql-server""
                sql-server : {
                  class : ""Akka.Persistence.SqlServer.Snapshot.SqlServerSnapshotStore, Akka.Persistence.SqlServer""
                  plugin-dispatcher : akka.actor.default-dispatcher
                  connection-string : 
                  connection-timeout : 30s
                  schema-name : dbo
                  table-name : SnapshotStore
                  auto-initialize : off
                }
              }
    }
  }
}
";

        public DefaultSQLConfig_fails_test() : base(cfg)
        {
//            //Tryed to do some magic but no use
//           var persistence = new SqlServerPersistenceProvider();
//           persistence.Apply(Sys);
////# var sqlPersistence = new SqlServerPersistence(Sys);

//            var persistence = Persistence.Instance;
//            persistence.Apply(Sys);
        }
    }
}