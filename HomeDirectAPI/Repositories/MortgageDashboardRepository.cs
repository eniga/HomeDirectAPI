using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace HomeDirectAPI.Repositories
{
    public class MortgageDashboardRepository
    {
        private string ConnectionString;

        public MortgageDashboardRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListMortgageDashboard List()
        {
            ListMortgageDashboard response = new ListMortgageDashboard();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    response.mortgageDashboards = conn.GetList<MortgageDashboard>().ToList();
                    response.Status = true;
                    response.Description = "Successful";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public MortgageDashboardDetails Get(long Year)
        {
            MortgageDashboardDetails response = new MortgageDashboardDetails();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var newdata = conn.GetList<MortgageDashboard>("Where datatype = 'New' and Year = ?Year", new { Year }).FirstOrDefault();
                    var existing = conn.GetList<MortgageDashboard>("Where datatype = 'Existing' and Year = ?Year", new { Year }).FirstOrDefault();
                    response.Status = true;
                    response.Description = "Successful";
                    response.newData = newdata;
                    response.existingData = existing;
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }
    }
}
