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