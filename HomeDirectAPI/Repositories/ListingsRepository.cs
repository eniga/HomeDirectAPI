using System;
using System.Data;
using System.Linq;
using Dapper;
using HomeDirectAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using TEntity = HomeDirectAPI.Models.Listings;

namespace HomeDirectAPI.Repositories
{
    public class ListingsRepository
    {
        private string ConnectionString;

        public ListingsRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public ListListingsResponse List()
        {
            ListListingsResponse response = new ListListingsResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.listings = conn.GetList<TEntity>().ToList();
                    if (response.listings.Count > 0)
                    {
                        int i = 0;
                        while (i < response.listings.Count)
                        {
                            var id = response.listings[i].user_id;
                            var user = conn.Get<User>(id);
                            if (user != null)
                                response.listings[i].user_name = user.FullName;
                            i++;
                        }
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

        public ListListingsResponse ListByDeveloperId(string developerId)
        {
            ListListingsResponse response = new ListListingsResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.listings = conn.GetList<TEntity>().Where(x => x.user_id == developerId).ToList();
                    if (response.listings.Count > 0)
                    {
                        int i = 0;
                        while (i < response.listings.Count)
                        {
                            var id = response.listings[i].user_id;
                            var user = conn.Get<User>(id);
                            if (user != null)
                                response.listings[i].user_name = user.FullName;
                            i++;
                        }
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

        public ListingsResponse Read(long id)
        {
            ListingsResponse response = new ListingsResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    response.listing = conn.Get<TEntity>(id);
                    if (response.listing != null)
                    {
                        var user = conn.Get<User>(response.listing.user_id);
                        if (user != null)
                            response.listing.user_name = user.FullName;
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

        public Response Add(TEntity value)
        {
            Response response = new Response();
            try
            {
                var exist = List().listings.Where(x => x.prop_address.ToLower() == value.prop_address.ToLower());
                if (exist.Count() > 0)
                {
                    response.Status = false;
                    response.Description = "Record already exists";
                    return response;
                }
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

        public Response Update(TEntity value)
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

        public Response UpdateStatus(long id, Listings status)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var item = Read(id);
                    if(item.listing == null)
                    {
                        response.Status = false;
                        response.Description = "Invalid Property";
                        return response;
                    }
                    var listing = item.listing;
                    listing.status = status.status;
                    conn.Update(listing);
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

        public Response Delete(long id)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<TEntity>(id);
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
