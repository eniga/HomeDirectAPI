using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;

namespace HomeDirectAPI.Repositories
{
    public class LoanRepaymentRepository
    {
        private string ConnectionString;

        public LoanRepaymentRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListLoanRepaymentResponse List()
        {
            ListLoanRepaymentResponse response = new ListLoanRepaymentResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    response.list = conn.GetList<LoanRepayment>().ToList();
                    if (response.list.Count > 0)
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

        public ListLoanRepaymentResponse BankList(long BankId)
        {
            ListLoanRepaymentResponse response = new ListLoanRepaymentResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.list = conn.GetList<LoanRepayment>(BankId).ToList();
                    if (response.list.Count > 0)
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

        public LoanRepaymentResponse Read(long RepaymentId)
        {
            LoanRepaymentResponse response = new LoanRepaymentResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    response.repayment = conn.Get<LoanRepayment>(RepaymentId);
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

        public Response Add(LoanRepayment repayment)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Insert(repayment);
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

        public Response Update(LoanRepayment repayment)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update(repayment);
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

        public Response Delete(long RepaymentId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete(RepaymentId);
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
