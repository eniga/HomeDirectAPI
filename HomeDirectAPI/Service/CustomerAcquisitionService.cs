using System;
using System.Data;
using System.Linq;
using Dapper;
using HomeDirectAPI.Models;
using HomeDirectAPI.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestSharp;

namespace HomeDirectAPI.Service
{
    public class CustomerAcquisitionService
    {
        private CustomerAcquisitionSettings config;
        private string ConnectionString;

        public CustomerAcquisitionService(IConfiguration configuration)
        {
            config = configuration.GetSection("CustomerAcquisition").Get<CustomerAcquisitionSettings>();
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public OauthTokenDetails GetToken()
        {
            using(IDbConnection conn = GetConnection())
            {
                return conn.GetList<OauthTokenDetails>().FirstOrDefault();
            }
        }

        public void SaveToken(OauthTokenDetails details)
        {
            using (IDbConnection conn = GetConnection())
            {
                var exist = GetToken() != null ? true : false;
                if (exist)
                    conn.Update(details);
                else
                    conn.Insert(details);
            }
        }

        public Object GetCustomerAcquisition(CustomerAcquisitionRequest request)
        {
            Object response = new Object();
            try
            {
                var token = RequestToken();
                RestClient client = new RestClient(config.BaseUrl);
                RestRequest req = new RestRequest("decisioning/experianone/customeracquisition/v1/applications", Method.POST);
                req.AddHeader("authorization", "Bearer " + token.access_token);
                req.AddHeader("Accept", "application/json");
                req.AddHeader("Content-Type", "application/json");
                req.AddJsonBody(request);
                var result = client.Execute(req);
                if (result.IsSuccessful)
                {
                    response = JsonConvert.DeserializeObject<CustomerAcquisitionResponse>(result.Content);
                }
                else
                {
                    response = JsonConvert.DeserializeObject<CustomerAcquisitionFailedResponse>(result.Content);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }


        public OauthTokenDetails RequestToken()
        {
            OauthTokenDetails result = null;
            try
            {
                //var tokendetails = GetToken();
                //if(tokendetails != null)
                //{
                //    return tokendetails;
                //}
                RestClient client = new RestClient(config.BaseUrl);
                RestRequest req = new RestRequest("oauth2/v1/token", Method.POST);
                req.AddHeader("Client_id", config.Client_id);
                req.AddHeader("Client_secret", config.Client_secret);
                var data = new
                {
                    username = config.Username,
                    password = config.Password
                };
                req.AddJsonBody(data);
                var response = client.Execute(req);
                if (response.IsSuccessful)
                {
                    result = JsonConvert.DeserializeObject<OauthTokenDetails>(response.Content);
                    //SaveToken(result);
                }
            }
            catch (Exception ex)
            {
                result = null;
                throw new Exception(ex.Message);
            }
            return result;
        }

        
    }
}
