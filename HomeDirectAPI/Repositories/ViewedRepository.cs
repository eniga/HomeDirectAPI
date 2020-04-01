using System;
using System.Data;
using System.Linq;
using Dapper;
using HomeDirectAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace HomeDirectAPI.Repositories
{
    public class ViewedRepository
    {
        private string ConnectionString;

        public ViewedRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListViewedResponse List()
        {
            ListViewedResponse response = new ListViewedResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.data = conn.GetList<Viewed>().ToList();

                    if (response.data.Count > 0)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                    }
                    else
                    {
                        response.Status = false;
                        response.Description = "No data";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public ViewedResponse Read(int ID)
        {
            ViewedResponse response = new ViewedResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.data = conn.Get<Viewed>(ID);
                    if (response.data != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                    }
                    else
                    {
                        response.Status = false;
                        response.Description = "No data";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public Response Add(Viewed value)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Insert(value);
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

        public Response Update(Viewed value)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update(value);
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

        public Response Delete(int ID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Viewed>(ID);
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
    }
}
