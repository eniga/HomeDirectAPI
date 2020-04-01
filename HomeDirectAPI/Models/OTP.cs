using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("otpdetails")]
    public class OTPDetails
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
        [ReadOnly(true)]
        public DateTime DateCreated { get; set; }
        public bool IsValidated { get; set; }
        [ReadOnly(true)]
        public DateTime DateValidated { get; set; }
    }

    public class ValidateOTPRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
    }

    public class GenerateOTPRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
