using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HomeDirectAPI.Models;
using HomeDirectAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace HomeDirectAPI.Controllers
{
    [Route("api/[controller]")]
    public class MortgageDocsController : Controller
    {
        MortgageDocRepository repo;

        public MortgageDocsController(IConfiguration configuration)
        {
            repo = new MortgageDocRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListMortgageDocResponse List()
        {
            return repo.List();
        }

        [HttpGet("Docs/Count")]
        public long GetCount(long LoanID)
        {

            return repo.ListByMortgageLoanID(LoanID).MortgageDocs.Count;
        }

        [HttpGet("Mortgage/{MortgageLoanID}")]
        public ListMortgageDocResponse ListByMortgageLoanID(long MortgageLoanID)
        {
            return repo.ListByMortgageLoanID(MortgageLoanID);
        }

        [HttpGet("User/{UserID}")]
        public ListMortgageDocResponse ListByUserID(long UserID)
        {
            return repo.ListByUserID(UserID);
        }

        // GET api/values/5
        [HttpGet("{MortgageLoanID}")]
        public MortgageDocResponse Get(long MortgageLoanID)
        {
            return repo.Read(MortgageLoanID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody] MortgageLoanViewModel value)
        {
            Response response = new Response();

            try
            {
                string base64String = value.attachment;
                string ImageType = base64String.Split(';')[0].Split('/')[1];
                string ImageName = $"image_{DateTime.Now.ToString("yyyyMMddhhmmssff")}.{ImageType}";
                String path = "~/Resources/Uploads/";

                MorgageLoanDocs valuedocs = new MorgageLoanDocs()
                {
                    attachment = value.attachment,
                    DocsDesc = "Loan Docs Upload",
                    DocsLink = path,
                    DocsName = ImageName,
                    LoanDocsID = value.LoanDocsID,
                    MortgageLoanID = Convert.ToInt32(value.MortgageLoanID)
                };


                Helper.SaveImage(base64String, ImageName);

                // process uploaded files
                // Don't rely on or trust the FileName property without validation.

                //return Ok(new { count = files.Count, size, filePath });

                response = repo.Add(valuedocs);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        [HttpGet("Name")]
        public string GetFileName(long LoanDocsID)
        {
            string fileName = string.Empty;
            MortgageDocResponse docs = repo.GetDocsPath(LoanDocsID);
            fileName = docs.MorgageLoanDoc.DocsName;
            return fileName;
        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        [HttpPost("Download/LoanDocs")]
        public IActionResult DownloadFile(long LoanDocsID)
        {
            //MortgageDocResponse docsresp = new MortgageDocResponse();
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            MortgageDocResponse docsPath = repo.GetDocsPath(LoanDocsID);

            //currentDirectory = currentDirectory + "\\src\\assets"Path.Combine(Path.Combine(currentDirectory, "attachments"), fileName);;
            var filelink = docsPath.MorgageLoanDoc.DocsLink;

            var file = Path.Combine(currentDirectory, filelink);

            var memory = new MemoryStream();
            using (var stream = new FileStream(file, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(file));
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]MorgageLoanDocs value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{MortgageLoanID}")]
        public Response Delete(long MortgageLoanID)
        {
            return repo.Delete(MortgageLoanID);
        }


    }
}