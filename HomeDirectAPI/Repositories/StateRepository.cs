using System;
using System.Data;
using System.Linq;
using Dapper;
using HomeDirectAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace HomeDirectAPI.Repositories
{
    public class StateRepository
    {
        private string ConnectionString;

        public StateRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListStateResponse List()
        {
            ListStateResponse response = new ListStateResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.states = conn.GetList<StateResp>().ToList();
                    if (response.states != null)
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

        public StateResponse GetstatebyID(long stateID)
        {
            StateResponse response = new StateResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.state = conn.Get<StateResp>(stateID);
                    if (response.state != null)
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
        public LGAResponse LgaByStateID(long stateID)
        {
            LGAResponse response = new LGAResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.lgas = conn.Query<Local>("SELECT * FROM hdldb.LGA where StateID=?stateID ", new { stateID }).ToList();
                    if (response.lgas != null)
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


        public LGAsResponse GetLgaID(long LgID)
        {
            LGAsResponse response = new LGAsResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.lga = conn.Get<Local>(LgID); //conn.Query<Local>("SELECT * FROM hdldb.LGA where StateID=?stateID ", new { LgID }).ToList();
                    if (response.lga != null)
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
