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
    public class SurveyDaoTest
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
        public void Test_Submit_Form()
        {
            //Arrange
            Survey surveyTest = new Survey();
            surveyTest.ParkCode = "CVNP";
            surveyTest.Email = "sta@gmail.com";
            surveyTest.ActivityLevel = "Sedentary";
            surveyTest.StateOfResidence = "OH";

            ISurveyDao dao = new SurveyDao(ConnectionString);

            //Action
            bool result = dao.SubmitForm(surveyTest);

            //Assert
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void Test_Get_Survey_Results()
        {
            //Arrange

            ISurveyDao dao = new SurveyDao(ConnectionString);
            IList<SurveyResult> initialList = new List<SurveyResult>();
            initialList = dao.GetSurveyResults();

            SurveyResult initialResult = initialList[0];
            string intialResultParkCode = initialResult.ParkCode;
            int initialResultCount = initialResult.Count;



            Survey surveyTest = new Survey();
            if (initialList == null)
            {
                surveyTest.ParkCode = "CVNP";
                initialResultCount = 0;
            }
            else
            {
                surveyTest.ParkCode = intialResultParkCode;
            }

            surveyTest.Email = "sta@gmail.com";
            surveyTest.ActivityLevel = "Sedentary";
            surveyTest.StateOfResidence = "OH";
            dao.SubmitForm(surveyTest);


            //Action
            IList<SurveyResult> surveyResult = new List<SurveyResult>();
            surveyResult = dao.GetSurveyResults();
            int testResultCount = surveyResult[0].Count;
            //Assert
            Assert.AreEqual(initialResultCount + 1, testResultCount);

        }
    }
}

