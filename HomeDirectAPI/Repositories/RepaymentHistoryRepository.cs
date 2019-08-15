using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;

namespace HomeDirectAPI.Repositories
{
    public class RepaymentHistoryRepository
    {
        private string ConnectionString;

        public RepaymentHistoryRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListRepaymentHistoryResponse List(int LoanId)
        {
            ListRepaymentHistoryResponse response = new ListRepaymentHistoryResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.repayments = conn.GetList<RepaymentHistory>("where loanid = ?LoanId", new { LoanId }).ToList();
                    if (response.repayments.Count > 0)
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

        public RepaymentHistoryResponse Read(int RepaymentID)
        {
            RepaymentHistoryResponse response = new RepaymentHistoryResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.repayment = conn.Get<RepaymentHistory>(RepaymentID);
                    if (response.repayment != null)
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

        public Response Add(RepaymentHistory value)
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

        public Response Update(RepaymentHistory value)
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

        public Response Delete(int RepaymentID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<RepaymentHistory>(RepaymentID);
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

        public TotalRepaymentsResponse TotalRepayment()
        {
            TotalRepaymentsResponse response = new TotalRepaymentsResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    decimal total = conn.Query<decimal>("select COALESCE(SUM(Amount), 0) Total from RepaymentHistory").FirstOrDefault();
                    response.Status = true;
                    response.Description = "Successful";
                    response.totalRepayments = total;
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public ListRepaymentHistoryResponse RecentRepayments()
        {
            ListRepaymentHistoryResponse response = new ListRepaymentHistoryResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.repayments = conn.GetListPaged<RepaymentHistory>(1, 5, null, "TransactionDate desc").ToList();
                    if (response.repayments.Count > 0)
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
    }
}
