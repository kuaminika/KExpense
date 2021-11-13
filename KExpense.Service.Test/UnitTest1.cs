using KExpense.Repository.interfaces;
using NUnit.Framework;
namespace KExpense.Service.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGettingAllOrgs()
        {
            
            string connString = "server=localhost;user id=kExpense;persistsecurityinfo=True;database=kExpense; password=kExpense1000";
            AKDBAbstraction db = new Repository.KMysql_KDBAbstraction(connString);
            KExpense.Repository.OrgRepository or = new Repository.OrgRepository(db);
            var r = or.GetAll();

            Assert.IsTrue(r.Count > 0);
        }
        [Test]
        public void TestGettingExpenses()
        {

            string connString = "server=localhost;user id=kExpense;persistsecurityinfo=True;database=kExpense; password=kExpense1000";
            AKDBAbstraction db = new Repository.KMysql_KDBAbstraction(connString);
            KExpense.Repository.interfaces.IKExpenseRepository ker = new KExpense.Repository.KExpenseRepository(db);
            var r = ker.GetAllKExpenses();
            Assert.IsTrue(r.Count > 0);

        }
    }
}