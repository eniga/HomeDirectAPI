using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;

namespace HomeDirectAPI.Repositories
{
    public class LoanBuyerRepository
    {
        private string ConnectionString;

        public LoanBuyerRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListLoanBuyerResponse List()
        {
            ListLoanBuyerResponse response = new ListLoanBuyerResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.loanbuyers = conn.GetList<LoanBuyer>().ToList();
                    if (response.loanbuyers.Count > 0)
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

        public LoanBuyerResponse Read(long LoanBuyerID)
        {
            LoanBuyerResponse response = new LoanBuyerResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.loanbuyer = conn.Get<LoanBuyer>(LoanBuyerID);
                    if (response.loanbuyer != null)
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

        public Response Add(LoanBuyer value)
        {
            Response response = new Response();
            try
            {
                var exist = List().loanbuyers.Where(x => x.Location.ToLower() == value.Location.ToLower());
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

        public Response Update(LoanBuyer value)
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

        public Response Delete(long LoanBuyerID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<LoanBuyer>(LoanBuyerID);
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
