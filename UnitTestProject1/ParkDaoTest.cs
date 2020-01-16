using Capstone.Web;
using Capstone.Web.DAL;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

namespace CapstoneTests
{
    [TestClass]
    public class ParkDaoTests
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=NPGeek;Trusted_Connection=True;";
        
        ///// <summary>
        /// The transaction for each test.
        /// </summary>
        private TransactionScope transaction;

        [TestInitialize]
        public void Setup()
        {
            // Begin the transaction
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Roll back the transaction
            transaction.Dispose();
        }

        [TestMethod]
        public void Test_Get_Park_By_Code()
        {
            //Arrange
            IParkDao dao = new ParkDao(ConnectionString);

            Park park = new Park();
            string testPark = "CVNP";

            //Action
            park = dao.GetParkByCode(testPark);

            //Assert
            Assert.AreEqual(testPark, park.ParkCode);

        }

        [TestMethod]
        public void Test_Get_All_Parks()
        {
            //Arrange
            IParkDao dao = new ParkDao(ConnectionString);

            IList<Park> testList = new List<Park>();
            testList = dao.GetAllParks();


            //Action
            int results = GetRowCount("park");
            //Assert
            Assert.AreEqual(results, testList.Count);

        }



        /// <summary>
        /// Gets the row count for a table.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }


    }
}


