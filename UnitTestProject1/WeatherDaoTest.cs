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
    class WeatherDaoTest
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
            public void Test_Get_Weather_By_Code()
            {
                //Arrange
                IWeatherDao dao = new WeatherDao(ConnectionString);

                IList<Weather> weatherTest = new List<Weather>();
                string testPark = "CVNP";

                //Action
                weatherTest = dao.GetWeather(testPark);

                //Assert
                Assert.AreEqual(GetRowCount("weather", testPark), weatherTest.Count);

            }



            /// <summary>
            /// Gets the row count for a table.
            /// </summary>
            /// <param name="table"></param>
            /// <returns></returns>
            protected int GetRowCount(string table, string parkCode)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table} WHERE parkCode = '{parkCode}';", conn);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }


        }

    }
}
