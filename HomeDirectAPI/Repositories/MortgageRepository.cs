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
    public class MortgageRepository
    {
        private string ConnectionString;

        public MortgageRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }
        //DateTime? StartDate, DateTime? EndDate
        public ListMortgageLoanResponse List()
        {
            ListMortgageLoanResponse response = new ListMortgageLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.applications = conn.GetList<MortgageLoanApplication>().ToList();
                    //if (StartDate.HasValue && EndDate.HasValue)
                    //{
                    //    response.mortgageapplications = conn.GetList<MortgageApplication>("where convert(loandate, date) between convert(?StartDate, date) and convert(?EndDate, date)", new { StartDate, EndDate }).ToList();
                    //}
                    //else
                    //{
                        
                    //}
                    if (response.applications.Count > 0)
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

        public MortgageLoanResponse Read(int MortgageLoanID)
        {
            MortgageLoanResponse response = new MortgageLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.application = conn.Get<MortgageLoanApplication>(MortgageLoanID);
                    if (response.application != null)
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
        

        public ListMortgageLoanResponse GetLoanByEmail(string email)
        {
            ListMortgageLoanResponse response = new ListMortgageLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.applications= conn.Query<MortgageLoanApplication>(" SELECT * FROM hdldb.MortgageLoanApplication where Email= ?Email ", new { email }).ToList();
                    if (response.applications.Count > 0)
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
        public MortgageResponse Add(MortgageLoanApplication value)
        {
            MortgageResponse response = new MortgageResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var id = conn.Insert(value);
                    response.MortgageId = id.Value;
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

        public Response Update(MortgageLoanApplication value)
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

        public Response Delete(int MortgageLoanID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<MortgageApplication>(MortgageLoanID);
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

        public ListMortgageLoanResponse GetLoanByUserID(int UserID)
        {
            ListMortgageLoanResponse response = new ListMortgageLoanResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.applications = conn.GetList<MortgageLoanApplication>("where UserID = ?UserID", new { UserID }).ToList();
                    if (response.applications.Count > 0)
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

        public Response UpdateMortgageStatus(UpdateLoanStatus value)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    response = ApproveTask(value);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public Response ApproveTask(UpdateLoanStatus value)
        {
            Response response = new Response();
            string sql = "UPDATE mortgageloanapplication SET LoanStatus = ?LoanStatus, ApprovedDate =?ApprovedDate Where MortgageLoanID = ?MortgageLoanID";
            
            using(IDbConnection conn = GetConnection())
            {
                if (value.LoanStatus.Contains("Approved"))
                {
                    conn.Open();
                    var tran = conn.BeginTransaction();
                    try
                    {
                        var mortgage = conn.Get<MortgageLoanApplication>(value.MortgageLoanID);
                        var banks = conn.Get<Bank>(mortgage.BankID);
                        var status = conn.Get<LoanStatuses>(4);
                        var paymentstatute = conn.Get<PaymentStatutes>(5);
                        var loan = new Loans()
                        {
                            DateApproved = mortgage.ApprovedDate.HasValue ? mortgage.ApprovedDate.Value : DateTime.Now,
                            DateCreated = DateTime.Now,
                            LoanAmount = Convert.ToDecimal(mortgage.AmountBorrowed),
                            LoanBuyerStatus = mortgage.LoanStatus,
                            LoanBuyerStatusID = 1,
                            LoanDate = mortgage.LoanDate.Value,
                            LoanStatus = status.LoanStatus,
                            MortgageBank = banks.BankName,
                            TitleHolder = mortgage.FullName,
                            PropertyID = long.Parse(mortgage.ProID),
                            UserID = mortgage.UserID,
                            MortgageBankID = int.Parse(mortgage.BankID),
                            Timeline = int.Parse(mortgage.Paymentterms),
                            PerformanceRating = 100M,
                            Repayments = int.Parse(mortgage.Paymentterms),
                            LoanStatusID = status.LoanStatusID,
                            PaymentStatuteID = paymentstatute.PaymentStatuteID,
                            PaymentStatute = paymentstatute.PaymentStatute,
                            Score = 100M,
                            ApplicationID = mortgage.ApplicationID,
                            MortgageType = mortgage.MortgageType
                        };
                        var loanID = conn.Insert(loan);
                        decimal rate = decimal.Parse("100.00");
                        var rating = new LoanRating()
                        {
                            LoanID = loanID.Value,
                            Rating = rate,
                            RatingDesc = "Performing"
                        };
                        conn.Insert(rating);
                        var loanDocs = conn.GetList<MorgageLoanDocs>("Where MortgageLoanID = ?MortgageLoanID", new { value.MortgageLoanID }).AsList();
                        loanDocs.ForEach(item =>
                        {
                            var loandoc = new LoanDoc()
                            {
                                DocDesc = item.DocsDesc,
                                DocLink = item.DocsLink,
                                DocName = item.DocsName,
                                LoanID = loanID.Value,
                                MortgageId = value.MortgageLoanID
                            };
                            conn.Insert(loandoc);
                        });
                        // insert into repayment history
                        var uus = conn.Get<UUSBanks>(loan.MortgageBankID);
                        decimal totalrepayment = loan.LoanAmount * (1 + ((uus.InterestRate /100) * (loan.Timeline / 12)));
                        decimal monthly = totalrepayment / loan.Timeline;
                        int duration = 0;
                        while (duration < loan.Timeline)
                        {
                            duration++;
                            var repayment = new RepaymentHistory()
                            {
                                InterestRate = uus.InterestRate,
                                Amount = monthly,
                                LoanID = loanID.Value,
                                Outstanding = totalrepayment - (monthly * duration),
                                Repayment = "Unpaid",
                                DueDate = loan.LoanDate.AddMonths(duration).ToLongDateString(),
                                TransactionDate = loan.LoanDate.AddMonths(duration)
                            };
                            conn.Insert(repayment);
                        }
                        var req = new UpdateLoanStatus2()
                        {
                            ApprovedDate = mortgage.ApprovedDate.HasValue ? mortgage.ApprovedDate.Value : DateTime.Now,
                            LoanStatus = value.LoanStatus,
                            MortgageLoanID = value.MortgageLoanID
                        };
                        conn.Execute(sql, req);
                        response.Status = true;
                        response.Description = "Successful";
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        response.Status = false;
                        response.Description = ex.Message;
                    }
                }
                else
                {
                    conn.Execute(sql, value);
                    response.Status = true;
                    response.Description = "Successful";
                }
            }
            return response;
        }
    }
}
