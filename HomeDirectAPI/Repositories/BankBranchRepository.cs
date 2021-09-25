using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;

namespace HomeDirectAPI.Repositories
{
    public class BankBranchRepository
    {
        private string ConnectionString;

        public BankBranchRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListBankBranchesResponse List()
        {
            ListBankBranchesResponse response = new ListBankBranchesResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.branches = conn.GetList<BankBranch>().ToList();
                    if(response.branches.Count > 0)
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

        public BankBranchesResponse Read(long BranchID)
        {
            BankBranchesResponse response = new BankBranchesResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.branch = conn.Get<BankBranch>(BranchID);
                    if (response.branch != null)
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

        public Response Add(BankBranch value)
        {
            Response response = new Response();
            try
            {
                var exist = List().branches.Where(x => x.BranchName.ToLower() == value.BranchName.ToLower());
                if (exist.Count() > 0)
                {
                    response.Status = false;
                    response.Description = "Record already exists";
                    return response;
                }
                using(IDbConnection conn = GetConnection())
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

        public Response Update(BankBranch value)
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

        public Response Delete(long BranchID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<BankBranch>(BranchID);
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
