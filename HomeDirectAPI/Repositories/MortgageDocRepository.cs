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
    public class MortgageDocRepository
    {
        private string ConnectionString;

        public MortgageDocRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }
        //DateTime? StartDate, DateTime? EndDate
        public ListMortgageDocResponse List()
        {
            ListMortgageDocResponse response = new ListMortgageDocResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.MortgageDocs = conn.GetList<MorgageLoanDocs>().ToList();
                    //if (StartDate.HasValue && EndDate.HasValue)
                    //{
                    //    response.mortgageapplications = conn.GetList<MortgageApplication>("where convert(loandate, date) between convert(?StartDate, date) and convert(?EndDate, date)", new { StartDate, EndDate }).ToList();
                    //}
                    //else
                    //{

                    //}
                    if (response.MortgageDocs.Count > 0)
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

        public MortgageDocResponse Read(int MortgageId)
        {
            MortgageDocResponse response = new MortgageDocResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.MorgageLoanDoc = conn.Get<MorgageLoanDocs>(MortgageId);
                    if (response.MorgageLoanDoc != null)
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

        public Response Add(MorgageLoanDocs value)
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

        public Response Update(MorgageLoanDocs value)
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

        public Response Delete(int MortgageId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<MorgageLoanDocs>(MortgageId);
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
