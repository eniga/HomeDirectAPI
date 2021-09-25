using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using HomeDirectAPI.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;

namespace HomeDirectAPI.Repositories
{
    public static class Helper
    {
        private static string key = "Diamondbank1!";
        static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static bool SaveImage(string ImgStr, string ImgName)
        {
            bool result = false;
            try
            {
                String path = "~/images/prodimages/"; //Path

                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                //set the image path
                string imgPath = Path.Combine(path, ImgName);

                if (File.Exists(imgPath))
                {
                    File.Delete(imgPath);
                }
                //string imgUrl = ImgStr.Split(',')[1];
                var imageParts = ImgStr.Split(',').ToList<string>()[1];
                byte[] imageBytes = Convert.FromBase64String(imageParts);

                //File.WriteAllBytes(imgPath, imageBytes);
                File.WriteAllBytes(imgPath, Convert.FromBase64String(ImgStr.Split(',').ToList()[1]));

                result = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return result;
        }

        public static bool IsNumeric(string value)
        {
            logger.Debug("IsNumeric: request for " + value);
            bool ok = value.All(char.IsNumber);
            logger.Debug("IsNumeric: response for " + ok.ToString());
            return ok;
        }

        public static string ObjectToXml(object obj)
        {
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.GetEncoding("UTF-16")
            };

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(obj.GetType());

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(xmlWriter, obj, namespaces);
                }
                return stringWriter.ToString();
            }
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9.,]+/", "", RegexOptions.Compiled);
        }

        static Random random = new Random();

        public static string GenerateRandomNumber(long count)
        {
            StringBuilder builder = new StringBuilder();

            for (long i = 0; i < count; i++)
            {
                long number = random.Next(10);
                builder.Append(number);
            }

            return builder.ToString();
        }

        public static Response SendEmail(EmailRequest request)
        {
            Response response = new Response();
            try
            {
                SmtpClient client = new SmtpClient("mail.apis.ng");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("verify@apis.ng", "Password1x");
                client.Port = 587;
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("verify@apis.ng");
                mailMessage.To.Add(request.To);
                mailMessage.Body = request.Body;
                mailMessage.Subject = request.Subject;
                client.Send(mailMessage);
                response.Status = true;
                response.Description = "Successful";
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = {
        "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
        "abcdefghijkmnopqrstuvwxyz",    // lowercase
        "0123456789",                   // digits
        "!@$?_-"                        // non-alphanumeric
    };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (long i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);


            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
