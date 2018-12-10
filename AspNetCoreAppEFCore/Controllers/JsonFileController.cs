using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.BusinessLogic;
using AspNetCoreAppEFCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAppEFCore.Controllers
{
    public class JsonFileController : Controller
    {
        private readonly IDataReader _reader;

        public JsonFileController(IDataReader reader)
        {
            _reader = reader;
        }

        // GET: JsonFile
        public ActionResult Index()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\UploadedFiles\test.json";
            var jFile = new JsonFile
            {
                Path = filePath,
                Body = _reader.ReadFile(filePath)
            };
            
            return View(jFile);
        }
    }
}