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
        public ListMortgageDocResponse Get()
        {
            return repo.List();
        }

        [HttpGet("Docs/Count")]
        public int GetCount(int LoanID)
        {

            return repo.ListByMortgageLoanID(LoanID).MortgageDocs.Count;
        }

        [HttpGet("Mortgage/{MortgageLoanID}")]
        public ListMortgageDocResponse ListByMortgageLoanID(int MortgageLoanID)
        {
            return repo.ListByMortgageLoanID(MortgageLoanID);
        }

        [HttpGet("User/{UserID}")]
        public ListMortgageDocResponse ListByUserID(int UserID)
        {
            return repo.ListByUserID(UserID);
        }

        // GET api/values/5
        [HttpGet("{MortgageLoanID}")]
        public MortgageDocResponse Get(int MortgageLoanID)
        {
            return repo.Read(MortgageLoanID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromForm]MortgageLoanViewModel value)
        {
            MorgageLoanDocs valuedocs = new MorgageLoanDocs();
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //= new MorgageLoanDocs();
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                valuedocs.DocsDesc = "Loan Docs Upload";
                valuedocs.MortgageLoanID = Convert.ToInt32(value.MortgageLoanID);
                valuedocs.DocsLink = dbPath;
                valuedocs.DocsName = fileName;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                   file.CopyTo(stream);
                }

                //return Ok(new { dbPath });
            }


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            //return Ok(new { count = files.Count, size, filePath });

            return repo.Add(valuedocs);
        }

        [HttpGet("Name")]
        public string GetFileName(int LoanDocsID)
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
        public IActionResult DownloadFile(int LoanDocsID)
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
        public Response Delete(int MortgageLoanID)
        {
            return repo.Delete(MortgageLoanID);
        }


    }
}