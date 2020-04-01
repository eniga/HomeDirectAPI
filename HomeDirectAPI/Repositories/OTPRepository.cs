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
    public class OTPRepository
    {
        private string ConnectionString;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public OTPRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public Response Generate(GenerateOTPRequest request)
        {
            Response response = new Response();
            try
            {
                if (string.IsNullOrEmpty(request.Email) && string.IsNullOrEmpty(request.PhoneNumber))
                {
                    response.Status =false;
                    response.Description = "Kindly provide Email or Phone Number";
                    return response;
                }
                Random generator = new Random();
                String r = generator.Next(0, 999999).ToString("D6");
                string sql = "update OTPDetails set IsValidated = 1 where IsValidated = 1 and (Email = ?Email or PhoneNumber = ?PhoneNumber)";
                OTPDetails context = new OTPDetails()
                {
                    OTP = r,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    IsValidated = false
                };
                using (IDbConnection conn = GetConnection())
                {
                    conn.Execute(sql, request);
                    conn.Insert(context);
                    response.Status = true;
                    response.Description = "Successful";
                    if (!string.IsNullOrEmpty(request.Email))
                    {
                        EmailRequest email = new EmailRequest()
                        {
                            Body = $"Your OTP is {r}",
                            Subject = "Homes Direct Verification",
                            To = request.Email
                        };
                        Helper.SendEmail(email);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public Response Validate(ValidateOTPRequest request)
        {
            Response response = new Response();
            try
            {
                response.Status = false;
                response.Description = "Invalid OTP / Email or Phone number combination";
                using (IDbConnection conn = GetConnection())
                {
                    var result = conn.GetList<OTPDetails>("Where IsValidated = 0 and (Email = ?Email or PhoneNumber = ?PhoneNumber)", request).FirstOrDefault();
                    if (result != null)
                    {
                        if (DateTime.Now.Subtract(result.DateCreated).TotalMinutes > 3)
                        {
                            response.Status = false;
                            response.Description = "OTP expired";
                        }
                        else if (result.OTP == request.OTP)
                        {
                            response.Status = true;
                            response.Description = "Successful";
                        }
                        else
                        {
                            response.Status = false;
                            response.Description = "Invalid OTP";
                        }
                        result.IsValidated = true;
                        conn.Update(result);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }
    }
}
