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
            var sql = "Insert into MortgageLoanApplication" +
"(UserID, ProID, ProName, MortgageType, AmountBorrowed, MortgageCategory, Paymentterms, FirstName, LastName, DOB, Email, PhoneNumber, CustomerBank, EmploymentStatus," +
"NumberOfDependants, AnnualIncome, PrefferedFinInst, ContactConsent, StatutoryAcceptanceConsent, BusinessTermsConsent, AuthorisationConsent, LoanDate, CreatedDate, ApprovedDate)" +
       " values" +
          "(?UserID, ?ProID, ?ProName, ?MortgageType, ?AmountBorrowed, ?MortgageCategory, ?Paymentterms, ?FirstName, ?LastName, ?DOB, ?Email, ?PhoneNumber, ?CustomerBank, ?EmploymentStatus," +
"?NumberOfDependants, ?AnnualIncome, ?PrefferedFinInst, ?ContactConsent, ?StatutoryAcceptanceConsent, ?BusinessTermsConsent, ?AuthorisationConsent, ?LoanDate, ?CreatedDate, ?ApprovedDate);" +
 
"select LAST_INSERT_ID();";
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                  var id=  conn.Query<int>(sql, new
                  {
                       @UserID = value.UserID,
                       @ProID= value.ProID,
                       @ProName= value.ProName,
                      @MortgageType = value.MortgageType,
                       @AmountBorrowed= value.AmountBorrowed,
                       @MortgageCategory= value.MortgageCategory,
                      @Paymentterms = value.Paymentterms,
                       @FirstName =value.FirstName,
                      @LastName=  value.LastName,
                       @DOB= value.DOB,
                      @Email=  value.Email,
                      @PhoneNumber = value.PhoneNumber,
                      @CustomerBank=  value.CustomerBank,
                       @EmploymentStatus =value.EmploymentStatus,
                       @NumberOfDependants= value.NumberOfDependants,
                       @AnnualIncome =value.AnnualIncome,
                       @PrefferedFinInst= value.PrefferedFinInst,
                       @ContactConsent= value.ContactConsent,
                       @StatutoryAcceptanceConsent= value.StatutoryAcceptanceConsent,
                       @BusinessTermsConsent= value.BusinessTermsConsent,
                       @AuthorisationConsent =value.AuthorisationConsent,
                      @LoanDate= value.LoanDate,
                      @CreatedDate=  value.CreatedDate,
                      @ApprovedDate=  value.ApprovedDate
                    }).First();
                   // conn.Insert(value);
                    //var Id = value.MortgageLoanID;
                    response.MortgageId = id;
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
                    response.applications = conn.Query<MortgageLoanApplication>(" SELECT * FROM hdldb.MortgageLoanApplication where UserID= ?UserID ", new { UserID }).ToList();
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
    }
}
