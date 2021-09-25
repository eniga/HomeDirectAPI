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
    public class DeveloperRepository
    {
        private string ConnectionString;

        public DeveloperRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListDeveloperResponse List()
        {
            ListDeveloperResponse response = new ListDeveloperResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<Developers>().ToList();
                    if (result.Count > 0)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.developers = result;
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

        public DeveloperResponse Read(long DeveloperId)
        {
            DeveloperResponse response = new DeveloperResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var result = conn.Get<Developers>(DeveloperId);
                    if (result != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.developer = result;
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

        public DeveloperResponse ReadByEmail(string Email)
        {
            DeveloperResponse response = new DeveloperResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<Developers>("Where Email = ?Email", new { Email }).FirstOrDefault();
                    if (result != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.developer = result;
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

        public DeveloperResponse ReadByPhone(string PhoneNumber)
        {
            DeveloperResponse response = new DeveloperResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<Developers>("Where PhoneNumber = ?PhoneNumber", new { PhoneNumber }).FirstOrDefault();
                    if (result != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.developer = result;
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

        public Response Add(Developers value)
        {
            Response response = new Response();
            try
            {
                var exist = List().developers.Where(x => x.Email.ToLower() == value.Email.ToLower());
                if (exist.Count() > 0)
                {
                    response.Status = false;
                    response.Description = "Record already exists";
                    return response;
                }
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

        public Response Update(Developers value)
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

        public Response Delete(long DeveloperId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Developers>(new Developers { DeveloperID = DeveloperId.ToString() });
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

        public DeveloperResponse Authenticate(Login login)
        {
            DeveloperResponse response = new DeveloperResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<Developers>("Where Email = ?Email and Password = ?Password", login).FirstOrDefault();
                    if (result != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.developer = result;
                    }
                    else
                    {
                        response.Status = false;
                        response.Description = "Invalid Email / Password";
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
    }
}
