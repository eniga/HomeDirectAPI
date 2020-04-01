using System;
using System.Data;
using System.Linq;
using Dapper;
using HomeDirectAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace HomeDirectAPI.Repositories
{
    public class BookmarksRepository
    {
        private string ConnectionString;

        public BookmarksRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListBookmarksResponse List()
        {
            ListBookmarksResponse response = new ListBookmarksResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.data = conn.GetList<Bookmarks>().ToList();

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

        public BookmarksResponse Read(int ID)
        {
            BookmarksResponse response = new BookmarksResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.data = conn.Get<Bookmarks>(ID);
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

        public Response Add(Bookmarks value)
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

        public Response Update(Bookmarks value)
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
                    conn.Delete<Bookmarks>(ID);
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
