using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkDao : IParkDao
    {

        private readonly string connectionString;

        private readonly string sql_GetAllParks = "SELECT * FROM park";
        private readonly string sql_GetById = "SELECT * FROM park WHERE parkCode = @parkCode";


        public ParkDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetAllParks()
        {
            IList<Park> parks = new List<Park>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql_GetAllParks;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    parks.Add(new Park
                    {
                        ParkCode = Convert.ToString(reader["parkCode"]),
                        ParkName = Convert.ToString(reader["parkName"]),
                        State = Convert.ToString(reader["state"]),
                        Acreage = Convert.ToInt32(reader["acreage"]),
                        ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                        MilesOfTrails = Convert.ToInt32(reader["milesOfTrail"]),
                        NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                        Climate = Convert.ToString(reader["climate"]),
                        YearFounded = Convert.ToInt32(reader["yearFounded"]),
                        AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                        InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                        InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                        ParkDescription = Convert.ToString(reader["parkDescription"]),
                        EntryFee = Convert.ToInt32(reader["entryFee"]),
                        NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
                    });
                }
            }

            return parks;
        }

        public Park GetParkByCode(string parkCode)
        {
            Park park = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql_GetById, connection);
                    command.Parameters.AddWithValue("@parkcode", parkCode);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        park = MapRowToPark(reader);
                    }

                    return park;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkCode = Convert.ToString(reader["parkCode"]);
            park.ParkName = Convert.ToString(reader["parkName"]);
            park.State = Convert.ToString(reader["state"]);
            park.Acreage = Convert.ToInt32(reader["acreage"]);
            park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
            park.MilesOfTrails = Convert.ToInt32(reader["milesOfTrail"]);
            park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
            park.Climate = Convert.ToString(reader["climate"]);
            park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
            park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
            park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            park.ParkDescription = Convert.ToString(reader["parkDescription"]);
            park.EntryFee = Convert.ToInt32(reader["entryFee"]);
            park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return park;
        }
    }
}
