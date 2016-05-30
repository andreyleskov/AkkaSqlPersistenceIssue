namespace AkkaSqlPersistenceIssue.Tests
{
    class SqlJournal_fails_test : Sql_journal_test
    {   //Some real connection strings
        private static readonly string SqlPersistenceConfiguration = @"
akka.persistence{
                journal {
                  plugin = ""akka.persistence.journal.sql-server""
                  sql-server {
                      class = ""Akka.Persistence.SqlServer.Journal.SqlServerJournal, Akka.Persistence.SqlServer""
                      schema-name = dbo
                      auto-initialize = on
                      connection-string = ""Data Source=(LocalDB)\\v11.0;Initial Catalog=AutoTestAkka;Integrated Security= True""
                  }
                }

                snapshot-store{
                    plugin = ""akka.persistence.snapshot-store.sql-server""
                    sql-server {
                        class = ""Akka.Persistence.SqlServer.Snapshot.SqlServerSnapshotStore, Akka.Persistence.SqlServer""
                        schema-name = dbo
                        auto-initialize = on
                        connection-string = ""Data Source=(LocalDB)\\v11.0;Initial Catalog=AutoTestAkka;Integrated Security= True""
                    }
                }
}";
   

        public SqlJournal_fails_test() : base(SqlPersistenceConfiguration)
        {
          
        }
    }
}