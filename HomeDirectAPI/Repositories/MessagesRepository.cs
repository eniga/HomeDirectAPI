using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using HomeDirectAPI.Models;
using System.Data;
using System.Linq;

namespace HomeDirectAPI.Repositories
{
    public class MessagesRepository
    {
        private string ConnectionString;

        public MessagesRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListMessagesResponse List()
        {
            ListMessagesResponse response = new ListMessagesResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.messages = conn.GetList<Messages>().ToList();
                    if (response.messages.Count > 0)
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

        public ListMessagesResponse ListByThreadID(string ThreadID)
        {
            ListMessagesResponse response = new ListMessagesResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.messages = conn.GetList<Messages>("Where ThreadID = ?ThreadID", new { ThreadID }).ToList();
                    if (response.messages.Count > 0)
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

        public ListMessagesResponse MyInbox(long UserId)
        {
            ListMessagesResponse response = new ListMessagesResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.messages = conn.GetList<Messages>("where RecipientID = ?UserId", new { UserId }).ToList();
                    if (response.messages.Count > 0)
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

        public ListMessagesResponse MyOutbox(long UserId)
        {
            ListMessagesResponse response = new ListMessagesResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.messages = conn.GetList<Messages>("where SenderID = ?UserId", new { UserId }).ToList();
                    if (response.messages.Count > 0)
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

        public MessagesResponse Read(long MessageID)
        {
            MessagesResponse response = new MessagesResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.message = conn.Get<Messages>(MessageID);
                    if (response.message != null)
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

        public Response Add(Messages value)
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

        public Response Update(Messages value)
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

        public Response Delete(long MessageID)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Messages>(MessageID);
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
