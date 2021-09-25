using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;

namespace HomeDirectAPI.Repositories
{
    public class BankRepository
    {
        private string ConnectionString;

        public BankRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListBankResponse List()
        {
            ListBankResponse response = new ListBankResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.banks = conn.GetList<Bank>().ToList();
                    if (response.banks.Count > 0)
                    {
                        int i = 0;
                        while (i < response.banks.Count)
                        {
                            var id = response.banks[i].BankAdminUserID;
                            var user = conn.Get<User>(id);
                            if(user != null)
                                response.banks[i].BankAdminUser = user.FullName;
                            i++;
                        }
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

        public BankResponse Read(long BankID)
        {
            BankResponse response = new BankResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.bank = conn.Get<Bank>(BankID);
                    if (response.bank != null)
                    {
                        var user = conn.Get<User>(response.bank.BankAdminUserID);
                        if (user != null)
                            response.bank.BankAdminUser = user.FullName;
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

        public Response Add(Bank value)
        {
            Response response = new Response();
            try
            {
                var exist = List().banks.Where(x => x.BankName.ToLower() == value.BankName.ToLower());
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

        public Response Update(Bank value)
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

        public Response Delete(long BankID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Bank>(BankID);
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
