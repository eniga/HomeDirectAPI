using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeDirectAPI.Models
{
    public class CustomerAcquisitionAuth
    {
        public string command { get; set; }
        public bool merge { get; set; }
        public Settings settings { get; set; }
        public string data { get; set; }
        public string method { get; set; }
        public object selector { get; set; }
    }

    public class AjaxPageState
    {
        public string theme { get; set; }
        public string theme_token { get; set; }
    }

    [Table("experian_auth_details")]
    public class OauthTokenDetails
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string issued_at { get; set; }
        public string refresh_token { get; set; }
        [Key]
        public string token_type { get; set; }
    }

    public class ExperianCustom
    {
        public OauthTokenDetails oauth_token_details { get; set; }
    }

    public class Settings
    {
        public AjaxPageState ajaxPageState { get; set; }
        public string basePath { get; set; }
        public ExperianCustom experian_custom { get; set; }
        public string pathPrefix { get; set; }
    }
}
