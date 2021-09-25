using Dapper;
using HomeDirectAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDirectAPI.Repositories
{
    public class UserTypeRepository
    {
        
            private string ConnectionString;

            public UserTypeRepository(IConfiguration configuration)
            {
                ConnectionString = configuration.GetConnectionString("DefaultConnection");
            }

            private MySqlConnection GetConnection()
            {
                SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
                return new MySqlConnection(ConnectionString);
            }

            public ListUserTypeResponse List()
            {
            ListUserTypeResponse response = new ListUserTypeResponse();
                try
                {
                    using (IDbConnection conn = GetConnection())
                    {
                        response.usertypes = conn.GetList<UserTypes>().ToList();
                        if (response.usertypes.Count > 0)
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

            public UserTypeResponse Read(long CatID)
            {
            UserTypeResponse response = new UserTypeResponse();
                try
                {
                    using (IDbConnection conn = GetConnection())
                    {
                        response.usertype = conn.Get<UserTypes>(CatID);
                        if (response.usertype != null)
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

            public Response Add(UserTypes value)
            {
                Response response = new Response();
                try
                {
                var exist = List().usertypes.Where(x => x.TypeName.ToLower() == value.TypeName.ToLower());
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

            public Response Update(UserTypes value)
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

            public Response Delete(long CatID)
            {
                Response response = new Response();
                try
                {
                    using (IDbConnection conn = GetConnection())
                    {
                        conn.Delete<UserCategory>(CatID);
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

