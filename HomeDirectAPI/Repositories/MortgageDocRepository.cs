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

        public ListMortgageDocResponse ListByMortgageLoanID(long MortgageLoanID)
        {
            ListMortgageDocResponse response = new ListMortgageDocResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.MortgageDocs = conn.GetList<MorgageLoanDocs>("Where MortgageLoanID = ?MortgageLoanID", new { MortgageLoanID }).ToList();
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

        public ListMortgageDocResponse ListByUserID(long UserID)
        {
            ListMortgageDocResponse response = new ListMortgageDocResponse();
            string sql = @"SELECT A.* FROM MortgageLoanDocs A
                        INNER JOIN MortgageLoanApplication B
                        ON A.MortgageLoanID = B.MortgageLoanID
                        INNER JOIN Users C
                        ON B.UserID = C.UserID
                        WHERE C.UserID = ?UserID";
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.MortgageDocs = conn.Query<MorgageLoanDocs>(sql, new { UserID }).ToList();
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

        public MortgageDocResponse Read(long MortgageId)
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

        public Response Delete(long MortgageId)
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

        public MortgageDocResponse GetDocsPath(long LoanDocsID)
        {
            MortgageDocResponse response = new MortgageDocResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.MorgageLoanDoc = conn.Query<MorgageLoanDocs>(" SELECT * FROM MortgageLoanDocs where LoanDocsID = ?LoanDocsID ", new { LoanDocsID }).FirstOrDefault();
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
    }
}
