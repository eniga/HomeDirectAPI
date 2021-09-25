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
    public class CustomerRepository
    {
        private string ConnectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListCustomerResponse List()
        {
            ListCustomerResponse response = new ListCustomerResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<Customers>().ToList();
                    if(result.Count > 0)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.customers = result;
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

        public CustomerResponse Read(long CustomerId)
        {
            CustomerResponse response = new CustomerResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var result = conn.Get<Customers>(CustomerId);
                    if(result != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.customer = result;
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

        public CustomerResponse ReadByEmail(string Email)
        {
            CustomerResponse response = new CustomerResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<Customers>("Where Email = ?Email", new { Email }).FirstOrDefault();
                    if (result != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.customer = result;
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

        public CustomerResponse ReadByPhone(string PhoneNumber)
        {
            CustomerResponse response = new CustomerResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<Customers>("Where PhoneNumber = ?PhoneNumber", new { PhoneNumber }).FirstOrDefault();
                    if (result != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.customer = result;
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

        public Response Add(Customers value)
        {
            Response response = new Response();
            try
            {
                var exist = List().customers.Where(x => x.Email.ToLower() == value.Email.ToLower());
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

        public Response Update(Customers value)
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

        public Response Delete(long CustomerId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete(new Customers { CustomerId = CustomerId });
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

        public CustomerResponse Authenticate(Login login)
        {
            CustomerResponse response = new CustomerResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<Customers>("Where Email = ?Email and Password = ?Password", login).FirstOrDefault();
                    if(result != null)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.customer = result;
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
