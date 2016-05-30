using NUnit.Framework;

namespace AkkaSqlPersistenceIssue.Tests
{
    class Sql_journal_test : Journal_availability_for_persistent_actor_for_test_akka_system
    {
        [Test]
        public void Journal_is_sql()
        {
            Assert.AreEqual("akka.persistence.journal.sql-server", _journalName);
        }

        public Sql_journal_test(string config) : base(config)
        {
        }
    }
}