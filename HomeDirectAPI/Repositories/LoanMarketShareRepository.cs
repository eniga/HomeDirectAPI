using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;

namespace HomeDirectAPI.Repositories
{
    public class LoanMarketShareRepository
    {
        private string ConnectionString;

        public LoanMarketShareRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListLoanMarketShareResponse List(DateTime? StartDate, DateTime? EndDate)
        {
            ListLoanMarketShareResponse response = new ListLoanMarketShareResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    if (StartDate.HasValue && EndDate.HasValue)
                    {
                        response.loanmarketshares = conn.GetList<LoanMarketShare>("where convert(loandate, date) between convert(?StartDate, date) and convert(?EndDate, date)", new { StartDate, EndDate }).ToList();
                    }
                    else
                    {
                        response.loanmarketshares = conn.GetList<LoanMarketShare>().ToList();
                    }
                    if (response.loanmarketshares.Count > 0)
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

        public LoanMarketShareResponse Read(long ShareID)
        {
            LoanMarketShareResponse response = new LoanMarketShareResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.loanmarketshare = conn.Get<LoanMarketShare>(ShareID);
                    if (response.loanmarketshare != null)
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

        public Response Add(LoanMarketShare value)
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

        public Response Update(LoanMarketShare value)
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

        public Response Delete(long ShareID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<LoanMarketShare>(ShareID);
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
