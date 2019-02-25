using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace World.Models
{
    public class City
    {
        private string _name;
        private int _population;
        private string _countryCode;

        public City(string name, int population, string countryCode)
        {
            _name = name;
            _population = population;
            _countryCode = countryCode;
        }

        public string GetName()
        {
            return _name;
        }
        public int GetPopulation()
        {
            return _population;
        }
        public string GetCountryCode()
        {
            return _countryCode;
        }

        public static List<City> GetAllCities()
        {
            List<City> allCities = new List<City> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                string name = rdr.GetString(1);
                int population = rdr.GetInt32(4);
                string countryCode = rdr.GetString(2);
                City newCity = new City(name, population, countryCode);
                allCities.Add(newCity);
            }

            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }

            return allCities;
        }
    }
}