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
    public class LoanRepository
    {
        private string ConnectionString;

        public LoanRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListLoanResponse List(DateTime? StartDate, DateTime? EndDate)
        {
            ListLoanResponse response = new ListLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    if(StartDate.HasValue && EndDate.HasValue)
                    {
                        response.loans = conn.GetList<Loans>("where convert(loandate, date) between convert(?StartDate, date) and convert(?EndDate, date)", new { StartDate, EndDate }).ToList();
                    } else
                    {
                        response.loans = conn.GetList<Loans>().ToList();
                    }
                    
                    if (response.loans.Count > 0)
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

        public LoanResponse Read(int LoanID)
        {
            LoanResponse response = new LoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.loan = conn.Get<Loans>(LoanID);
                    if (response.loan != null)
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

        public Response Add(Loans value)
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

        public Response Update(Loans value)
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

        public Response Delete(int LoanID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Loans>(LoanID);
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

        public PendingLoanResponse PendingApplications()
        {
            PendingLoanResponse response = new PendingLoanResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    response.NumberOfPending = conn.RecordCount<int>("where LoanStatusID = 1");
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

        public PendingLoanResponse PendingByBank(int BankID)
        {
            PendingLoanResponse response = new PendingLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.NumberOfPending = conn.RecordCount<int>("where LoanStatusID = 1 and MortgageBankID = ?BankID", BankID);
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

        public PendingLoanResponse TransmittedLoans()
        {
            PendingLoanResponse response = new PendingLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.NumberOfPending = conn.RecordCount<int>("where LoanStatusID = 2");
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

        public ListLoanResponse Repaid(DateTime? StartDate, DateTime? EndDate)
        {
            ListLoanResponse response = new ListLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    if (StartDate.HasValue && EndDate.HasValue)
                    {
                        response.loans = conn.GetList<Loans>("where LoanStatusID = 8 and convert(loandate, date) between convert(?StartDate, date) and convert(?EndDate, date)", new { StartDate, EndDate }).ToList();
                    }
                    else
                    {
                        response.loans = conn.GetList<Loans>("where LoanStatusID = 8").ToList();
                    }
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

        public ListLoanResponse RecentLoanRepayments(DateTime? StartDate, DateTime? EndDate)
        {
            ListLoanResponse response = new ListLoanResponse();
            ListRepaymentHistoryResponse list = new ListRepaymentHistoryResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    string condition = StartDate.HasValue && EndDate.HasValue ? "where convert(loandate, date) between convert(?StartDate, date) and convert(?EndDate, date)" : null;
                    list.repayments = conn.GetListPaged<RepaymentHistory>(1, 5, condition, "TransactionDate desc", new { StartDate, EndDate }).ToList();
                    List<Loans> loans = new List<Loans>();
                    list.repayments.ForEach(item =>
                    {
                        Loans loan = new Loans();
                        loan = conn.Get<Loans>(item.LoanID);
                        loans.Add(loan);
                    });
                    if (loans.Count > 0)
                    {
                        response.Status = true;
                        response.Description = "Successful";
                        response.loans = loans;
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

        public ListLoanResponse GetByBank(int bankId, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            ListLoanResponse response = new ListLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    if (StartDate.HasValue && EndDate.HasValue)
                    {
                        response.loans = conn.GetList<Loans>("where MortgageBankID = ?bankId, convert(loandate, date) between convert(?StartDate, date) and convert(?EndDate, date)", new { bankId, StartDate, EndDate }).ToList();
                    }
                    else
                    {
                        response.loans = conn.GetList<Loans>("where MortgageBankID = ?bankId", new { bankId }).ToList();
                    }

                    if (response.loans.Count > 0)
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
