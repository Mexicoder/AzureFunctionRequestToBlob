using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Blob;

/*
************************************************
NOTE: 
    make sure you have your AzureWebJobsStorage Environmental Variable is set when trying to run
    AND 
    make sure you add this package

    dotnet add package Microsoft.Azure.WebJobs.Extensions.Storage

************************************************
*/
 
namespace Company.Function
{
    public static class HttpTrigger_test_blob_store
    {
        [FunctionName("HttpTrigger_test_blob_store")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Blob("blobverifycontainer")] CloudBlobContainer outputContainer,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
         
            /// write to the blob storage           
            await outputContainer.CreateIfNotExistsAsync();
            var blobName = Guid.NewGuid().ToString();
            var cloudBlockBlob = outputContainer.GetBlockBlobReference(blobName);
            await cloudBlockBlob.UploadTextAsync(requestBody);
 
            return new OkObjectResult(blobName);
        }
    }
}
