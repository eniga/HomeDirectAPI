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
    public class LoanPartnersRepository
    {
        private string ConnectionString;

        public LoanPartnersRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }
        //DateTime? StartDate, DateTime? EndDate
        public ListpartersResponse List()
        {
            ListpartersResponse response = new ListpartersResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.partners = conn.GetList<LoanPartners>().ToList();
                    //if (StartDate.HasValue && EndDate.HasValue)
                    //{
                    //    response.mortgageapplications = conn.GetList<MortgageApplication>("where convert(loandate, date) between convert(?StartDate, date) and convert(?EndDate, date)", new { StartDate, EndDate }).ToList();
                    //}
                    //else
                    //{

                    //}
                    if (response.partners.Count > 0)
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

        public PartnersResponse Read(int MortgageLoanID)
        {
            PartnersResponse response = new PartnersResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.partner = conn.Get<LoanPartners>(MortgageLoanID);
                    if (response.partner != null)
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

        public ListpartersResponse GetPartnerByUserID(int UserID)
        {
            ListpartersResponse response = new ListpartersResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.partners = conn.Query<LoanPartners>(" SELECT * FROM hdldb.LoanPartners where UserID= ?UserID ", new { UserID }).ToList();
                    if (response.partners.Count > 0)
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

        public ListpartersResponse GetLoanByEmail(string email)
        {
            ListpartersResponse response = new ListpartersResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.partners = conn.Query<LoanPartners>(" SELECT * FROM hdldb.MortgageLoanApplication where Email= ?Email ", new { email }).ToList();
                    if (response.partners.Count > 0)
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
        public Response Add(LoanPartners value)
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
    }
}
