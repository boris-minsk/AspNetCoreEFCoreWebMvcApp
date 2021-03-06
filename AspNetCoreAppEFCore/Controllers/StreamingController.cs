﻿using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.BusinessLogic;
using AspNetCoreAppEFCore.Filters;
using AspNetCoreAppEFCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace AspNetCoreAppEFCore.Controllers
{
    public class StreamingController : Controller
    {
        private readonly ILogger<StreamingController> _logger;
        private readonly IDataProcessor _processor;

        // Get the default form options so that we can use them to set the default limits for
        // request body data
        private static readonly FormOptions DefaultFormOptions = new FormOptions();

        public StreamingController(ILogger<StreamingController> logger, IDataProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [HttpGet]
        [GenerateAntiforgeryTokenCookieForAjax]
        public IActionResult Index()
        {
            return View();
        }

        #region Disable the form value model binding
        // 1. Disable the form value model binding here to take control of handling 
        //    potentially large files.
        // 2. Typically anti-forgery tokens are sent in request body, but since we 
        //    do not want to read the request body early, the tokens are made to be 
        //    sent via headers. The anti-forgery token filter first looks for tokens
        //    in the request header and then falls back to reading the body.
        [HttpPost]
        [DisableFormValueModelBinding]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload()
        {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                return BadRequest($"Expected a multipart request, but got {Request.ContentType}");
            }

            var filePath = Directory.GetCurrentDirectory() + @"\UploadedFiles";
            Directory.CreateDirectory(filePath);
            var targetFilePath = filePath + @"\" + "test.csv";

            // Used to accumulate all the form url encoded key value pairs in the request.
            var formAccumulator = new KeyValueAccumulator();

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                DefaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);

            var section = await reader.ReadNextSectionAsync();
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                    {
                        //targetFilePath =Path.GetTempFileName();
                        using (var targetStream = System.IO.File.Create(targetFilePath))
                        {
                            await section.Body.CopyToAsync(targetStream);

                            _logger.LogInformation($"Copied the uploaded file '{targetFilePath}'");
                        }
                    }
                    else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition))
                    {
                        // Content-Disposition: form-data; name="key" value
                        // Do not limit the key name length here because the 
                        // multipart headers length limit is already in effect.
                        var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name);
                        var encoding = GetEncoding(section);
                        using (var streamReader = new StreamReader(
                            section.Body,
                            encoding,
                            detectEncodingFromByteOrderMarks: true,
                            bufferSize: 1024,
                            leaveOpen: true))
                        {
                            // The value length limit is enforced by MultipartBodyLengthLimit
                            var value = await streamReader.ReadToEndAsync();
                            if (String.Equals(value, "undefined", StringComparison.OrdinalIgnoreCase))
                            {
                                value = String.Empty;
                            }

                            formAccumulator.Append(key.ToString(), value);

                            if (formAccumulator.ValueCount > DefaultFormOptions.ValueCountLimit)
                            {
                                throw new InvalidDataException($"Form key count limit {DefaultFormOptions.ValueCountLimit} exceeded.");
                            }
                        }
                    }
                }

                // Drains any remaining section body that has not been consumed and
                // reads the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            // Bind form data to a model
            var upload = new Upload();
            var formValueProvider = new FormValueProvider(
                BindingSource.Form,
                new FormCollection(formAccumulator.GetResults()),
                CultureInfo.CurrentCulture);

            var bindingSuccessful = await TryUpdateModelAsync(upload, prefix: "", valueProvider: formValueProvider);
            if (!bindingSuccessful)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            }

            var uploadedData = new UploadedData()
            {
                FilePath = targetFilePath
            };

            _processor.Process(uploadedData);

            return Ok(new { filePath = uploadedData.FilePath });
        }
        #endregion

        private static Encoding GetEncoding(MultipartSection section)
        {
            var hasMediaTypeHeader = MediaTypeHeaderValue.TryParse(section.ContentType, out var mediaType);
            // UTF-7 is insecure and should not be honored. UTF-8 will succeed in most cases.
            if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding))
            {
                return Encoding.UTF8;
            }
            return mediaType.Encoding;
        }
    }
}