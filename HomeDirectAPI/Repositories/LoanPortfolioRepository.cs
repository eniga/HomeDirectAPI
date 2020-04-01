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
    public class LoanPortfolioRepository
    {
        string ConnectionString;

        public LoanPortfolioRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListLoanPortfolioResponse List(DateTime? StartDate = null, DateTime? EndDate = null)
        {
            ListLoanPortfolioResponse response = new ListLoanPortfolioResponse();
            string sql = @"select MortgageBankID BankId, MortgageBank BankName,
                sum(if(paymentstatuteid = 1, 1, 0)) Lost,
                sum(if(paymentstatuteid = 2, 1, 0)) Deliquent,
                sum(if(paymentstatuteid = 3, 1, 0)) 'Default',
                sum(if(paymentstatuteid = 4, 1, 0)) Late,
                sum(if(paymentstatuteid = 5, 1, 0)) Performing
                from loans";
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    if (StartDate.HasValue && EndDate.HasValue)
                    {
                        sql += " where date(LoanDate) between DATE(?StartDate) and date(?EndDate) group by MortgageBankID, MortgageBank";
                        response.loanPortfolios = conn.Query<LoanPortfolio>(sql, new { StartDate, EndDate }).ToList();
                    }
                    else
                    {
                        sql += " group by MortgageBankID, MortgageBank";
                        response.loanPortfolios = conn.Query<LoanPortfolio>(sql).ToList();
                    }
                    var total = new LoanPortfolio()
                    {
                        BankId = 0,
                        BankName = "All Banks",
                        Default = response.loanPortfolios.Sum(x => x.Default),
                        Delinquent = response.loanPortfolios.Sum(x => x.Delinquent),
                        Late = response.loanPortfolios.Sum(x => x.Late),
                        Lost = response.loanPortfolios.Sum(x => x.Lost),
                        Performing = response.loanPortfolios.Sum(x => x.Performing)
                    };
                    response.loanPortfolios.Add(total);
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

        public LoanPortfolioResponse Get(int id)
        {
            LoanPortfolioResponse response = new LoanPortfolioResponse();
            string sql = @"select 
                sum(if(paymentstatuteid = 1, 1, 0)) Lost,
                sum(if(paymentstatuteid = 2, 1, 0)) Deliquent,
                sum(if(paymentstatuteid = 3, 1, 0)) 'Default',
                sum(if(paymentstatuteid = 4, 1, 0)) Late,
                sum(if(paymentstatuteid = 5, 1, 0)) Performing
                from loans where LoanID = ?id";
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.loanPortfolio = conn.Query<LoanPortfolio>(sql, new { id }).FirstOrDefault();
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

        public ListBankTranchesResponse ListBankTranches(int BankId)
        {
            ListBankTranchesResponse response = new ListBankTranchesResponse();
            string sql = @"select CONCAT(LPAD(MONTH(LoanDate),2, '0'), '/', YEAR(LoanDate)) Tranche,
            sum(if(paymentstatuteid = 1, 1, 0)) Lost,
            sum(if(paymentstatuteid = 2, 1, 0)) Deliquent,
            sum(if(paymentstatuteid = 3, 1, 0)) 'Default',
            sum(if(paymentstatuteid = 4, 1, 0)) Late,
            sum(if(paymentstatuteid = 5, 1, 0)) Performing
            from loans where MortgageBankID = ?BankId
            group by CONCAT(LPAD(MONTH(LoanDate),2, '0'), '/', YEAR(LoanDate))";
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    response.tranches = conn.Query<BankTranches>(sql, new { BankId }).ToList();
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
