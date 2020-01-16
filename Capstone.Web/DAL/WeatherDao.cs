using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherDao : IWeatherDao
    {

        private readonly string connectionString;

        public WeatherDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private string sql_weather = "SELECT * FROM weather WHERE parkCode = @parkCode ORDER BY fiveDayForecastValue;";

        public IList<Weather> GetWeather(string parkCode)
        {
            List<Weather> weather = new List<Weather>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sql_weather, connection);
                command.Parameters.AddWithValue("@parkcode", parkCode);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    weather.Add(new Weather
                    {
                        ParkCode = Convert.ToString(reader["parkCode"]),
                        ForecastValue = Convert.ToInt32(reader["fiveDayForeCastValue"]),
                        LowTemp = Convert.ToInt32(reader["low"]),
                        HighTemp = Convert.ToInt32(reader["high"]),
                        Forecast = Convert.ToString(reader["forecast"]),
                    });
                }
            }

            return weather;
        }
    }
}
