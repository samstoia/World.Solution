using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace World.Models
{
    public class Country
    {
        private string _name;
        private string _continent;
        private int _population;
        private string _region;

        public Country(string name, string continent, int population, string region)
        {
            _name = name;
            _continent = continent;
            _population = population;
            _region = region;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetContinent()
        {
            return _continent;
        }

        public int GetPopulation()
        {
            return _population;
        }

        public string GetRegion()
        {
            return _region;
        }

        public static List<Country> GetAllCountries()
        {
            List<Country> allCountries = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                // int countryId = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string continent = rdr.GetString(2);
                int population = rdr.GetInt32(6);
                string region = rdr.GetString(3);
                Country newCountry = new Country(name, continent, population, region);
                allCountries.Add(newCountry);
            }

            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }

            return allCountries;
        }

    }
}