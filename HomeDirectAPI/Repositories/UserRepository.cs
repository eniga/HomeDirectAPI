using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;

namespace HomeDirectAPI.Repositories
{
    public class UserRepository
    {
        private string ConnectionString;

        public UserRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListUserResponse List()
        {
            ListUserResponse response = new ListUserResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.users = conn.GetList<User>().ToList();
                    if (response.users.Count > 0)
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

        public UserResponse Read(int UserID)
        {
            UserResponse response = new UserResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.user = conn.Get<User>(UserID);
                    if (response.user != null)
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

        public UserResponse Authenticate(string email, string password)
        {
            UserResponse response = new UserResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.user = conn.Query<User>("SELECT * FROM hdldb.Users where Email= ?Email and Password= ?Password ", new { email, password }).FirstOrDefault();
                    if (response.user != null)
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

        public UserResponse GetUserByEmail(string email)
        {
            UserResponse response = new UserResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.user = conn.Query<User>("SELECT * FROM hdldb.Users where Email= ?email ", new { email }).FirstOrDefault();
                    if (response.user != null)
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

        public Response Add(User value)
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

        public Response Update(User value)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    string pass = conn.Get<User>(value.UserID).Password;
                    value.Password = pass;
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

        public Response Delete(int UserID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<User>(UserID);
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
