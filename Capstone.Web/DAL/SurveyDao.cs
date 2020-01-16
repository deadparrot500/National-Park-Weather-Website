using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyDao : ISurveyDao
    {

        private readonly string connectionString;
        private string Sql_submit = @"INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES(@parkCode, @emailAddress, @state, @activityLevel);";
        private string Sql_results = "SELECT COUNT(surveyId) count, survey_result.parkCode, parkName FROM survey_result JOIN park ON survey_result.parkCode = park.parkCode GROUP BY parkName, survey_result.parkCode; ";

        public SurveyDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool SubmitForm(Survey survey)
        {
            bool result = false;
            int affected = 0;
        
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql_submit, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.StateOfResidence);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    affected = cmd.ExecuteNonQuery();
                }
            

            if (affected >= 1)
            {
                result = true;
            }
            return result;
        }

        public IList<SurveyResult> GetSurveyResults()
        {
            IList<SurveyResult> surveys = new List<SurveyResult>();
            
           
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql_results, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                    SurveyResult surveyResult = new SurveyResult();

                    surveyResult.ParkCode = Convert.ToString(reader["parkCode"]);
                    surveyResult.Count = Convert.ToInt32(reader["count"]);
                    surveyResult.ParkName = Convert.ToString(reader["parkName"]);


                    surveys.Add(surveyResult);
                    }
                }
            
            return surveys;

        }


    }
}
